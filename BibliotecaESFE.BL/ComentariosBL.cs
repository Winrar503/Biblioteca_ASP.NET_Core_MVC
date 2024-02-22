using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class ComentariosBL
    {
        public async Task<int> CreateAsync(Comentarios comentarios)
        {
            return await ComentariosDAL.CreateAsync(comentarios);
        }
        public async Task<int> DeleteAsync(Comentarios comentarios)
        {
            return await ComentariosDAL.DeleteAsync(comentarios);
        }
        public async Task<Comentarios> GetByIdAsync(Comentarios comentarios)
        {
            return await ComentariosDAL.GetByIdAsync(comentarios);
        }

        public async Task<List<Comentarios>> GetAllAsync()
        {
            return await ComentariosDAL.GetAllAsync();
        }

    }
}
