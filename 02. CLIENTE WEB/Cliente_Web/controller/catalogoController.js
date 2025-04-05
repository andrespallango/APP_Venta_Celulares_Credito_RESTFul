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

// Función para listar teléfonos
async function listarTelefonos() {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:listarTelefonos/>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);

    // Procesar la respuesta SOAP
    const telefonos = [];
    const telefonoNodes = xmlResponse.getElementsByTagName("return");
    for (let i = 0; i < telefonoNodes.length; i++) {
        const telefono = {
            codProducto: telefonoNodes[i].getElementsByTagName("codProducto")[0]?.textContent,
            nombre: telefonoNodes[i].getElementsByTagName("nombre")[0]?.textContent,
            precio: telefonoNodes[i].getElementsByTagName("precio")[0]?.textContent,
            foto: telefonoNodes[i].getElementsByTagName("foto")[0]?.textContent, // Nueva propiedad
        };
        telefonos.push(telefono);
    }

    return telefonos;
}

export { listarTelefonos };
