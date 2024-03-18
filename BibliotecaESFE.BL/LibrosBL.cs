using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class LibrosBL
    {
        public async Task<int> CreateAsync(Libros libros)
        {
            return await LibrosDAL.CreateAsync(libros);
        }
        public async Task<int> UpdateAsync(Libros libros)
        {
            return await LibrosDAL.UpdateAsync(libros);
        }
        public async Task<int> DeleteAsync(Libros libros)
        {
            return await LibrosDAL.DeleteAsync(libros);
        }
        public async Task<Libros> GetByIdAsync(Libros libros)
        {
            return await LibrosDAL.GetByIdAsync(libros);
        }

        public async Task<List<Libros>> GetAllAsync()
        {
            return await LibrosDAL.GetAllAsync();
        }

        public async Task<List<Libros>> SearchAsync(Libros libros)
        {
            return await LibrosDAL.SearchAsync(libros);
        }
        public async Task<List<Libros>> SearchIncludeLibrosAsync(Libros libros)
        {
            return await LibrosDAL.SearchIncludeCludeLibrosAsync(libros);
        }
    }
}
