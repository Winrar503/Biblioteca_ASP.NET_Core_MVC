using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public  class Reservas
    {
        [Key ] 
        public int Id { get; set; } 
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaReserva {  get; set; }


        [NotMapped]
        public int Top_Aux { get; set; }
        public Usuarios Usuarios { get; set; } = new Usuarios();
        public Libros Libros { get; set; }  = new Libros();

    }
}
