using AgmApp.Core.Entities;
using AgmApp.Core.Interfaces;
using AgmApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgmApp.Infrastructure.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {

        private readonly AgmAppContext _context;

        public UserRolesRepository(AgmAppContext context)
        {
            this._context = context;
        }



        public async Task<List<UserRol>> GetAll()
        {
            return await _context.RolesUsuario.Select(x => new UserRol()
            {
                Rol = new Rol { 
                    Nombre = x.IdRolFkNavigation.RolName,
                    RowId = x.IdRolFkNavigation.RolRowId
                },
                Usuario = new User { 
                    Names= x.IdUsuarioFkNavigation.UsrNombres
                }
            }).ToListAsync();
        }
    }
}
