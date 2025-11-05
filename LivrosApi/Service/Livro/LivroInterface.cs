using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrosApi.DTO;
using LivrosApi.DTO.Autor;
using LivrosApi.DTO.Livro;
using LivrosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Service.Livro
{
    public interface LivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDTO livroEdicaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idAutor);
    }
}