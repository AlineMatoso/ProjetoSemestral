import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import Home from "./Pages/Home";
import ListarAutores from "./Pages/ListarAutores";
import CriarAutor from "./Pages/CriarAutor";
import EditarAutor from "./Pages/EditarAutor";
import ExcluirAutor from "./Pages/ExcluirAutor";
import ListarLivros from "./Pages/ListarLivros";
import CriarLivro from "./Pages/CriarLivro";
import EditarLivro from "./Pages/EditarLivro";
import ExcluirLivro from "./Pages/ExcluirLivro";
import LivrosPorAutor from "./Pages/LivrosPorAutor";
import './styles/App.css';

export default function App() {
  return (
    <BrowserRouter>
      <header>
        <nav>
          <Link to="/">Home</Link> |
          <Link to="/ListarAutores">Listar Autores</Link> |
          <Link to="/CriarAutor">Criar Autor</Link> |
          <Link to="/EditarAutor">Editar Autor</Link> |
          <Link to="/ExcluirAutor">Excluir Autor</Link> |
          <Link to="/ListarLivros">Listar Livros</Link> |
          <Link to="/CriarLivro">Criar Livro</Link> |
          <Link to="/EditarLivro">Editar Livro</Link> |
          <Link to="/ExcluirLivro">Excluir Livro</Link> |
        </nav>
      </header>

      <main>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/ListarAutores" element={<ListarAutores />} />
          <Route path="/CriarAutor" element={<CriarAutor />} />
          <Route path="/EditarAutor" element={<EditarAutor />} />
          <Route path="/ExcluirAutor" element={<ExcluirAutor />} />
          <Route path="/ListarLivros" element={<ListarLivros />} />
          <Route path="/CriarLivro" element={<CriarLivro />} />
          <Route path="/EditarLivro" element={<EditarLivro />} />
          <Route path="/ExcluirLivro" element={<ExcluirLivro />} />
          <Route path="/autores/:id/livros" element={<LivrosPorAutor />} />
        </Routes>
      </main>
    </BrowserRouter>
  );
}
