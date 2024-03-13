using BibliotecaESFE.DAL;
using BibliotecaESFE.EN;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.BL
{
    public class UsuarioBL
    {
        public async Task<int> CreateAsync(Usuarios usuarios)
        {
            return await UsuarioDAL.CreateAsync(usuarios);
        }

        public async Task<int> UpdateAsync(Usuarios usuarios)
        {
            return await UsuarioDAL.UpdateAsync( usuarios);
        }

        public async Task<int> DeleteAsync(Usuarios usuarios)
        {
            return await UsuarioDAL.DeleteAsync(usuarios);
        }

        public async Task<Usuarios> GetByIdAsync(Usuarios usuarios)
        {
            return await UsuarioDAL.GetByIdAsync(usuarios);
        }

        public async Task<List<Usuarios>> GetAllAsync()
        {
            return await UsuarioDAL.GetAllAsync();
        }

        public async Task<List<Usuarios>> SearchAsync(Usuarios usuarios)
        {
            return await UsuarioDAL.SearchAsync(usuarios);
        }

        public async Task<List<Usuarios>> SearchIncludeRoleAsync(Usuarios usuarios)
        {
            return await UsuarioDAL.SearchIncludeRoleAsync(usuarios);
        }

        public async Task<Usuarios> LoginAsync(Usuarios usuarios)
        {
            return await UsuarioDAL.LoginAsync(usuarios);
        }

        public async Task<int> ChangePasswordAsync(Usuarios usuarios, string oldPassword)
        {
            return await UsuarioDAL.ChangePasswordAsync(usuarios, oldPassword);
        }
    }
}
