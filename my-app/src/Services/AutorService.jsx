import { request } from "./Api";

export const ListarAutores = async () => {
  return request("Autor/ListarAutores");
};

export const BuscarAutorPorId = async (idAutor) => {
  return request(`Autor/BuscarAutorPorId/${idAutor}`);
};

export const BuscarAutorPorIdLivro = async (idLivro) => {
  return request(`Autor/BuscarAutorPorIdLivro/${idLivro}`);
};

export const CriarAutor = (autor) =>
  request("Autor/CriarAutor", {
    method: "POST",
    body: JSON.stringify(autor),
  });

export const EditarAutor = (autor) =>
  request("Autor/EditarAutor", {
    method: "PUT",
    body: JSON.stringify(autor),
  });

export const ExcluirAutor = (idAutor) =>
  request(`Autor/ExcluirAutor/${idAutor}`, 
    { method: "DELETE" });