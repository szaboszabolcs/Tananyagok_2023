using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Szabó_Szabolcs_backend_uszoeb.Models;

namespace Szabó_Szabolcs_backend_uszoeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VersenyzoController : ControllerBase
    {

        [HttpGet("getVersenyzoNev")]

        public IActionResult GetVersenyzoNev()
        {
            using (var context = new uszoebContext())
            {
                try
                {
                    return Ok(context.Versenyzoks.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpGet("getVersenyzoSzama")]

        public IActionResult GetVersenyzokSzama()
        {

            using (var context = new uszoebContext())
            {
                try
                {
                    return Ok(context.Versenyzoks.Count());
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost("AddVersenyzo/{UserId}")]

        public IActionResult AddVersenyzo(string UserId, Versenyzok versenyzo)
        {
            using (var context = new uszoebContext())
            {
                if (UserId == Program.UID)
                {
                    context.Versenyzoks.Add(versenyzo);
                    context.SaveChanges();
                    return StatusCode(201, "Versenyzo hozzáadása sikeresen megtörtént.");
                }
                else
                {
                    return StatusCode(401, "Nincs jogosultsága új versenyző felvételéhez!");
                }

            }

        }

        [HttpPut("UpdateVersenyzo")]

        public IActionResult UpdateVersenyzo(string UserId, Versenyzok versenyzo)
        {
            using (var context = new uszoebContext())
            {
                if (UserId == Program.UID)
                {
                    context.Versenyzoks.Update(versenyzo);
                    context.SaveChanges();
                    return StatusCode(200, "A versenyző adatainak módosítása sikeresen megtörtént.");
                }
                else
                {
                    return StatusCode(401, "Nincs Jogosultsága új versenyző felvételéhez!");
                }
            }
        }

        [HttpDelete("DeleteVersenyzo")]

        public IActionResult DeleteVersenyzo(string UserId, int id)
        {
            using (var context = new uszoebContext())
            {
                if (UserId == Program.UID)
                {
                    Versenyzok versenyzok = new Versenyzok();
                    versenyzok.Id = id;
                    context.Versenyzoks.Remove(versenyzok);
                    context.SaveChanges();
                    return StatusCode(204, "Versenyző adatainak a törlése sikeresen megtörtént.");
                }
                else
                {
                    return StatusCode(401, "Nincs jogosultsága a versenyzők adatainak a törléséhez!");
                }
            }
        }
    }
}