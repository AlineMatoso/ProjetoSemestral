import { useState } from "react";
import { CriarLivro } from "../Services/LivroService";

export default function postLivro() {
  const [titulo, setTitulo] = useState("");
  const [autorId, setAutorId] = useState("");
  const [mensagem, setMensagem] = useState(null);

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const resposta = await CriarLivro({ titulo, autorId });
      setMensagem(resposta.mensagem || "Livro cadastrado com sucesso!");
      setTitulo("");
      setAutorId("");
    } catch (error) {
      setMensagem(error.message || "Erro ao cadastrar livro");
    }
  };

  return (
    <div>
      <h1>Cadastrar Livro</h1>
      {mensagem && <p>{mensagem}</p>}

      <form onSubmit={handleSubmit}>
        <input 
          type="text"
          placeholder="Titulo"
          value={titulo}
          onChange={(e) => setTitulo(e.target.value)}
          required
        />

        <input 
          type="text"
          placeholder="Id do Autor"
          value={autorId}
          onChange={(e) => setAutorId(e.target.value)}
          required
        />

        <button type="submit">Salvar</button>
      </form>
    </div>
  );
}
