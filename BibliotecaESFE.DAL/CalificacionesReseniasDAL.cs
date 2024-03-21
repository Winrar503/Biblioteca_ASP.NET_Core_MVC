using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class CalificacionesReseniasDAL
    {
        public static async Task<int> CreateAsync(CalificacionesResenias calificacionesResenias)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.CalificacionesResenias.Add(calificacionesResenias);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        //public static async Task<int> UpdateAsync(CalificacionesResenias calificacionesResenias)
        //{
        //    int result = 0;
        //    using (var bdContexto = new ContextoBD())
        //    {
        //        var calificacionesDB = await bdContexto.CalificacionesResenias.FirstOrDefaultAsync(c => c.Id == calificaciones.Id);
        //        if (calificacionesDB != null)
        //        {
        //            calificacionesDB.UsuarioId = calificacionesResenias.UsuarioId;
        //            bdContexto.Update(calificacionesDB);
        //            result = await bdContexto.SaveChangesAsync();
        //        }
        //        return result;
        //    }
        //}
        //public static async Task<int> DeleteAsync(CalificacionesResenias calificacionesResenias)
        //{
        //    int result = 0;
        //    using (var bdContexto = new ContextoBD())
        //    {
        //        var calificacionesDB = await bdContexto.CalificacionesResenias.FirstOrDefaultAsync(c => c.Id == calificacionesResenias.Id);

        //        if (calificacionesDB != null)
        //        {
        //            bdContexto.CalificacionesResenias.Remove(calificacionesDB);
        //            result = await bdContexto.SaveChangesAsync();
        //        }
        //        return result;
        //    }

        //}
        //public static async Task<CalificacionesResenias> GetByIdAsync(CalificacionesResenias calificacionesResenias) 
        //{
        //    var calificacionesDB = new CalificacionesResenias();
        //    using (var bdContexto = new ContextoBD())
        //    {
        //        calificacionesDB = await bdContexto.CalificacionesResenias.FirstOrDefaultAsync(c => c.Id == calificacionesResenias.Id);
        //    }
        //    return calificacionesDB;
        //}
        public static async Task<List<CalificacionesResenias>> GetAllAsync()
        {
            var calificacione = new List<CalificacionesResenias>();
            using (var bdContexto = new ContextoBD())
            {
                calificacione = await bdContexto.CalificacionesResenias.ToListAsync();
            }
            return calificacione;
        }
        //internal static IQueryable<CalificacionesResenias> QuerySelect(IQueryable<CalificacionesResenias> query, CalificacionesResenias calificacionesResenias)
        //{
        //    if (calificacionesResenias.UsuarioId > 0)
        //    {
        //        query = query.Where(c => c.UsuarioId == calificacionesResenias.UsuarioId);
        //    }
        //    if (calificacionesResenias.UsuarioId > 0)
        //    {
        //        query = query.Where(c => c.UsuarioId == calificacionesResenias.UsuarioId);
        //    }
        //    query = query.OrderByDescending(c => c.UsuarioId);
        //    if (calificacionesResenias.Top_Aux > 0)
        //    {
        //        query = query.Take(calificacionesResenias.Top_Aux).AsQueryable();
        //    }
        //    return query;
        //}
        //public static async Task<List<CalificacionesResenias>> SearchAsync(CalificacionesResenias calificacionesResenias)
        //{
        //    var calificacione = new List<CalificacionesResenias>();
        //    using (var bdContexto = new ContextoBD())
        //    {
        //        var select = bdContexto.CalificacionesResenias.AsQueryable();
        //        select = QuerySelect(select, calificacionesResenias);
        //        calificacione = await select.ToListAsync();
        //    }
        //    return calificacione;
        //}
    }
}

    
