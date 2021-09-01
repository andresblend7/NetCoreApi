using AgmApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgmApp.Core.Handlers.Logic
{
    public interface IAuthHandler
    {
        string GenerateJWT(User user);
    }
}
