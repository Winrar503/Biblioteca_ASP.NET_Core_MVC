using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class CalificacionesBL
    {
        public async Task<int> CreateAsync(Calificaciones calificaciones)
        {
            return await CalificacionesDAL.CreateAsync(calificaciones);
        }

        public async Task<int> UpdateAsync(Calificaciones calificaciones)
        {
            return await CalificacionesDAL.UpdateAsync(calificaciones);
        }

        public async Task<int> DeleteAsync(Calificaciones calificaciones) => await CalificacionesDAL.DeleteAsync(calificaciones: calificaciones);

        public static async Task<Calificaciones> GetByIdAsync(Calificaciones calificaciones)
        {
            return await CalificacionesDAL.GetByIdAsync(calificaciones);
        }

        public async Task<List<Calificaciones>> GetAllAsync()
        {
            return await CalificacionesDAL.GetAllAsync();
        }

        public async Task<List<Calificaciones>> SearchAsync(Calificaciones calificaciones)
        {
            return await CalificacionesDAL.SearchAsync(calificaciones);
        }
    }
}

    
