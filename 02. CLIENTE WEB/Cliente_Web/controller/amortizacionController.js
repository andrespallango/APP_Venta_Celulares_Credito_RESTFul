const REST_ENDPOINT_CLIENTE = "https://localhost:7268/api/Cliente";
const REST_ENDPOINT_AMORTIZACION = "https://localhost:7268/api/Amortizacion";


// Referencias a elementos del DOM
const amortizacionForm = document.getElementById("amortizacionForm");
const cedulaClienteInput = document.getElementById("cedulaCliente");
const amortizacionContainer = document.getElementById("amortizacionContainer");
const amortizacionTableBody = document.getElementById("amortizacionTable").querySelector("tbody");

// Función genérica para enviar solicitudes REST
async function sendRestRequest(url, method = "GET", body = null) {
    console.log(`[REST REQUEST] ${method} ${url}`);
    if (body) console.log("[REST REQUEST] Body:", JSON.stringify(body));

    try {
        const options = {
            method,
            headers: { "Content-Type": "application/json" },
        };

        if (body) options.body = JSON.stringify(body);

        const response = await fetch(url, options);
        console.log(`[REST RESPONSE] Status: ${response.status}`);

        if (!response.ok) throw new Error(`HTTP error! Status: ${response.status}`);

        return await response.json();
    } catch (error) {
        console.error("[REST ERROR] Error en la solicitud:", error);
        throw error;
    }
}

// Obtener código de crédito basado en la cédula del cliente
async function obtenerCodigoCredito(cedula) {
    const url = `${REST_ENDPOINT_CLIENTE}/obtenerCodigoCliente/${cedula}`;
    return await sendRestRequest(url);
}

// Obtener tabla de amortización basada en el código de crédito
async function obtenerTablaAmortizacion(codCredito) {
    const url = `${REST_ENDPOINT_AMORTIZACION}/credito/${codCredito}`;
    return await sendRestRequest(url);
}

// Manejo del formulario
amortizacionForm.addEventListener("submit", async (event) => {
    event.preventDefault();
    const cedula = cedulaClienteInput.value.trim();

    if (!cedula) {
        alert("Ingrese una cédula válida.");
        return;
    }

    try {
        // Obtener código de crédito
        const codCredito = await obtenerCodigoCredito(cedula);
        if (!codCredito) {
            alert("No se encontró crédito asociado a esta cédula.");
            amortizacionContainer.style.display = "none";
            return;
        }

        // Obtener y mostrar tabla de amortización
        const amortizaciones = await obtenerTablaAmortizacion(codCredito);
        amortizacionTableBody.innerHTML = "";

        if (amortizaciones.length === 0) {
            alert("No se encontraron registros de amortización.");
            amortizacionContainer.style.display = "none";
            return;
        }

        amortizaciones.forEach(amortizacion => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${amortizacion.codAmortizacion}</td>
                <td>${amortizacion.codCredito}</td>
                <td>$${amortizacion.capitalPagado.toFixed(2)}</td>
                <td>$${amortizacion.interesPagado.toFixed(2)}</td>
                <td>${amortizacion.numCuota}</td>
                <td>$${amortizacion.saldo.toFixed(2)}</td>
                <td>$${amortizacion.valorCuota.toFixed(2)}</td>
                <td>${amortizacion.fechaPago}</td>`;
            amortizacionTableBody.appendChild(row);
        });

        amortizacionContainer.style.display = "block";
    } catch (error) {
        console.error("[AMORTIZACION] Error:", error);
        alert("Error al consultar la tabla de amortización.");
    }
});
