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
        public static async Task<int> CreateAsync(CalificacionesResenias calificaciones)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Calificaciones_Reseñas.Add(calificaciones);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(CalificacionesResenias calificaciones)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var calificacionesDB = await bdContexto.Calificaciones_Reseñas.FirstOrDefaultAsync(c => c.Id == calificaciones.Id);
                if (calificacionesDB != null)
                {
                    calificacionesDB.UsuarioId = calificaciones.UsuarioId;
                    bdContexto.Update(calificacionesDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<int> DeleteAsync(CalificacionesResenias calificaciones)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var calificacionesDB = await bdContexto.Calificaciones_Reseñas.FirstOrDefaultAsync(c => c.Id == calificaciones.Id);

                if (calificacionesDB != null)
                {
                    bdContexto.Calificaciones_Reseñas.Remove(calificacionesDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

        }
        public static async Task<CalificacionesResenias> GetByIdAsync(CalificacionesResenias calificaciones) 
        {
            var calificacionesDB = new CalificacionesResenias();
            using (var bdContexto = new ContextoBD())
            {
                calificacionesDB = await bdContexto.Calificaciones_Reseñas.FirstOrDefaultAsync(c => c.Id == calificaciones.Id);
            }
            return calificacionesDB;
        }
        public static async Task<List<CalificacionesResenias>> GetAllAsync()
        {
            var calificacione = new List<CalificacionesResenias>();
            using (var bdContexto = new ContextoBD())
            {
                calificacione = await bdContexto.Calificaciones_Reseñas.ToListAsync();
            }
            return calificacione;
        }
        internal static IQueryable<CalificacionesResenias> QuerySelect(IQueryable<CalificacionesResenias> query, CalificacionesResenias calificaciones)
        {
            if (calificaciones.UsuarioId > 0)
            {
                query = query.Where(c => c.UsuarioId == calificaciones.UsuarioId);
            }
            if (calificaciones.UsuarioId > 0)
            {
                query = query.Where(c => c.UsuarioId == calificaciones.UsuarioId);
            }
            query = query.OrderByDescending(c => c.UsuarioId);
            if (calificaciones.Top_Aux > 0)
            {
                query = query.Take(calificaciones.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<List<CalificacionesResenias>> SearchAsync(CalificacionesResenias calificaciones)
        {
            var calificacione = new List<CalificacionesResenias>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Calificaciones_Reseñas.AsQueryable();
                select = QuerySelect(select, calificaciones);
                calificacione = await select.ToListAsync();
            }
            return calificacione;
        }
    }
}

    
