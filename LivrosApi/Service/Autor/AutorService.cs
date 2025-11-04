using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using LivrosApi.Data;
using LivrosApi.DTO;
using LivrosApi.DTO.Autor;
using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace LivrosApi.Controllers.AutorService
{
    public class AutorService : AutorInterface
    {
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        public  async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try{
                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                
                resposta.Mensagem = "Autor criado com sucesso!";

                return resposta;
                
            } catch (Exception ex){
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            


        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor com este ID.";
                    return resposta;
                }

                autor.Nome = autorEdicaoDto.Nome;

                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Update(autor);

                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor atualizado.";

                return resposta;

            } catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }





        }

        async public Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado.";
                    return resposta;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();

                resposta.Mensagem = "Autor excluido. ";
                return resposta;

            } catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }



        }

        async Task<ResponseModel<AutorModel>> AutorInterface.BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco =>autorBanco.Id == idAutor);

                if (autor == null){
                    resposta.Mensagem = "Nenhum autor localizado. ";
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado.";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        async Task<ResponseModel<AutorModel>> AutorInterface.BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                //entra do livro model, ai quando chega em autor model ele entra em autor model e 
                // depois ve todos as propriedades do autor

                if (livro == null)
                {
                    resposta.Mensagem = ("Nenhum autor localizado. ");
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = ("Autor Localizado!");
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        async Task<ResponseModel<List<AutorModel>>> AutorInterface.ListarAutores()
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
