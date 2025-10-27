using System.Text.Json.Serialization;
using LivrosApi.Models;

namespace LivrosApi
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } // para quando eu quiser deixar ele ser nulo, posso colocar "?" no final do tipo da variavel, --> string?

        public string Sobrenome { get; set; }

        [JsonIgnore] // quando eu crio um autor, eu nao preciso colocar todos os livros registrados, posso só 
                     // colocar o nome e sobrenome, e posso deixar a lista de livros nula. 
        public ICollection<LivrosModel> Livros { get; set; }
        // Essa propriedade serve para fazer uma relação entre o autormodel e o livromodel
    }


}