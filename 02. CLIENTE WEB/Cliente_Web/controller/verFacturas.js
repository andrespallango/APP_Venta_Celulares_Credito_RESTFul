const SOAP_ENDPOINT_FACTURA = "http://localhost:8080/Examen_Practico_Primer_Parcial/FacturaService";

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

// Función para obtener facturas por cédula
async function obtenerFacturasPorCedula(cedula) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ws="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ws:obtenerFacturasPorCedula>
                 <cedula>${cedula}</cedula>
              </ws:obtenerFacturasPorCedula>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody, SOAP_ENDPOINT_FACTURA);
    const facturas = [];
    const facturaNodes = xmlResponse.getElementsByTagName("return");

    for (let i = 0; i < facturaNodes.length; i++) {
        facturas.push({
            cedulaCliente: facturaNodes[i].getElementsByTagName("cedulaCliente")[0]?.textContent,
            codCliente: facturaNodes[i].getElementsByTagName("codCliente")[0]?.textContent,
            codFactura: facturaNodes[i].getElementsByTagName("codFactura")[0]?.textContent,
            fecha: facturaNodes[i].getElementsByTagName("fecha")[0]?.textContent.split("T")[0].replace(/-/g, "/"),
            formaPago: facturaNodes[i].getElementsByTagName("formaPago")[0]?.textContent,
            nombreCliente: facturaNodes[i].getElementsByTagName("nombreCliente")[0]?.textContent,
            total: parseFloat(facturaNodes[i].getElementsByTagName("total")[0]?.textContent || 0),
        });
    }

    return facturas;
}

// Función para obtener el detalle de una factura por su código
async function obtenerDetalleFacturaPorCodigo(codFactura) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ws="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ws:obtenerDetalleFacturaPorCodigo>
                 <codFactura>${codFactura}</codFactura>
              </ws:obtenerDetalleFacturaPorCodigo>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody, SOAP_ENDPOINT_FACTURA);
    const detalles = [];
    const detalleNodes = xmlResponse.getElementsByTagName("return");

    for (let i = 0; i < detalleNodes.length; i++) {
        detalles.push({
            cantidad: parseInt(detalleNodes[i].getElementsByTagName("cantidad")[0]?.textContent || 0, 10),
            codDetalle: detalleNodes[i].getElementsByTagName("codDetalle")[0]?.textContent,
            codFactura: detalleNodes[i].getElementsByTagName("codFactura")[0]?.textContent,
            codProducto: detalleNodes[i].getElementsByTagName("codProducto")[0]?.textContent,
            nombreProducto: detalleNodes[i].getElementsByTagName("nombreProducto")[0]?.textContent,
            precioUnitario: parseFloat(detalleNodes[i].getElementsByTagName("precioUnitario")[0]?.textContent || 0),
            subtotal: parseFloat(detalleNodes[i].getElementsByTagName("subtotal")[0]?.textContent || 0),
        });
    }

    return detalles;
}

// Manejo del formulario para buscar facturas por cédula
document.getElementById("consultaFacturasForm").addEventListener("submit", async (event) => {
    event.preventDefault();
    const cedula = document.getElementById("cedula").value.trim();
    if (!cedula) {
        alert("Ingrese una cédula válida.");
        return;
    }

    try {
        const facturas = await obtenerFacturasPorCedula(cedula);
        const facturasTableBody = document.getElementById("facturasTableBody");
        facturasTableBody.innerHTML = "";

        if (facturas.length === 0) {
            facturasTableBody.innerHTML = "<tr><td colspan='4'>No se encontraron facturas.</td></tr>";
            return;
        }

        facturas.forEach(factura => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${factura.codFactura}</td>
                <td>${factura.fecha}</td>
                <td>${factura.formaPago}</td>
                <td><button onclick="mostrarDetalleFactura(${factura.codFactura}, '${factura.nombreCliente}', '${factura.cedulaCliente}', '${factura.fecha}', '${factura.formaPago}', ${factura.total})">Ver Detalle</button></td>
            `;
            facturasTableBody.appendChild(row);
        });
    } catch (error) {
        console.error("[Buscar Facturas] Error:", error);
        alert("Error al buscar facturas.");
    }
});

// Función para mostrar el detalle de una factura
window.mostrarDetalleFactura = async function(codFactura, nombreCliente, cedulaCliente, fecha, formaPago, totalFactura) {
    try {
        const detalles = await obtenerDetalleFacturaPorCodigo(codFactura);
        const detallesTableBody = document.getElementById("detallesTableBody");
        detallesTableBody.innerHTML = "";

        if (detalles.length === 0) {
            detallesTableBody.innerHTML = "<tr><td colspan='4'>No se encontraron detalles para esta factura.</td></tr>";
            return;
        }

        let total = 0;
        detalles.forEach(detalle => {
            total += detalle.subtotal;
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${detalle.codProducto}</td>
                <td>${detalle.nombreProducto}</td>
                <td>${detalle.cantidad}</td>
                <td>$${detalle.precioUnitario.toFixed(2)}</td>
            `;
            detallesTableBody.appendChild(row);
        });

        const subtotal = total / 1.12;
        const iva = total - subtotal;

        document.getElementById("detalleFacturaInfo").innerHTML = `
            <p><strong>Código Factura:</strong> ${codFactura}</p>
            <p><strong>Fecha:</strong> ${fecha}</p>
            <p><strong>Forma de Pago:</strong> ${formaPago}</p>
            <p><strong>Nombre Cliente:</strong> ${nombreCliente}</p>
            <p><strong>Cédula Cliente:</strong> ${cedulaCliente}</p>
            <p><strong>Subtotal:</strong> $${subtotal.toFixed(2)}</p>
            <p><strong>IVA (12%):</strong> $${iva.toFixed(2)}</p>
            <p><strong>Total:</strong> $${total.toFixed(2)}</p>
        `;

        document.getElementById("detalleFacturaModal").style.display = "block";
    } catch (error) {
        console.error("[Detalle Factura] Error:", error);
        alert("Error al obtener el detalle de la factura.");
    }
};

// Función para cerrar el modal de detalle de factura
window.cerrarDetalleFacturaModal = function() {
    document.getElementById("detalleFacturaModal").style.display = "none";
};