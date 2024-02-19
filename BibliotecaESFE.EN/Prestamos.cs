using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Prestamos
    {
        [Key]
        
        public int Id { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }
        [ForeignKey("Libros")]
        public int LibroId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public  DateTime FechaDevolucion { get; set; }


        [NotMapped]
        public int Top_Aux { get; set; }
        public Usuarios Usuarios { get; set; } = new Usuarios();
        public Libros Libros { get; set; } = new Libros();

    }
}
