using LivrosApi.Models;

namespace LivrosApi.DTO.Livro
{
    public class LivroEdicaoDTO
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public AutorModel? Autor{ get; set; }
    }
}