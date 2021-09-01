using AgmApp.API.Responses;
using AgmApp.Core;
using AgmApp.Core.Entities;
using AgmApp.Core.Handlers.Logic;
using AgmApp.Core.Interfaces;
using AgmApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgmApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserRepository _userRepository;
        IAuthHandler _autHandler;
        public AuthController(IUserRepository userRep, IAuthHandler auth)
        {
            this._userRepository = userRep;
            this._autHandler = auth;
        }


        [HttpPost("AuthUser")]
        public async Task<IActionResult> AuthUser(UserLogin data) {

            if (data.UserName == "andres" && data.Password == "321")
            {


                var user = await this._userRepository.GetUserByCredentials();
                
                var token = this._autHandler.GenerateJWT(user);

                return Ok(new { user, token });

            }
            else {

                return Ok(null);
            
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(User data)
        {
            var user = await this._userRepository.CreateUser(data);
            var response = new ApiResponse<int>(user);        

            return Ok(response);
        }
    }
}
