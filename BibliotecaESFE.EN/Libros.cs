using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Titulo { get; set; } = string.Empty;
        [ForeignKey("Autores")]
        public int AutorId { get; set; }
        [ForeignKey("Editoriales")]
        public int EditorialId { get; set; }
        [ForeignKey("Categorias")]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "Favor llenar")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Disponibilidad { get; set; } = string.Empty;

        [NotMapped]
        public int Top_Aux {  get; set; }
        public Autores? Autores { get; set; }
        public Editoriales? Editoriales { get; set; }
        public Categorias? Categorias { get; set; }
        public List<Reservas>? Reservas { get; set; }
    }
}
