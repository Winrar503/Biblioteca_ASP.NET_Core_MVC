//using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.EN
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = string.Empty;

        [NotMapped]
        public int Top_Aux { get; set; } //propiedad auxiliar
        public List<Usuarios>? Users { get; set; } //propiedad de navegación
    }
}
