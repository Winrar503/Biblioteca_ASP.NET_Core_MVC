using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Categorias
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Favor llenar")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; } = string.Empty;
        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Libros> Libros { get; set; } = new List<Libros>();

    }
}
