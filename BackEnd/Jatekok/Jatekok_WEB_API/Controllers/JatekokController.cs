using Jatekok_WEB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Jatekok_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JatekokController : ControllerBase
    {

        [HttpGet]

        public IActionResult GetJatekok()
        {
            using (var context = new jatekokContext())
            {
                try
                {
                    return Ok(context.Jateks.ToList());

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("JatekokSzama")]

        public IActionResult GetJatekokSzama()
        {
            using (var context = new jatekokContext())
            {
                try
                {
                    return Ok($"Az adatbázisban szereplő játékok száma: {context.Jateks.Count()}");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpPost]

        public IActionResult PostJatek(Jatek jatek)
        {
            using (var context = new jatekokContext())
            {
                try
                {
                    context.Jateks.Add(jatek);
                    context.SaveChanges();
                    return StatusCode(401, "Az új játék sikeresen hozzáadva.");
                }
                catch (Exception ex)
                {
                    return StatusCode(502, $"Valami hiba van:{ex.Message}");
                }
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetJatek(int id)
        {
            using (var context = new jatekokContext())
            {
                try
                {
                    return Ok(context.Jateks.Where(x => x.Id == id).ToList());
                }
                catch (Exception ex)
                {
                    return StatusCode(502, ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            using (var context = new jatekokContext())
            {
                try
                {
                    Jatek jatek = new Jatek();
                    jatek.Id = id;
                    context.Jateks.Remove(jatek);
                    context.SaveChanges();
                    return StatusCode(404, "A játék törlése sikerült.");
                }
                catch (Exception ex)
                {
                    return StatusCode(502, "A játék törlése nem sikerült!");
                }
            }
        }

        [HttpPut("JatekModosit")]

        public IActionResult JatekModosit(Jatek jatek)
        {
            using (var context = new jatekokContext())
            {
                try
                {
                    context.Jateks.Update(jatek);
                    context.SaveChanges();
                    return StatusCode(402, "A játék módosítása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return StatusCode(505, "A játék módosítása nem sikerült!");
                }
            
            }
        }
    }
}
