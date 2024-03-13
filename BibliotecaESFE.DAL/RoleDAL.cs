using BibliotecaESFE.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaESFE.DAL
{
    public class RoleDAL
    {
        public static async Task<int> CreateAsync(Role role)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                dbContext.Role.Add(role);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> UpdateAsync(Role role)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var roleDb = await dbContext.Role.FirstOrDefaultAsync(r => r.Id == role.Id);
                if (roleDb != null)
                {
                    roleDb.Name = role.Name;
                    dbContext.Role.Update(roleDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<int> DeleteAsync(Role role)
        {
            int result = 0;
            using (var dbContext = new ContextoBD())
            {
                var roleDb = await dbContext.Role.FirstOrDefaultAsync(r => r.Id == role.Id);
                if (roleDb != null)
                {
                    dbContext.Role.Remove(roleDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }

        public static async Task<Role> GetByIdAsync(Role role)
        {
            var roleDb = new Role();
            using (var dbContext = new ContextoBD())
            {
                roleDb = await dbContext.Role.FirstOrDefaultAsync(r => r.Id == role.Id);
            }
            return roleDb!;
        }

        public static async Task<List<Role>> GetAllAsync()
        {
            var roles = new List<Role>();
            using (var dbContext = new ContextoBD())
            {
                roles = await dbContext.Role.ToListAsync();
            }
            return roles;
        }

        internal static IQueryable<Role> QuerySelect(IQueryable<Role> query, Role role)
        {
            if (role.Id > 0)
                query = query.Where(r => r.Id == role.Id);

            if (!string.IsNullOrWhiteSpace(role.Name))
                query = query.Where(r => r.Name.Contains(role.Name));

            query = query.OrderByDescending(r => r.Id);

            if (role.Top_Aux > 0)
                query = query.Take(role.Top_Aux).AsQueryable();

            return query;
        }

        public static async Task<List<Role>> SearchAsync(Role role)
        {
            var roles = new List<Role>();
            using (var dbContext = new ContextoBD())
            {
                var select = dbContext.Role.AsQueryable();
                select = QuerySelect(select, role);
                roles = await select.ToListAsync();
            }
            return roles;
        }
    }
}
