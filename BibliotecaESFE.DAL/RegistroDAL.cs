using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class RegistroDAL
    {
        public static async Task<int> CreateAsync(Registro registro)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                bdContexto.Registro_Sesiones_Usuario.Add(registro);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Registro registro)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var registroDB = await bdContexto.Registro_Sesiones_Usuario.FirstOrDefaultAsync(r => r.id == registro.id);
                if (registroDB != null)
                {
                    registroDB.Usuario_id = registro.Usuario_id;
                    bdContexto.Update(registroDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
        }
        public static async Task<int> DeleteAsync(Registro registro)
        {
            int result = 0;
            using (var bdContexto = new ContextoBD())
            {
                var registroDB = await bdContexto.Registro_Sesiones_Usuario.FirstOrDefaultAsync(r => r.Usuario_id == registro.Usuario_id);
                if (registroDB != null)
                {
                    bdContexto.Registro_Sesiones_Usuario.Remove(registroDB);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }

        }
        public static async Task<Registro> GetByIdAsync(Registro registro)
        {
            var registroDB = new Registro();
            using (var bdContexto = new ContextoBD())
            {
                registroDB = await bdContexto.Registro_Sesiones_Usuario.FirstOrDefaultAsync(r => r.Usuario_id == registro.Usuario_id);
            }
            return registroDB;
        }
        public static async Task<List<Registro>> GetAllAsync()
        {
            var registroe = new List<Registro>();
            using (var bdContexto = new ContextoBD())
            {
                registroe = await bdContexto.Registro_Sesiones_Usuario.ToListAsync();
            }
            return registroe;
        }
        internal static IQueryable<Registro> QuerySelect(IQueryable<Registro> query, Registro registro)
        {
            if (registro.Usuario_id > 0)
            {
                query = query.Where(r => r.Usuario_id == registro.Usuario_id);
            }
            if (registro.Usuario_id > 0)
            {
                query = query.Where(r => r.Usuario_id == registro.Usuario_id);
            }
            query = query.OrderByDescending(r => r.Usuario_id);
            if (registro.Top_Aux > 0)
            {
                query = query.Take(registro.Top_Aux).AsQueryable();
            }
            return query;
        }
        public static async Task<List<Registro>> SearchAsync(Registro registro)
        {
            var registroes = new List<Registro>();
            using (var bdContexto = new ContextoBD())
            {
                var select = bdContexto.Registro_Sesiones_Usuario.AsQueryable();
                select = QuerySelect(select, registro);
                registroes = await select.ToListAsync();
            }
            return registroes;
        }
    }
}

    