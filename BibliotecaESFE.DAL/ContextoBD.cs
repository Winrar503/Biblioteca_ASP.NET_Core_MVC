using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class ContextoBD : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<RegistroSecionesUsuarios> Registro_Sesiones_Usuario { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Editoriales> Editoriales { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<CalificacionesResenias> CalificacionesResenias { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Role> Role { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = WINRAR\SQLEXPRESS;
                                           Initial Catalog = BibliotecaESFE;
                                           Integrated Security = true;
                                           Encrypt = false;
                                           TrustServerCertificate = true;");
        }
    }   
}
