using AgmApp.Core.Handlers.Logic;
using AgmApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgmApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IUserRolesRepository usrRolRepository;
        public AdminController(IUserRolesRepository usrRep)
        {
            this.usrRolRepository = usrRep;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {

            var result = await this.usrRolRepository.GetAll();

            return Ok(result);
        }
    }
}
