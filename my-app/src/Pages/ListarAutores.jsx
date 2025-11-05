import { useEffect, useState } from "react";
import { ListarAutores } from "../Services/AutorService.jsx";
import Card from "../Components/Card.jsx";

export default function getAutores() {
    const [autores, setAutores] = useState([]);
    const [erro, setErro] = useState(null);

    useEffect(() => {
        const carregar = async () => {
            try {
                const dados = await ListarAutores();
                setAutores(dados);
            } catch (e) {
                setErro(e.message);
            }
        };

        carregar();
    }, []);

    return (
        <div>
            <h1>Autores</h1>

            {erro && <p style={{ color: "red" }}>{erro}</p>}

            <div className="cards-container">
                {autores.map((autor) => (
                    <Card key={autor.id}>
                       {autor.id}. {autor.nome} {autor.sobrenome}
                    </Card>
                ))}
            </div>
        </div>
    );
}
