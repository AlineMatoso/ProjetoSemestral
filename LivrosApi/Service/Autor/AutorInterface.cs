using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrosApi.Models;

namespace LivrosApi.Controllers
{
    public interface AutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutoriPorId(int idAutor);

        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);



    }
}