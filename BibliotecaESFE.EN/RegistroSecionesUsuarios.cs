using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class RegistroSecionesUsuarios
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Usuarios")]
        [Required(ErrorMessage = "El usuario es requerido")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public Usuarios Usuarios { get; set; } = new Usuarios();    }
}
