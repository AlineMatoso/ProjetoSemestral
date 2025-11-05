using LivrosApi.Models;

namespace LivrosApi.DTO.Livro
{
    public class LivroCriacaoDTO
    {
        public string? Titulo { get; set; }
        public AutorModel? Autor{ get; set; }
        
    }
}