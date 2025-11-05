import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { BuscarLivroPorAutor } from "../Services/LivroService";
import Card from "../Components/Card.jsx";

export default function LivrosPorAutor() {
  const { id } = useParams();
  const [livros, setLivros] = useState([]);
  const [mensagem, setMensagem] = useState(null);

  useEffect(() => {
    async function carregar() {
      try {
        const dados = await BuscarLivroPorAutor(id);
        setLivros(dados);
      } catch (error) {
        setMensagem(error.message);
      }
    }
    carregar();
  }, [id]);

  return (
    <div>
      <h1>Livros do Autor {livros[0]?.autor?.nome} {livros[0]?.autor?.sobrenome} </h1>
      {mensagem && <p>{mensagem}</p>}
        <div className="cards-container">
          {livros.map((livro) => (
            <Card key={livro.id}>
                {livro.id}.{livro.titulo}
            </Card>
          ))}
        </div>
    </div>
  );
}
