using System.Text.Json.Serialization;
using LivrosApi.Models;

namespace LivrosApi
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }

        [JsonIgnore]
        public ICollection<LivrosModel> Livros { get; set; } = new List<LivrosModel>();
    }
}