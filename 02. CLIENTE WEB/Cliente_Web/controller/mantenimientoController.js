const SOAP_ENDPOINT = "http://localhost:8080/Examen_Practico_Primer_Parcial/TelefonoService";

// Función genérica para enviar solicitudes SOAP
async function sendSoapRequest(soapBody) {
    try {
        const response = await fetch(SOAP_ENDPOINT, {
            method: "POST",
            headers: {
                "Content-Type": "text/xml; charset=utf-8",
            },
            body: soapBody,
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const textResponse = await response.text();
        const parser = new DOMParser();
        return parser.parseFromString(textResponse, "text/xml");
    } catch (error) {
        console.error("Error en la solicitud SOAP:", error);
        throw error;
    }
}

// Operaciones SOAP
async function listarTelefonos() {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:listarTelefonos/>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);

    const telefonos = [];
    const telefonoNodes = xmlResponse.getElementsByTagName("return");
    for (let i = 0; i < telefonoNodes.length; i++) {
        const telefono = {
            codProducto: telefonoNodes[i].getElementsByTagName("codProducto")[0]?.textContent,
            nombre: telefonoNodes[i].getElementsByTagName("nombre")[0]?.textContent,
            precio: telefonoNodes[i].getElementsByTagName("precio")[0]?.textContent,
            foto: telefonoNodes[i].getElementsByTagName("foto")[0]?.textContent, // Incluye foto
        };
        telefonos.push(telefono);
    }

    return telefonos;
}

async function crearTelefono(nombre, precio, foto) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:crearTelefono>
                 <nombre>${nombre}</nombre>
                 <precio>${precio}</precio>
                 <foto>${foto}</foto> <!-- Foto añadida -->
              </ec:crearTelefono>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);
    const resultNode = xmlResponse.getElementsByTagName("return")[0];
    return resultNode?.textContent === "true";
}

async function actualizarTelefono(codProducto, nombre, precio, foto) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:actualizarTelefono>
                 <codProducto>${codProducto}</codProducto>
                 <nombre>${nombre}</nombre>
                 <precio>${precio}</precio>
                 <foto>${foto}</foto> <!-- Foto añadida -->
              </ec:actualizarTelefono>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);
    const resultNode = xmlResponse.getElementsByTagName("return")[0];
    return resultNode?.textContent === "true";
}

async function eliminarTelefono(codProducto) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:eliminarTelefono>
                 <codProducto>${codProducto}</codProducto>
              </ec:eliminarTelefono>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);
    const resultNode = xmlResponse.getElementsByTagName("return")[0];
    return resultNode?.textContent === "true";
}

// Manejo de la interfaz
const form = document.getElementById("productoForm");
const modal = document.getElementById("productoModal");
const confirmacionModal = document.getElementById("confirmacionModal");
const modalTitle = document.getElementById("modalTitle");
const crearProductoBtn = document.getElementById("crearProductoBtn");
const productosTableBody = document.querySelector("#productosTable tbody");
const confirmarEliminarBtn = document.getElementById("confirmarEliminar");
const cancelarEliminarBtn = document.getElementById("cancelarEliminar");
let productoAEliminar = null;

// Funciones para manejar el modal
function mostrarModal(titulo, producto = null) {
    modalTitle.textContent = titulo;
    modal.style.display = "block";
    if (producto) {
        document.getElementById("codProducto").value = producto.codProducto;
        document.getElementById("nombre").value = producto.nombre;
        document.getElementById("precio").value = producto.precio;
        document.getElementById("foto").value = producto.foto; // Foto añadida
    } else {
        form.reset();
    }
}

function ocultarModal() {
    modal.style.display = "none";
    form.reset();
}

function mostrarConfirmacionModal(codProducto) {
    confirmacionModal.style.display = "block";
    productoAEliminar = codProducto;
}

function ocultarConfirmacionModal() {
    confirmacionModal.style.display = "none";
    productoAEliminar = null;
}

// Manejo del CRUD
async function cargarProductos() {
    productosTableBody.innerHTML = "<tr><td colspan='5'>Cargando...</td></tr>";
    try {
        const productos = await listarTelefonos();
        productosTableBody.innerHTML = "";
        productos.forEach(producto => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${producto.codProducto}</td>
                <td>${producto.nombre}</td>
                <td>$${parseFloat(producto.precio).toFixed(2)}</td>
                <td><img src="${producto.foto}" alt="Foto" style="width: 50px; height: 50px;"></td>
                <td>
                    <button class="editar-btn" data-id="${producto.codProducto}" data-nombre="${producto.nombre}" data-precio="${producto.precio}" data-foto="${producto.foto}">Editar</button>
                    <button class="eliminar-btn" data-id="${producto.codProducto}">Eliminar</button>
                </td>
            `;
            productosTableBody.appendChild(row);
        });

        // Asignar eventos dinámicamente
        document.querySelectorAll(".editar-btn").forEach(btn => {
            btn.addEventListener("click", event => {
                const codProducto = event.target.getAttribute("data-id");
                const nombre = event.target.getAttribute("data-nombre");
                const precio = event.target.getAttribute("data-precio");
                const foto = event.target.getAttribute("data-foto");
                mostrarModal("Editar Producto", { codProducto, nombre, precio, foto });
            });
        });

        document.querySelectorAll(".eliminar-btn").forEach(btn => {
            btn.addEventListener("click", event => {
                const codProducto = event.target.getAttribute("data-id");
                mostrarConfirmacionModal(codProducto);
            });
        });
    } catch (error) {
        productosTableBody.innerHTML = "<tr><td colspan='5'>Error al cargar productos.</td></tr>";
    }
}

async function guardarProducto(event) {
    event.preventDefault();
    const codProducto = document.getElementById("codProducto").value;
    const nombre = document.getElementById("nombre").value;
    const precio = document.getElementById("precio").value;
    const foto = document.getElementById("foto").value;

    if (codProducto) {
        await actualizarTelefono(codProducto, nombre, precio, foto);
    } else {
        await crearTelefono(nombre, precio, foto);
    }

    ocultarModal();
    cargarProductos();
}

async function confirmarEliminarProducto() {
    if (productoAEliminar) {
        await eliminarTelefono(productoAEliminar);
        cargarProductos();
        ocultarConfirmacionModal();
    }
}

// Eventos
form.addEventListener("submit", guardarProducto);
crearProductoBtn.addEventListener("click", () => mostrarModal("Crear Producto"));
confirmarEliminarBtn.addEventListener("click", confirmarEliminarProducto);
cancelarEliminarBtn.addEventListener("click", ocultarConfirmacionModal);

// Inicializar productos
cargarProductos();
