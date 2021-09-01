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

        public async Task<User> GetUserByCredentials() {

            return  await _context.Users.Where(x => x.Id == 1).Select(x=> new User() { 
                AccesId= "e29dae7e-cfbf-4ac8-afa3-545e4808ae20",
                Names= x.UsrNombres,
                Photo= "photo.png",
                Username = x.UsrUsername
            }).FirstOrDefaultAsync();          

             
        }

        public async Task<int> CreateUser(User data)
        {
            var entity = new Users()
            {
                Id = 2,
                UsrIdPk = "2",
                UsrNombres = "segundo",
                UsrPassword = "asdasd",
                UsrUsername = "mBox",
            };

            var result =  await  _context.Users.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

    }
}
