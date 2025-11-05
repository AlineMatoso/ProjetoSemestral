import { useState } from "react";
import { EditarAutor } from "../Services/AutorService";

export default function putAutor() {
    const [id, setId] = useState("");
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState("");
    const [mensagem, setMensagem] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const resposta = await EditarAutor({ id, nome, sobrenome });
            setMensagem(resposta.mensagem || "Autor editado com sucesso!");
            setId("");
            setNome("");
            setSobrenome("");
        } catch (error) {
            setMensagem(error.message || "Erro ao editar autor");
        }
    };

    return (
        <div>
            <h1>Editar Autor</h1>
            {mensagem && <p>{mensagem}</p>}

            <form onSubmit={handleSubmit}>
                <input
                    type="number"
                    placeholder="ID"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                    required
                />

                <input
                    type="text"
                    placeholder="Nome"
                    value={nome}
                    onChange={(e) => setNome(e.target.value)}
                    required
                />

                <input
                    type="text"
                    placeholder="Sobrenome"
                    value={sobrenome}
                    onChange={(e) => setSobrenome(e.target.value)}
                    required
                />

                <button type="submit">Salvar</button>
            </form>
        </div>
    );
}
