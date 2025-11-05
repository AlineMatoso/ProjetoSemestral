import { useState } from "react";
import { CriarAutor } from "../Services/AutorService";

export default function postAutor() {
  const [nome, setNome] = useState("");
  const [sobrenome, setSobrenome] = useState("");
  const [mensagem, setMensagem] = useState(null);

  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const resposta = await CriarAutor({ nome, sobrenome });
      setMensagem(resposta.mensagem || "Autor cadastrado com sucesso!");
      setNome("");
      setSobrenome("");
    } catch (error) {
      setMensagem(error.message || "Erro ao cadastrar autor");
    }
  };

  return (
    <div>
      <h1>Cadastrar Autor</h1>
      {mensagem && <p>{mensagem}</p>}

      <form onSubmit={handleSubmit}>
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
