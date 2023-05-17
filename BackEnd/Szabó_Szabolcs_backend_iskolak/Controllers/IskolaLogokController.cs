using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Szabó_Szabolcs_backend_iskolak.Models;

namespace Szabó_Szabolcs_backend_iskolak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IskolaLogokController : ControllerBase
    {
        [HttpDelete]

        public IActionResult DeleteIskolaLogo(int id)
        {
            using (var context = new iskolaContext())
            {
                try
                {
                    Iskolalogok iskolalogok = new Iskolalogok();
                    iskolalogok.Id = id;
                    context.Remove(iskolalogok);
                    context.SaveChanges();
                    return StatusCode(402, "Az iskola adatainak törlése sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Az iskola adatait nem sikerült törölni:{ex.Message}");
                }
            }
        }
    }
}
