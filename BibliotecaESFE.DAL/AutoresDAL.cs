using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaESFE.DAL
{
    public class AutoresDAL
    {
        public static async Task<int> CreateAsync(Autores autores)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Autores.Add(autores);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Autores autores)
        {
            int result = 0;
            using(var bdContexto = new ContextoBD())
            {
                var autoresDB = await bdContexto.Autores.FirstOrDefaultAsync(a => a.Id == autores.Id);
                if (autoresDB != null)
                {
                    autoresDB.Nombre = autores.Nombre;
                    bdContexto.Update(autoresDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<int> DeleteAsync(Autores autores)
        {
            int result = 0;
            using(var bdContexto = new ContextoBD())
            {
                var autoresDB = bdContexto.Autores.FirstOrDefault(a => a.Id == autores.Id);
                if (autoresDB != null)
                {
                    bdContexto.Autores.Remove(autoresDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<Autores> GetByIdAsync(Autores autores)
        {
            var autoresDB = new Autores();
            using (var bdContexto = new ContextoBD())
            {
                autoresDB = await bdContexto.Autores.FirstOrDefaultAsync(a => a.Id == autores.Id);
            }
            return autoresDB;
        }
        public static async Task<List<Autores>> GetAllAsync()
        {
            var autor = new List<Autores>();
            using (var bdContexto = new ContextoBD())
            {
                autor = await bdContexto.Autores.ToListAsync();
            }
            return autor;
        }
        internal static IQueryable<Autores> QuerySelect(IQueryable<Autores> query, Autores autores)
        {
            if (autores.Id > 0)
            {
                query = query.Where(c => c.Id == autores.Id);
            }
            if (!string.IsNullOrEmpty(autores.Nombre))
            {
                query = query.Where(c => c.Nombre.Contains(autores.Nombre));
            }
            query = query.OrderByDescending(c => c.Id);
            if (autores.Top_Aux > 0)
            {
                query = query.Take(autores.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<List<Autores>> SearchAsync(Autores autores)
        {
            var autoros = new List<Autores>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Autores.AsQueryable();
                select = QuerySelect(select, autores);
                autoros = await select.ToListAsync();
            }
            return autoros;
        }

    }
}
