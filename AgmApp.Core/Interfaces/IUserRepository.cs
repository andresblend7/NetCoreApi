using AgmApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgmApp.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByCredentials();

        /// <summary>
        /// ESTE ERRROR DE USERS NO DEBE ESTAR EN CORE, DEBE ESTAR EN INFRAESTRUCTURE Y ENVIARSE UN MODELO DTO
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<int> CreateUser(User data);
    }
}
