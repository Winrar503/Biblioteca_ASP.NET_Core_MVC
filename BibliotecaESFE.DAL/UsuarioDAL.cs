using BibliotecaESFE.EN;
using Firebase.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class UsuarioDAL
    {
        private static void EncryptMD5(Usuarios usuarios)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(usuarios.Password));
                var encryptedStr = "";
                for (int i = 0; i < result.Length; i++)
                {
                    encryptedStr += result[i].ToString("x2").ToLower();
                }
                usuarios.Password = encryptedStr;
            }
        }

        private static async Task<bool> ExistsLogin(Usuarios usuarios, ContextoBD context)
        {
            bool result = false;
            var userLoginExists = await context.Usuarios.FirstOrDefaultAsync(u => u.Login == usuarios.Login && u.Id != usuarios.Id);
            if (userLoginExists != null && userLoginExists.Id > 0 && userLoginExists.Login == usuarios.Login)
                result = true;

            return result;
        }

        public static async Task<int> CreateAsync(Usuarios usuarios)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                bool existsLogin = await ExistsLogin(usuarios, dbContext);
                if (existsLogin == false)
                {
                    usuarios.RegistrationDate = DateTime.Now;
                    EncryptMD5(usuarios);
                    dbContext.Usuarios.Add(usuarios);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("El nombre de usuario ya existe");
            }
            return result;
        }

        public static async Task<int> UpdateAsync(Usuarios usuarios)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                bool existsLogin = await ExistsLogin(usuarios, dbContext);
                if (existsLogin == false)
                {
                    var userDb = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarios.Id);
                    userDb.IdRole = usuarios.IdRole;
                    userDb.Name = usuarios.Name;
                    userDb.LastName = usuarios.LastName;
                    userDb.Status = usuarios.Status;
                    userDb.Login = usuarios.Login;

                    dbContext.Usuarios.Update(userDb);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("El nombre de usuario ya existe");
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Usuarios usuarios)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var usuariosDb = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarios.Id);
                dbContext.Usuarios.Remove(usuariosDb);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Usuarios> GetByIdAsync(Usuarios usuarios)
        {
            var usuarioDb = new Usuarios();
            using (var dbContext = new ContextoBD())
            {
                usuarioDb = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarios.Id);
            }
            return usuarioDb!;
        }

        public static async Task<List<Usuarios>> GetAllAsync()
        {
            var usuario = new List<Usuarios>();
            using (var dbContext = new ContextoBD())
            {
                usuario = await dbContext.Usuarios.ToListAsync();
            }
            return usuario;
        }

        internal static IQueryable<Usuarios> QuerySelect(IQueryable<Usuarios> query, Usuarios usuarios)
        {
            if (usuarios.Id > 0)
                query = query.Where(u => u.Id == usuarios.Id);

            if (usuarios.IdRole > 0)
                query = query.Where(u => u.IdRole == usuarios.IdRole);

            if (!string.IsNullOrWhiteSpace(usuarios.Name))
                query = query.Where(u => u.Name.Contains(usuarios.Name));

            if (!string.IsNullOrWhiteSpace(usuarios.LastName))
                query = query.Where(u => u.LastName.Contains(usuarios.LastName));

            if (!string.IsNullOrWhiteSpace(usuarios.Login))
                query = query.Where(u => u.Login.Contains(usuarios.Login));

            if (usuarios.Status > 0)
                query = query.Where(u => u.Status == usuarios.Status);

            if (usuarios.RegistrationDate.Year > 1000)
            {
                DateTime inicialDate = new DateTime(usuarios.RegistrationDate.Year, usuarios.RegistrationDate.Month, usuarios.RegistrationDate.Day, 0, 0, 0);
                DateTime finalDate = inicialDate.AddDays(1).AddMilliseconds(-1);
                query = query.Where(u => u.RegistrationDate >= inicialDate && u.RegistrationDate <= finalDate);
            }

            query = query.OrderByDescending(u => u.Id).AsQueryable();

            if (usuarios.Top_Aux > 0)
                query = query.Take(usuarios.Top_Aux).AsQueryable();

            return query;
        }

        public static async Task<List<Usuarios>> SearchAsync(Usuarios usuarios)
        {
            var usuario = new List<Usuarios>();
            using (var dbContext = new ContextoBD())
            {
                var select = dbContext.Usuarios.AsQueryable();
                select = QuerySelect(select, usuarios);
                usuario = await select.ToListAsync();
            }
            return usuario;
        }

        public static async Task<List<Usuarios>> SearchIncludeRoleAsync(Usuarios usuarios)
        {
            var usuario = new List<Usuarios>();
            using (var dbContext = new ContextoBD())
            {
                var select = dbContext.Usuarios.AsQueryable();
                select = QuerySelect(select, usuarios).Include(u => u.Role).AsQueryable();
                usuario = await select.ToListAsync();
            }
            return usuario;
        }

        public static async Task<Usuarios> LoginAsync(Usuarios usuario)
        {
            var  usuariosDb = new Usuarios();
            using (var dbContext = new ContextoBD())
            {
                EncryptMD5(usuario);
              usuariosDb = await dbContext.Usuarios.FirstOrDefaultAsync(
                    u => u.Login == usuario.Login && u.Password == usuario.Password && u.Status == (byte)User_Status.ACTIVO);
            }
            return  usuariosDb!;
        }

        public static async Task<int> ChangePasswordAsync(Usuarios usuarios, string oldPassword)
        {
            int result = 0;
            var userOldPass = new Usuarios { Password = oldPassword };
            EncryptMD5(userOldPass);
            using (var dbContext = new ContextoBD())
            {
                var usuarioDb = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarios.Id);
                if (userOldPass.Password == usuarioDb.Password)
                {
                    EncryptMD5(usuarios);
                    usuarioDb.Password = usuarios.Password;
                    dbContext.Usuarios.Update(usuarioDb);
                    result = await dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("La contraseña actual es inválida");
            }
            return result;
        }
    }
}
