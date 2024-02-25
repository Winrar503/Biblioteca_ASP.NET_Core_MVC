using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class CategoriasBL
    {
        public async Task<int> CreateAsync(Categorias categorias)
        {
            return await CategoriasDAL.CreateAsync(categorias);
        }
        public async Task<int> DeleteAsync(Categorias categorias)
        {
            return await CategoriasDAL.DeleteAsync(categorias);
        }
        public async Task<Categorias> GetByIdAsync(Categorias categorias)
        {
            return await CategoriasDAL.GetByIdAsync(categorias);
        }

        public async Task<List<Categorias>> GetAllAsync()
        {
            return await CategoriasDAL.GetAllAsync();
        }

        public async Task<List<Categorias>> SearchAsync(Categorias categorias)
        {
            return await CategoriasDAL.SearchAsync(categorias);
        }
    }
}
