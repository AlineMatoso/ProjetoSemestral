import { useEffect, useState } from "react";
import { ListarLivros } from "../Services/LivroService.jsx";
import Card from "../Components/Card.jsx";

export default function getLivros() {
    const [livros, setLivros] = useState([]);
    const [erro, setErro] = useState(null);

    useEffect(() => {
        const carregar = async () => {
            try {
                const dados = await ListarLivros();
                setLivros(dados);
            } catch (e) {
                setErro(e.message);
            }
        };

        carregar();
    }, []);

    return (
        <div>
            <h1>Livros</h1>

            {erro && <p style={{ color: "red" }}>{erro}</p>}

            <div className="cards-container">
                {livros.map((livro) => (
                    <Card key={livro.id}>
                       {livro.id}. {livro.titulo} Autor: {livro.autor.nome} {livro.autor.sobrenome}
                    </Card>
                ))}
            </div>
        </div>
    );
}
