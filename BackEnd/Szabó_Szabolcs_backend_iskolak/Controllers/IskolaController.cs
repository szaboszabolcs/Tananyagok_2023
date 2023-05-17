using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Szabó_Szabolcs_backend_iskolak.Models;

namespace Szabó_Szabolcs_backend_iskolak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IskolaController : ControllerBase
    {
        [HttpGet("GetIskolak")]

        public IActionResult GetIskolak()
        {
            using (var context = new iskolaContext())
            {
                try
                {                    
                    return StatusCode(200, context.Iskolaks.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        
        }

        [HttpGet("IskolakSzama")]

        public IActionResult IskolakSzama()
        {
            using (var context = new iskolaContext())
            {
                try
                {
                    return StatusCode(200, $"Az iskolák száma: {context.Iskolaks.Count()}");
                }
                catch(Exception ex)
                {
                    return StatusCode(404, "Nincs megjeleníthető adat!");
                }
            }
        }
    }
}
