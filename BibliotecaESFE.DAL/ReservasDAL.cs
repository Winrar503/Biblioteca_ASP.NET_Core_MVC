using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class ReservasDAL
    {
        public static async Task<int> CreateAsync(Reservas reservas)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Reservas.Add(reservas);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Reservas reservas)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var reservasDB = bdContexto.Reservas.FirstOrDefault(a => a.Id == reservas.Id);
                if (reservasDB != null)
                {
                    bdContexto.Reservas.Remove(reservasDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<Reservas> GetByIdAsync(Reservas reservas)
        {
            var reservasDB = new Reservas();
            using (var bdContexto = new ContextoBD())
            {
                reservasDB = await bdContexto.Reservas.FirstOrDefaultAsync(a => a.Id == reservas.Id);
            }
            return reservasDB;
        }
        public static async Task<List<Reservas>> GetAllAsync()
        {
            var reservas = new List<Reservas>();
            using (var bdContexto = new ContextoBD())
            {
                reservas = await bdContexto.Reservas.ToListAsync();
            }
            return reservas;
        }
    }
}
