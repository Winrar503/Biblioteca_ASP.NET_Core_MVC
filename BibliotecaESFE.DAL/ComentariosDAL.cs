using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class ComentariosDAL
    {
        public static async Task<int> CreateAsync(Comentarios comentarios)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Comentarios.Add(comentarios);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Comentarios comentarios)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var comentariosDB = bdContexto.Autores.FirstOrDefault(a => a.Id == comentarios.Id);
                if (comentariosDB != null)
                {
                    bdContexto.Autores.Remove(comentariosDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<Comentarios> GetByIdAsync(Comentarios comentarios)
        {
            var comentariosDB = new Comentarios();
            using (var bdContexto = new ContextoBD())
            {
                comentariosDB = await bdContexto.Comentarios.FirstOrDefaultAsync(a => a.Id == comentarios.Id);
            }
            return comentariosDB;
        }
        public static async Task<List<Comentarios>> GetAllAsync()
        {
            var comentarios = new List<Comentarios>();
            using (var bdContexto = new ContextoBD())
            {
                comentarios = await bdContexto.Comentarios.ToListAsync();
            }
            return comentarios;
        }
    }
}
