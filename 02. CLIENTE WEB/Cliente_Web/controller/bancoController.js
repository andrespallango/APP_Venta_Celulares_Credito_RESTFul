const SOAP_ENDPOINT = "http://localhost:8080/Examen_Practico_Primer_Parcial/CreditoService";

// Función para enviar solicitudes SOAP
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

// Verificar si el cliente es sujeto de crédito
async function verificarSujetoCredito(cedula) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:verificarSujetoCredito>
                 <cedula>${cedula}</cedula>
              </ec:verificarSujetoCredito>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);

    const resultNode = xmlResponse.getElementsByTagName("return")[0];
    return resultNode ? resultNode.textContent === "true" : false;
}

// Calcular el monto máximo de crédito
async function calcularMontoMaximoCredito(codCliente) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:calcularMontoMaximoCredito>
                 <codCliente>${codCliente}</codCliente>
              </ec:calcularMontoMaximoCredito>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);

    const resultNode = xmlResponse.getElementsByTagName("return")[0];
    return resultNode ? parseFloat(resultNode.textContent) : 0;
}

// Obtener el código del cliente según la cédula
async function obtenerCodigoCliente(cedula) {
    const soapBody = `
        <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ec="http://ws.monster.edu.ec/">
           <soapenv:Header/>
           <soapenv:Body>
              <ec:obtenerCodigoCliente>
                 <cedula>${cedula}</cedula>
              </ec:obtenerCodigoCliente>
           </soapenv:Body>
        </soapenv:Envelope>`;

    const xmlResponse = await sendSoapRequest(soapBody);

    const resultNode = xmlResponse.getElementsByTagName("return")[0];
    return resultNode ? parseInt(resultNode.textContent, 10) : -1;
}

export { verificarSujetoCredito, calcularMontoMaximoCredito, obtenerCodigoCliente };
