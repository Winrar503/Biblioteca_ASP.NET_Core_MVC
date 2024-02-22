using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class EditorialesBL
    {
        public async Task<int> CreateAsync(Editoriales editoriales)
        {
            return await EditorialesDAL.CreateAsync(editoriales);
        }
        public async Task<int> UpdateAsync(Editoriales editoriales)
        {
            return await EditorialesDAL.UpdateAsync(editoriales);
        }
        public async Task<int> DeleteAsync(Editoriales editoriales)
        {
            return await EditorialesDAL.DeleteAsync(editoriales);
        }
        public async Task<Editoriales> GetByIdAsync(Editoriales editoriales)
        {
            return await EditorialesDAL.GetByIdAsync(editoriales);
        }

        public async Task<List<Editoriales>> GetAllAsync()
        {
            return await EditorialesDAL.GetAllAsync();
        }

        public async Task<List<Editoriales>> SearchAsync(Editoriales editoriales)
        {
            return await EditorialesDAL.SearchAsync(editoriales);
        }
    }
}
