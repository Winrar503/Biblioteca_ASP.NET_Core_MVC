using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Editoriales
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Favor llenar")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Libros> Libros { get; set; } = new List<Libros>();
    }
}
