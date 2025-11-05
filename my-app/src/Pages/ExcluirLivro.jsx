import { useState } from "react";
import { ExcluirLivro } from "../Services/LivroService";

export default function deleteLivro() {
    const [idLivro, setIdLivro] = useState("");
    const [mensagem, setMensagem] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const resposta = await ExcluirLivro(Number(idLivro));
            setMensagem(resposta.mensagem || "Livro deletado com sucesso!");
            setIdLivro("");
        } catch (error) {
            setMensagem(error.message || "Erro ao excluir Livro");
        }
    };

    return (
        <div>
            <h1>Excluir Livro</h1>
            {mensagem && <p>{mensagem}</p>}

            <form onSubmit={handleSubmit}>
                <input
                    type="number"
                    placeholder="ID"
                    value={idLivro}
                    onChange={(e) => setIdLivro(e.target.value)}
                    required
                />

                <button type="submit">Excluir</button>
            </form>
        </div>
    );
}
