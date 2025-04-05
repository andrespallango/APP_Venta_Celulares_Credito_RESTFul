const SOAP_ENDPOINT_CREDITO = "http://localhost:8080/Examen_Practico_Primer_Parcial/CreditoService";
const SOAP_ENDPOINT_FACTURA = "http://localhost:8080/Examen_Practico_Primer_Parcial/FacturaService";
const SOAP_ENDPOINT_TELEFONO = "http://localhost:8080/Examen_Practico_Primer_Parcial/TelefonoService";

let productosSeleccionados = [];
let codCliente = null;
let montoMaximoCredito = 0;

// Referencias a elementos del DOM
const cedulaClienteInput = document.getElementById("cedulaCliente");
const verificarClienteBtn = document.getElementById("verificarClienteBtn");
const clienteInfo = document.getElementById("clienteInfo");
const clienteSujetoCredito = document.getElementById("clienteSujetoCredito");
const montoMaximoCreditoElement = document.getElementById("montoMaximoCredito");
const formaPagoContainer = document.getElementById("formaPagoContainer");
const pagoEfectivo = document.getElementById("pagoEfectivo");
const pagoCredito = document.getElementById("pagoCredito");
const productosContainer = document.getElementById("productosContainer");
const codigoProductoInput = document.getElementById("codigoProducto");
const cantidadProductoInput = document.getElementById("cantidadProducto");
const agregarProductoBtn = document.getElementById("agregarProductoBtn");
const productosSeleccionadosTable = document.getElementById("productosSeleccionados").querySelector("tbody");
const totalVentaElement = document.getElementById("totalVenta");
const cuotasContainer = document.getElementById("cuotasContainer");
const numeroCuotasInput = document.getElementById("numeroCuotas");
const registrarVentaBtn = document.getElementById("registrarVentaBtn");

// Función genérica para enviar solicitudes SOAP
async function sendSoapRequest(soapBody, endpoint) {
    const response = await fetch(endpoint, {
        method: "POST",
        headers: { "Content-Type": "text/xml; charset=utf-8" },
        body: soapBody,
    });

    if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
    const textResponse = await response.text();
    const parser = new DOMParser();
    return parser.parseFromString(textResponse, "text/xml");
}

// Obtener código del cliente
async function obtenerCodigoCliente(cedula) {
    const soapBody = `<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
        <soapenv:Body>
            <ec:obtenerCodigoCliente>
                <cedula>${cedula}</cedula>
            </ec:obtenerCodigoCliente>
        </soapenv:Body>
    </soapenv:Envelope>`;

    const response = await sendSoapRequest(soapBody, SOAP_ENDPOINT_CREDITO);
    const resultNode = response.getElementsByTagName("return")[0];
    return parseInt(resultNode?.textContent || "-1", 10);
}

// Verificar sujeto de crédito
async function verificarSujetoCredito(cedula) {
    const soapBody = `<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
        <soapenv:Body>
            <ec:verificarSujetoCredito>
                <cedula>${cedula}</cedula>
            </ec:verificarSujetoCredito>
        </soapenv:Body>
    </soapenv:Envelope>`;

    const response = await sendSoapRequest(soapBody, SOAP_ENDPOINT_CREDITO);
    const resultNode = response.getElementsByTagName("return")[0];
    return resultNode?.textContent === "true";
}

// Calcular monto máximo de crédito
async function calcularMontoMaximoCredito(codCliente) {
    const soapBody = `<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
        <soapenv:Body>
            <ec:calcularMontoMaximoCredito>
                <codCliente>${codCliente}</codCliente>
            </ec:calcularMontoMaximoCredito>
        </soapenv:Body>
    </soapenv:Envelope>`;

    const response = await sendSoapRequest(soapBody, SOAP_ENDPOINT_CREDITO);
    const resultNode = response.getElementsByTagName("return")[0];
    return parseFloat(resultNode?.textContent || "0");
}

async function buscarTelefonoPorCodigo(codigo) {
    const telefonos = await listarTelefonos();
    return telefonos.find(telefono => telefono.codProducto === codigo) || null;
}

// Reutilizamos la función listarTelefonos para obtener todos los productos
async function listarTelefonos() {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:listarTelefonos/>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody, SOAP_ENDPOINT_TELEFONO);

    const telefonos = [];
    const telefonoNodes = xmlResponse.getElementsByTagName("return");
    for (let i = 0; i < telefonoNodes.length; i++) {
        const telefono = {
            codProducto: telefonoNodes[i].getElementsByTagName("codProducto")[0]?.textContent,
            nombre: telefonoNodes[i].getElementsByTagName("nombre")[0]?.textContent,
            precio: parseFloat(telefonoNodes[i].getElementsByTagName("precio")[0]?.textContent),
            foto: telefonoNodes[i].getElementsByTagName("foto")[0]?.textContent, // Incluye la foto
        };
        telefonos.push(telefono);
    }

    return telefonos;
}

// Verificar cliente y asignar datos
verificarClienteBtn.addEventListener("click", async () => {
    const cedula = cedulaClienteInput.value.trim();
    if (!cedula) {
        alert("Ingrese una cédula válida.");
        return;
    }

    try {
        codCliente = await obtenerCodigoCliente(cedula);
        const sujetoCredito = await verificarSujetoCredito(cedula);

        if (sujetoCredito) {
            montoMaximoCredito = await calcularMontoMaximoCredito(codCliente);
            clienteSujetoCredito.textContent = "El cliente es sujeto de crédito.";
            montoMaximoCreditoElement.textContent = `Monto máximo de crédito: $${montoMaximoCredito.toFixed(2)}`;
            pagoCredito.disabled = false; // Habilitar la opción de crédito
        } else {
            clienteSujetoCredito.textContent = "El cliente no es sujeto de crédito.";
            montoMaximoCreditoElement.textContent = "";
            pagoCredito.disabled = true; // Deshabilitar la opción de crédito
            pagoCredito.checked = false; // Desmarcar la opción de crédito
            cuotasContainer.style.display = "none"; // Ocultar el contenedor de cuotas
        }

        clienteInfo.style.display = "block";
        formaPagoContainer.style.display = "block";
    } catch (error) {
        console.error("[Verificar Cliente] Error:", error);
        alert("Error verificando cliente.");
    }
});

// Registrar venta
registrarVentaBtn.addEventListener("click", async () => {
    if (!codCliente) {
        alert("El cliente no está registrado.");
        return;
    }

    const totalVenta = productosSeleccionados.reduce((sum, p) => sum + p.subtotal, 0);
    const formaPago = pagoCredito.checked ? "Crédito" : "Efectivo";

    if (formaPago === "Crédito" && totalVenta > montoMaximoCredito) {
        alert("El total excede el monto máximo de crédito permitido.");
        return;
    }

    const detalles = productosSeleccionados.map(p => ({
        codProducto: p.codProducto,
        cantidad: p.cantidad,
        precioUnitario: p.precioUnitario,
        subtotal: p.subtotal,
    }));

    const soapBody = `<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
        <soapenv:Body>
            <ec:crearFactura>
                <codCliente>${codCliente}</codCliente>
                <formaPago>${formaPago}</formaPago>
                ${detalles
                    .map(
                        d => `<detalles>
                            <codProducto>${d.codProducto}</codProducto>
                            <cantidad>${d.cantidad}</cantidad>
                            <precioUnitario>${d.precioUnitario}</precioUnitario>
                            <subtotal>${d.subtotal}</subtotal>
                        </detalles>`
                    )
                    .join("")}
            </ec:crearFactura>
        </soapenv:Body>
    </soapenv:Envelope>`;

    try {
        const response = await sendSoapRequest(soapBody, SOAP_ENDPOINT_FACTURA);
        const resultNode = response.getElementsByTagName("return")[0];
        const success = resultNode?.textContent === "true";

        if (success) {
            alert("Venta registrada correctamente.");
            if (formaPago === "Crédito") {
                const numeroCuotas = parseInt(numeroCuotasInput.value, 10);
                await otorgarCredito(numeroCuotas, totalVenta);
            }
            window.location.reload();
        } else {
            alert("Error registrando venta.");
        }
    } catch (error) {
        console.error("[Registrar Venta] Error:", error);
        alert("Error procesando la venta.");
    }
});

// Otorgar crédito y crear amortización
async function otorgarCredito(numeroCuotas, totalVenta) {
    const soapBody = `<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
        <soapenv:Body>
            <ec:otorgarCreditoYCrearAmortizacion>
                <codCliente>${codCliente}</codCliente>
                <precioTelefono>${totalVenta}</precioTelefono>
                <numeroCuotas>${numeroCuotas}</numeroCuotas>
            </ec:otorgarCreditoYCrearAmortizacion>
        </soapenv:Body>
    </soapenv:Envelope>`;

    const response = await sendSoapRequest(soapBody, SOAP_ENDPOINT_CREDITO);
    const resultNode = response.getElementsByTagName("return")[0];
    const success = resultNode?.textContent === "true";

    if (success) {
        alert("Crédito otorgado y amortización creada.");
    } else {
        alert("Error al otorgar crédito.");
    }
};

pagoCredito.addEventListener("click", () => {
    cuotasContainer.style.display = "block";
    productosContainer.style.display = "block";
    registrarVentaBtn.disabled = false;
});

pagoEfectivo.addEventListener("click", () => {
    cuotasContainer.style.display = "none";
    productosContainer.style.display = "block";
    registrarVentaBtn.disabled = false;
});

agregarProductoBtn.addEventListener("click", async () => {
    const codProducto = codigoProductoInput.value.trim();
    const cantidad = parseInt(cantidadProductoInput.value, 10);

    if (!codProducto || cantidad <= 0) {
        alert("Ingrese un código de producto y una cantidad válidos.");
        return;
    }

    try {
        const producto = await buscarTelefonoPorCodigo(codProducto);
        if (!producto) {
            alert("Producto no encontrado.");
            return;
        }

        const subtotal = producto.precio * cantidad;
        productosSeleccionados.push({
            codProducto: producto.codProducto,
            nombre: producto.nombre,
            cantidad,
            precioUnitario: producto.precio,
            subtotal,
            foto: producto.foto, // Guarda la URL de la foto
        });

        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${producto.codProducto}</td>
            <td>${producto.nombre}</td>
            <td>${cantidad}</td>
            <td>$${subtotal.toFixed(2)}</td>
            <td><button onclick="mostrarFoto('${producto.foto}')">Ver Foto</button></td>
        `;
        productosSeleccionadosTable.appendChild(row);

        const total = productosSeleccionados.reduce((sum, p) => sum + p.subtotal, 0);
        totalVentaElement.textContent = total.toFixed(2);

        codigoProductoInput.value = "";
        cantidadProductoInput.value = "";
    } catch (error) {
        console.error("[Agregar Producto] Error:", error);
        alert("Error al agregar producto.");
    }
});