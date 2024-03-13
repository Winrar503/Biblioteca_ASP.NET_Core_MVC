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
        public string titulo { get; set; } = string.Empty;
        [ForeignKey("Autores")]
        public int autorId { get; set; }
        [ForeignKey("Editoriales")]
        public int editorialId { get; set; }
        [ForeignKey("Categorias")]
        public int categoriaId { get; set; }
        [Required(ErrorMessage = "Favor llenar")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string disponibilidad { get; set; } = string.Empty;

        [NotMapped]
        public int Top_Aux {  get; set; }
        public Autores Autores { get; set; } = new Autores();
        public Editoriales Editoriales { get; set; } = new Editoriales();
        public Categorias Categorias { get; set; } = new Categorias();
    }
}
