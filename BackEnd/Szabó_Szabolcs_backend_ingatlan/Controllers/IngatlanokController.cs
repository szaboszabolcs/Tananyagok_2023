using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Szabó_Szabolcs_backend_ingatlan.Models;

namespace Szabó_Szabolcs_backend_ingatlan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngatlanokController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            using (var context = new ingatlanContext())
            {
                try
                {
                    return StatusCode(200, context.Ingatlanoks.ToList());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpPost]

        public IActionResult Post(Ingatlanok ingatlan)
        {
            using (var context = new ingatlanContext())
            {
                try
                {
                    context.Ingatlanoks.Add(ingatlan);
                    context.SaveChanges();
                    return StatusCode(201);
                }
                catch (Exception ex)
                {
                    return StatusCode(400, "Hiányos adatok!");
                }
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            using (var context = new ingatlanContext())
            {
                try
                {
                    Ingatlanok ingatlan = new Ingatlanok();
                    ingatlan.Id = id;
                    context.Ingatlanoks.Remove(ingatlan);
                    context.SaveChanges();
                    return StatusCode(404);
                }
                catch (Exception ex)
                {
                    return StatusCode(404, "Az ingatlan nem létezik.");
                }
            }
        }
    }
}
