const listaAutores = document.getElementById("autores-lista");
const apiUrl = "http://localhost:5128/api/Autor/ListarAutores";

const getAutores = async () => {
    try {
        // Faz o fetch da API
        const response = await fetch(apiUrl);
        const resultado = await response.json();

        // Checa se o backend retornou algum erro
        if (!resultado.status) {
            listaAutores.innerText = `Erro: ${resultado.mensagem}`;
            return;
        }

        // Limpa a lista antes de popular
        listaAutores.innerHTML = "";

        // Itera pelos autores e adiciona na lista
        resultado.dados.forEach(autor => {
            const li = document.createElement("li");


            li.innerText = `Nome: ${autor.nome}`;
            listaAutores.appendChild(li);
        });

    } catch (error) {
        console.error("Erro JS/REDE:", error.message);
        alert("Erro inesperado. Verifique sua conexão e tente novamente.");
    }
};

// Chama a função ao carregar o script
getAutores();