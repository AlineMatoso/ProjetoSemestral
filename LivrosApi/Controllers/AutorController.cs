using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {

        private readonly AutorInterface _autorInterface;
        public AutorController(AutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }


        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutoriPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutoriPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutoriPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
         public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }


    }
}

