using AgmApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgmApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuntesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping() {

            var result = new PingPong() { 
                Code = Guid.NewGuid().ToString(),
                Date = DateTime.Now
        };

            return Ok(result);
        }

        //*ENTITY FRAMEWORK --> INFRAESTRUCTURE EFC.SQL EFC.TOOLS ......... API -> EFC.DESIGNS// 
        //DB scaffold-DBContext "Server=(localdb)\MSSQLLocalDB;DataBase=AgmApp;Integrated Security= true" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Data -Force

    }
}
