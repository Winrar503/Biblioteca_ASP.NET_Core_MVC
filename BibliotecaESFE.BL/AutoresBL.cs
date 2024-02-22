using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class AutoresBL
    {
        public async Task<int> CreateAsync(Autores autores)
        {
            return await AutoresDAL.CreateAsync(autores);
        }
        public async Task<int> UpdateAsync(Autores autores)
        {
            return await AutoresDAL.UpdateAsync(autores);
        }
        public async Task<int> DeleteAsync(Autores autores)
        {
            return await AutoresDAL.DeleteAsync(autores);
        }

        public async Task<Autores> GetByIdAsync(Autores autores)
        {
            return await AutoresDAL.GetByIdAsync(autores);
        }

        public async Task<List<Autores>> GetAllAsync()
        {
            return await AutoresDAL.GetAllAsync();
        }

        public async Task<List<Autores>> SearchAsync(Autores autores)
        {
            return await AutoresDAL.SearchAsync(autores);
        }
    }
}

