using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class PrestamosBL
    {
        public async Task<int> CreateAsync(Prestamos prestamos)
        {
            return await PrestamosDAL.CreateAsync(prestamos);
        }
        public async Task<int> UpdateAsync(Prestamos prestamos)
        {
            return await PrestamosDAL.UpdateAsync(prestamos);
        }
        public async Task<int> DeleteAsync(Prestamos prestamos)
        {
            return await PrestamosDAL.DeleteAsync(prestamos);
        }
        public async Task<Prestamos> GetByIdAsync(Prestamos prestamos)
        {
            return await PrestamosDAL.GetByIdAsync(prestamos);
        }

        public async Task<List<Prestamos>> GetAllAsync()
        {
            return await PrestamosDAL.GetAllAsync();
        }

        public async Task<List<Prestamos>> SearchAsync(Prestamos prestamos)
        {
            return await PrestamosDAL.SearchAsync(prestamos);
        }
    }
}
