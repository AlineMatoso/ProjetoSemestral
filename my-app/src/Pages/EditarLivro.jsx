import { useState } from "react";
import { EditarLivro} from "../Services/LivroService";

export default function putLivro() {
    const [id, setId] = useState("");
    const [titulo, setTitulo] = useState("");
    const [autorId, setAutorId] = useState("");
    const [mensagem, setMensagem] = useState(null);

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const resposta = await EditarLivro({ id, titulo, autorId });
            setMensagem(resposta.mensagem || "Livro editado com sucesso!");
            setId("");
            setTitulo("");
            setAutorId("");
        } catch (error) {
            setMensagem(error.message || "Erro ao editar livro");
        }
    };

    return (
        <div>
            <h1>Editar Livro</h1>
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
                    placeholder="Título"
                    value={titulo}
                    onChange={(e) => setTitulo(e.target.value)}
                    required
                />

                <input
                    type="number"
                    placeholder="Id Autor"
                    value={autorId}
                    onChange={(e) => setAutorId(e.target.value)}
                    required
                />

                <button type="submit">Salvar</button>
            </form>
        </div>
    );
}
