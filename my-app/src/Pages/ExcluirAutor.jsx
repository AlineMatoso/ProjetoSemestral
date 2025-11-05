import { useState } from "react";
import { ExcluirAutor } from "../Services/AutorService";

export default function deleteAutor() {
    const [id, setId] = useState("");
    const [mensagem, setMensagem] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const resposta = await ExcluirAutor(Number(id));
            setMensagem(resposta.mensagem || "Autor deletado com sucesso!");
            setId("");
        } catch (error) {
            setMensagem(error.message || "Erro ao excluir autor");
        }
    };

    return (
        <div>
            <h1>Excluir Autor</h1>
            {mensagem && <p>{mensagem}</p>}

            <form onSubmit={handleSubmit}>
                <input
                    type="number"
                    placeholder="ID"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    required
                />

                <button type="submit">Excluir</button>
            </form>
        </div>
    );
}
