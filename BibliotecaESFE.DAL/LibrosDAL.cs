using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class LibrosDAL
    {
        public static async Task<int> CreateAsync(Libros libros)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Libros.Add(libros);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }


        public static async Task<int> UpdateAsync(Libros libros)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var librosDB = await bdContexto.Libros.FirstOrDefaultAsync(l => l.Id == libros.Id);
                if (librosDB != null)
                {
                    librosDB.titulo = libros.titulo;
                    bdContexto.Update(librosDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<int> DeleteAsync(Libros libros)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var librosDB = await bdContexto.Libros.FirstOrDefaultAsync(l => l.Id == libros.Id);
                if (librosDB != null)
                {
                    bdContexto.Libros.Remove(librosDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

        }
        public static async Task<Libros> GetByIdAsync(Libros libros)
        {
            var librosDB = new Libros();
            using (var bdContexto = new ContextoBD())
            {
                librosDB = await bdContexto.Libros.FirstOrDefaultAsync(l => l.Id == libros.Id);
            }
            return librosDB;
        }
        public static async Task<List<Libros>> GetAllAsync()
        {
            var libroes = new List<Libros>();
            using (var bdContexto = new ContextoBD())
            {
                libroes = await bdContexto.Libros.ToListAsync();
            }
            return libroes;
        }
        internal static IQueryable<Libros> QuerySelect(IQueryable<Libros> query, Libros libros)
        {
            if (libros.Id > 0)
            {
                query = query.Where(l => l.Id == libros.Id);
            }
            if (!string.IsNullOrEmpty(libros.titulo))
            {
                query = query.Where(l => l.titulo.Contains(libros.titulo));
            }
            query = query.OrderByDescending(l => l.Id);
            if (libros.Top_Aux > 0)
            {
                query = query.Take(libros.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<List<Libros>> SearchAsync(Libros libros)
        {
            var libroes = new List<Libros>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Libros.AsQueryable();
                select = QuerySelect(select, libros);
                libroes = await select.ToListAsync();
            }
            return libroes;
        }
        public static async Task<List<Libros>> SearchIncludeCludeCategoryAsync(Libros libros)
        {
            var libro = new List<Libros>();
            using (var bdContxto = new ContextoBD())
            {
                var selec = bdContxto.Libros.AsQueryable();
                selec = QuerySelect(selec, libros).Include(l => l.Autores).Include(l => l.Categorias).Include(l => l.Editoriales).AsQueryable();
                libro = await selec.ToListAsync();
            }
            return libro;
        }
    }
}
