using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Szabó_Szabolcs_backend_iskolak.Models;

namespace Szabó_Szabolcs_backend_iskolak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiakokController : ControllerBase
    {
        [HttpPost] 

        public IActionResult DiakHozzaadas(Diakok diakok)
        {
            using (var context = new iskolaContext())
            {
                try
                {
                    context.Diakoks.Add(diakok);
                    context.SaveChanges();
                    return StatusCode(200, "A diák hozzáadása sikeresen megtörtént!");
                }
                catch (Exception ex)
                {
                    return StatusCode(404, "Diák hozzáadása sikertelen/hiányos adatok!");
                }
            }
        }
    }
}
