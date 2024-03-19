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

        public static async Task<int> UpdateAsync(Reservas reservas)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var reservasDB = await dbContext.Reservas.FirstOrDefaultAsync(r => r.Id == reservas.Id);
                if (reservasDB != null)
                {
                    reservasDB.UsuarioId = reservas.UsuarioId;
                    reservasDB.LibroId = reservas.LibroId;
                    reservasDB.FechaReserva = reservas.FechaReserva;
                    dbContext.Reservas.Update(reservasDB);
                    result = await dbContext.SaveChangesAsync();
                }
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


        internal static IQueryable<Reservas> QuerySelect(IQueryable<Reservas> query, Reservas reservas )
        {
            if (reservas.Id > 0)
            {
                query = query.Where(r => r.Id == reservas.Id);
            }
            if (reservas.UsuarioId > 0)
                query = query.Where(u => u.UsuarioId == reservas.UsuarioId);

            if (reservas .LibroId > 0)
                query = query.Where(e => e.LibroId == reservas.LibroId);




            if (reservas.FechaReserva != default(DateTime)) // Verifica que la FechaReserva no sea el valor por defecto cualquier cosa es un error
            {
                query = query.Where(f => f.FechaReserva == reservas.FechaReserva);
            }



            query = query.OrderByDescending(l => l.Id);
            if (reservas.Top_Aux > 0)
            {
                query = query.Take(reservas.Top_Aux).AsQueryable();
            }
            return query;
        }


        public static async Task<List<Reservas>> SearchAsync(Reservas reservas)
        {
            var reserva = new List<Reservas>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Reservas.AsQueryable();
                select = QuerySelect(select, reservas);
                reserva = await select.ToListAsync();
            }
            return reserva;
        }

        public static async Task<List<Reservas>> SearchIncludeCludeLibrosAsync(Reservas reservas)
        {
            var reserva = new List<Reservas>();
            using (var bdContxto = new ContextoBD())
            {
                var selec = bdContxto.Reservas.AsQueryable();
                selec = QuerySelect(selec, reservas).Include(u => u.Usuarios).Include(l => l.Libros).AsQueryable();
                reserva = await selec.ToListAsync();
            }
            return reserva;
        }
    }
}
