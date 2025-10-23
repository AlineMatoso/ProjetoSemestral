namespace LivrosApi
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } // para quando eu quiser deixar ele ser nulo, posso colocar "?" no final do tipo da variavel, --> string?

        public string Sobrenome { get; set; }

        public ICollection<LivrosModel> livros{}
    }
    
    
}