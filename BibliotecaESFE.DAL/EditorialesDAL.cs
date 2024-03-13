using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class EditorialesDAL
    {
        public static async Task<int> CreateAsync(Editoriales editoriales)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Editoriales.Add(editoriales);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }



        public static async Task<int> DeleteAsync(Editoriales editoriales)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var editorialesDB = await bdContexto.Editoriales.FirstOrDefaultAsync(e => e.Id == editoriales.Id);
                if (editorialesDB != null)
                {
                    bdContexto.Editoriales.Remove(editorialesDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

        }
        public static async Task<Editoriales> GetByIdAsync(Editoriales editoriales)
        {
            var editorialesDB = new Editoriales();
            using (var bdContexto = new ContextoBD())
            {
                editorialesDB = await bdContexto.Editoriales.FirstOrDefaultAsync(e => e.Id == editoriales.Id);
            }
            return editorialesDB;
        }
        public static async Task<List<Editoriales>> GetAllAsync()
        {
            var editorialeos = new List<Editoriales>();
            using (var bdContexto = new ContextoBD())
            {
                editorialeos = await bdContexto.Editoriales.ToListAsync();
            }
            return editorialeos;
        }
        internal static IQueryable<Editoriales> QuerySelect(IQueryable<Editoriales> query, Editoriales editoriales)
        {
            if (editoriales.Id > 0)
            
            {
                query = query.Where(l => l.Id == editoriales.Id);
            }
            if (!string.IsNullOrEmpty(editoriales.Nombre))
            {
                query = query.Where(l => l.Nombre.Contains(editoriales.Nombre));
            }
            query = query.OrderByDescending(l => l.Id);
            if (editoriales.Top_Aux > 0)
            {
                query = query.Take(editoriales.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<int> UpdateAsync(Editoriales editoriales)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var editorialesDB = await bdContexto.Editoriales.FirstOrDefaultAsync(c => c.Id == editoriales.Id);
                if (editorialesDB != null)
                {
                    editorialesDB.Nombre = editoriales.Nombre;
                    bdContexto.Update(editorialesDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<List<Editoriales>> SearchAsync(Editoriales editoriales)
        {
            var editorial = new List<Editoriales>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Editoriales.AsQueryable();
                select = QuerySelect(select, editoriales);
                editorial = await select.ToListAsync();
            }
            return editorial;
        }
    }
}
