using Euroskills.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Euroskills.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EuSkillController : ControllerBase
    {
        [HttpGet("getVersenyzoK")]

        public IActionResult getVersenyzoK()
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    return StatusCode(200, context.Versenyzos.ToList());
                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }                
            }
        }

        [HttpGet("getVersenyzo/{id}")]

        public IActionResult getVersnyzoId(int id)
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    return StatusCode(200, context.Versenyzos.Where(x => x.Id == id).ToList());
                }
                catch(Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }

        [HttpGet("osszesOrszagSzama")]

        public IActionResult getOsszesOrszagSzama()
        {
            using (var context = new euroskillsContext())
            {
                try
                {
                    return StatusCode(200, $"Összes ország száma: {context.Orszags.Count()}");

                }
                catch (Exception ex)
                {
                    return StatusCode(400, ex.Message);
                }
            }
        }

        [HttpPost("addVersenyzo")]

        public IActionResult addVersenyzo(string UserID, Versenyzo versenyzo)
        {
            using (var context = new euroskillsContext())
            {
                if (UserID == Program.UserID)
                {
                    context.Versenyzos.Add(versenyzo);
                    context.SaveChanges();
                    return StatusCode(201, "Versenyző hozzáadása sikeresen megtörtént.");
                }
                else
                {
                    return StatusCode(404, "Helytelen azonosító!");
                }
            }
        }
    }
}