using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrosApi.Data;
using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Controllers.AutorService
{
    public class AutorService : AutorInterface
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<AutorModel>> BuscarAutoriPorId(int idAutor)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram cadastrados.";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
