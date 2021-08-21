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
    public class UserRepository : IUserRepository
    {

        private readonly AgmAppContext _context;

        public UserRepository(AgmAppContext context)
        {
            this._context = context;
        }

        public async Task<Users> GetUserByCredentials() {

            return await _context.Users.Where(x => x.Id == 1).FirstOrDefaultAsync();          
        }

        public async Task<int> CreateUser(Users data)
        {
            var entity = new Users()
            {
                Id = 2,
                UsrIdPk = "2",
                UsrNombres = "segundo",
                UsrPassword = "asdasd",
                UsrUsername = "mBox"
            };

            var result =  await  _context.Users.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

    }
}
