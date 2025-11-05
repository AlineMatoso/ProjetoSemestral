const API_URL = "http://localhost:5128/api";

async function request(endpoint, options = {}) {
  const response = await fetch(`${API_URL}/${endpoint}`, {
    headers: { "Content-Type": "application/json" },
    ...options,
  });

  if (!response.ok) {
    throw new Error("Erro de comunicação com o servidor");
  }

  const data = await response.json();
  if (!data.status) {
    throw new Error(data.mensagem || "Erro ao processar requisição");
  }

  return data.dados;
}

export { request };