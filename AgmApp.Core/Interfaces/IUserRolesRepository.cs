using AgmApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgmApp.Core.Interfaces
{
    public interface IUserRolesRepository
    {
        Task<List<UserRol>> GetAll();
    }
}
