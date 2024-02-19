using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Autores
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requrido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "La nacionalida es requrida")]
        [Display(Name = "Nacionalida")]
        public string Nacionalida { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; } = string.Empty;

        [NotMapped]
        public int Top_Aux { get; set; }
        public List<Libros> Libros { get; set; } = new List<Libros>();

    }
}
