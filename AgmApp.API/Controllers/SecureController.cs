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
    public class SecureController : ControllerBase
    {

        [HttpGet]
        public IActionResult Data()
        {

            var result = new { 
                Fecha = DateTime.Now,
                ClaveSecreta =  "Esto es algo que solo ves logueado"
            };

            return Ok(result);
        }


    }
}
