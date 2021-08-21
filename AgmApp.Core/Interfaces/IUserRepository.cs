using AgmApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgmApp.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> GetUserByCredentials();
        Task<int> CreateUser(Users data);
    }
}
