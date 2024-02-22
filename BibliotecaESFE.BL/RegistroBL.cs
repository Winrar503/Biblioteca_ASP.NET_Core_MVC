using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class RegistroBL
    {
        public async Task<int> CreateAsync(Registro registro)
        {
            return await RegistroDAL.CreateAsync(registro);
        }

        public async Task<int> UpdateAsync(Registro registro)
        {
            return await RegistroDAL.UpdateAsync(registro);
        }

        public async Task<int> DeleteAsync(Registro registro)
        {
            return await RegistroDAL.DeleteAsync(registro);
        }

        public static  async Task<Registro> GetByIdAsync(Registro registro)
        {
            return await RegistroDAL.GetByIdAsync(registro);
        }

        public async Task<List<Registro>> GetAllAsync()
        {
            return await RegistroDAL.GetAllAsync();
        }

        public async Task<List<Registro>> SearchAsync(Registro registro)
        {
            return await RegistroDAL.SearchAsync(registro);
        }
    }
}

