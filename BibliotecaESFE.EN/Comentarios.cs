using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Comentarios
    {

        [Key]
        public int Id { get; set; }
        public int Usuarioid { get; set; }
        public int LIbroid { get; set; }
        public string Comentario {  get; set; } = string.Empty;
        public DateTime FechaComentario { get; set; }


        [NotMapped]
        public int Top_Aux { get; set; }
        public  Usuarios Usuarios { get; set; } = new Usuarios();
        public Libros Libros { get; set; } = new Libros();

    }
}
