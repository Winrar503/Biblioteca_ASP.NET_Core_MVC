using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class CalificacionesDAL
    {
        public static async Task<int> CreateAsync(Calificaciones calificaciones)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Calificaciones_Reseñas.Add(calificaciones);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Calificaciones calificaciones)
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
        public static async Task<int> DeleteAsync(Calificaciones calificaciones)
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
        public static async Task<Calificaciones> GetByIdAsync(Calificaciones calificaciones) 
        {
            var calificacionesDB = new Calificaciones();
            using (var bdContexto = new ContextoBD())
            {
                calificacionesDB = await bdContexto.Calificaciones_Reseñas.FirstOrDefaultAsync(c => c.Id == calificaciones.Id);
            }
            return calificacionesDB;
        }
        public static async Task<List<Calificaciones>> GetAllAsync()
        {
            var calificacione = new List<Calificaciones>();
            using (var bdContexto = new ContextoBD())
            {
                calificacione = await bdContexto.Calificaciones_Reseñas.ToListAsync();
            }
            return calificacione;
        }
        internal static IQueryable<Calificaciones> QuerySelect(IQueryable<Calificaciones> query, Calificaciones calificaciones)
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
        public static async Task<List<Calificaciones>> SearchAsync(Calificaciones calificaciones)
        {
            var calificacione = new List<Calificaciones>();
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

    
