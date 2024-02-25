using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class CategoriasDAL
    {
        public static async Task<int> CreateAsync(Categorias categorias)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Categorias.Add(categorias);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Categorias categorias)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var categoriasDB = await bdContexto.Categorias.FirstOrDefaultAsync(l => l.Id == categorias.Id);
                if (categoriasDB != null)
                {
                    bdContexto.Categorias.Remove(categoriasDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

        }
        public static async Task<Categorias> GetByIdAsync(Categorias categorias)
        {
            var categoriasDB = new Categorias();
            using (var bdContexto = new ContextoBD())
            {
                categoriasDB = await bdContexto.Categorias.FirstOrDefaultAsync(c => c.Id == categorias.Id);
            }
            return categoriasDB;
        }
        public static async Task<List<Categorias>> GetAllAsync()
        {
            var categori = new List<Categorias>();
            using (var bdContexto = new ContextoBD())
            {
                categori = await bdContexto.Categorias.ToListAsync();
            }
            return categori;
        }
        internal static IQueryable<Categorias> QuerySelect(IQueryable<Categorias> query, Categorias categorias)
        {
            if (categorias.Id > 0)
            {
                query = query.Where(c => c.Id == categorias.Id);
            }
            if (!string.IsNullOrEmpty(categorias.Name))
            {
                query = query.Where(c => c.Name.Contains(categorias.Name));
            }
            query = query.OrderByDescending(c => c.Id);
            if (categorias.Top_Aux > 0)
            {
                query = query.Take(categorias.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<List<Categorias>> SearchAsync(Categorias categorias)
        {
            var categorias1 = new List<Categorias>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Categorias.AsQueryable();
                select = QuerySelect(select, categorias);
                categorias1 = await select.ToListAsync();
            }
            return categorias1;
        }
    }
}
