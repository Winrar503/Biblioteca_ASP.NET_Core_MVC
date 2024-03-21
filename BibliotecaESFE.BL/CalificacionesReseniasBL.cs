using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class CalificacionesReseniasBL
    {
        public async Task<int> CreateAsync(CalificacionesResenias calificacionesResenias)
        {
            return await CalificacionesReseniasDAL.CreateAsync(calificacionesResenias);
        }

        //public async Task<int> UpdateAsync(CalificacionesResenias calificaciones)
        //{
        //    return await CalificacionesReseniasDAL.UpdateAsync(calificaciones);
        //}

        //public async Task<int> DeleteAsync(CalificacionesResenias calificacionesResenias) => await CalificacionesReseniasDAL.DeleteAsync(calificacionesResenias: calificaciones);

        //public static async Task<CalificacionesResenias> GetByIdAsync(CalificacionesResenias calificaciones)
        //{
        //    return await CalificacionesReseniasDAL.GetByIdAsync(calificaciones);
        //}

        public async Task<List<CalificacionesResenias>> GetAllAsync()
        {
            return await CalificacionesReseniasDAL.GetAllAsync();
        }

        //public async Task<List<CalificacionesResenias>> SearchAsync(CalificacionesResenias calificaciones)
        //{
        //    return await CalificacionesReseniasDAL.SearchAsync(calificaciones);
        //}
    }
}

    
