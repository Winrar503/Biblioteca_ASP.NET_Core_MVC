using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class CalificacionesResenias
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId {  get; set; }
        [ForeignKey("Libros")]
        public int LibroId { get; set; }
        [Display(Name = "Calificacion")]
        public int Calificacion {  get; set; }
        [Display(Name = "Comentario")]
        public string Comentario { get; set; } = string.Empty;
        public DateTime FechaCalificacion { get; set; }

        [NotMapped]
        public int Top_Aux {  get; set; }
        public Usuarios? Usuarios { get; set; }
        public Libros? Libros { get; set; }
    }
}
