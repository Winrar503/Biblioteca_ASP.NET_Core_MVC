using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Registro
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Usuarios")]
        [Required(ErrorMessage = "El usuario es requerido")]
        [Display(Name = "Usuario")]
        public int Usuario_id { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin {  get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public Usuarios Usuarios { get; set; } = new Usuarios();    }
}
