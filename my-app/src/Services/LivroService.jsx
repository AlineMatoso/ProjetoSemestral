import { request } from "./Api";

export const ListarLivros = async () => {
  return request("Livro/ListarLivros");
};

export const BuscarLivroPorAutor = (idAutor) =>
  request(`Livro/BuscarLivroPorIdAutor/${idAutor}`);

export const CriarLivro = (livro) =>
  request("Livro/CriarLivro", {
    method: "POST",
    body: JSON.stringify(livro),
  });

export const EditarLivro = (livro) =>
  request("Livro/EditarLivro", {
    method: "PUT",
    body: JSON.stringify(livro),
  });

export const ExcluirLivro = (idLivro) =>
  request(`Livro/ExcluirLivro/${idLivro}`, 
    { method: "DELETE" });