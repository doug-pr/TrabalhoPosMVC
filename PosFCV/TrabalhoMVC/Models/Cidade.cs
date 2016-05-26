using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoMVC.Models
{
    public class Cidade
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        
        public int CodigoEstado { get; set; }
        [Required]
        [ForeignKey("CodigoEstado")]
        public Estado Estado { get; set; }
    }
}
