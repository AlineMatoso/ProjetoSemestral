using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LivrosApi.Models
{
    public class LivrosModel
    {
        public int Id { get; set; } 
        
       
        public string? Titulo { get; set; }
        
        // Adicione a relação com Autor
        public int AutorId { get; set; }
        
        [JsonIgnore]
        public AutorModel? Autor { get; set; }
    }
}