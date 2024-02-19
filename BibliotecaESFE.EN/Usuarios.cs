using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Es necesario que llenes todo")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string nombreUsuario { get; set; } = string.Empty;
        public string correoElectronico { get; set; } = string.Empty;
        public string contrasena { get; set; } = string.Empty;
        public DateTime fechaRegistro { get;}


        [NotMapped]
        //Para hacer paginacion
        public int Top_Aux { get; set; }
        //lista
        public List<Registro> Reg { get; set; } = new List<Registro> { };
        public List<Reservas> Reservas { get; set; } = new List<Reservas> { };

        public List<Comentarios> Comentarios { get; set; } = new List<Comentarios> { };
        public List<Calificaciones> Calificaciones { get; set; } = new List<Calificaciones> { };    
        public List<Prestamos> Prestamos { get; set; } = new List<Prestamos> { };   


    }
}
