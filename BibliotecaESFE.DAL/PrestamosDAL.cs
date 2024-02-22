using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class PrestamosDAL
    {
        public static async Task<int> CreateAsync(Prestamos prestamos)
        {
            int result = 0;
            using(var bdContexto = new ContextoBD())
            {
                bdContexto.Prestamos.Add(prestamos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Prestamos prestamos)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var prestamosDB = await bdContexto.Prestamos.FirstOrDefaultAsync(p => p.Id == prestamos.Id);
                if (prestamosDB != null)
                {
                    prestamosDB.UsuarioId = prestamos.UsuarioId;
                    bdContexto.Update(prestamosDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<int> DeleteAsync(Prestamos prestamos)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var prestamosDB = await bdContexto.Prestamos.FirstOrDefaultAsync(p => p.Id == prestamos.Id);
                if(prestamosDB != null)
                {
                    bdContexto.Prestamos.Remove(prestamosDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<Prestamos> GetByIdAsync(Prestamos prestamos)
        {
            var prestamosDB = new Prestamos();
            using(var bdContexto = new ContextoBD())
            {
                prestamosDB = await bdContexto.Prestamos.FirstOrDefaultAsync(p => p.Id == prestamos.Id);
            }
            return prestamosDB;
        }
        public static async Task<List<Prestamos>> GetAllAsync()
        {
            var prestamoes = new List<Prestamos>();
            using (var bdContexto = new ContextoBD())
            {
                prestamoes = await bdContexto.Prestamos.ToListAsync();
            }
            return prestamoes;
        }
        internal static IQueryable<Prestamos> QuerySelect(IQueryable<Prestamos> query, Prestamos prestamos)
        {
            if (prestamos.UsuarioId > 0)
            {
                query = query.Where(p => p.UsuarioId == prestamos.UsuarioId);
            }
            if (prestamos.UsuarioId > 0)
            {
                query = query.Where(p => p.UsuarioId == p.UsuarioId);
            }
            query = query.OrderByDescending(p => p.Id);
            if (prestamos.Top_Aux > 0)
            {
                query = query.Take(prestamos.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<List<Prestamos>> SearchAsync(Prestamos prestamos)
        {
            var prestamoes = new List<Prestamos>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Prestamos.AsQueryable();
                select = QuerySelect(select, prestamos);
                prestamoes = await select.ToListAsync();
            }
            return prestamoes;
        }
    }
}
