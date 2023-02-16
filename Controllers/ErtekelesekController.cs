using ErtekelesX.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ErtekelesX.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErtekelesekController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new ertekelorendszerContext())
            {
                try
                {
                    return Ok(context.Ertekeleseks.Include(f => f.Screening).Include(f=>f.Szempont).ToList());
                }
                catch (Exception ex) { return BadRequest(ex.Message); }
            }
        }

        [HttpPost]
        public IActionResult Post(Ertekelesek ertekeles)
        {
            using (var context = new ertekelorendszerContext())
            {
                try
                {
                    context.Ertekeleseks.Add(ertekeles);
                    context.SaveChanges();
                    var e=context.Ertekeleseks.Where(f=>f.ScreeningId==ertekeles.ScreeningId && f.SzempontId==ertekeles.SzempontId).ToList();
                    return Ok($"Adatok tárolása sikeresen megtörtént. ID: {e[0].Id}");
                }
                catch (Exception ex) { return StatusCode(230,ex.Message); }
            }
        }
    }

}
