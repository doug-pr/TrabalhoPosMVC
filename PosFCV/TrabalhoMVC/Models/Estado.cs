using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoMVC.Models
{
    public class Estado
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        public List<Cidade> Cidades { get; set; }   
    }
}
