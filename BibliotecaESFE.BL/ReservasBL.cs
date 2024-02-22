using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class ReservasBL
    {
        public async Task<int> CreateAsync(Reservas reservas)
        {
            return await ReservasDAL.CreateAsync(reservas);
        }
        public async Task<int> DeleteAsync(Reservas reservas)
        {
            return await ReservasDAL.DeleteAsync(reservas);
        }
        public async Task<Reservas> GetByIdAsync(Reservas reservas)
        {
            return await ReservasDAL.GetByIdAsync(reservas);
        }

        public async Task<List<Reservas>> GetAllAsync()
        {
            return await ReservasDAL.GetAllAsync();
        }
    }
}
