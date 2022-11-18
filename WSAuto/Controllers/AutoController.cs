using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSAuto.Data;
using WSAuto.Models;

namespace WSAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {

        private readonly DBAutoContext _context;

        public AutoController(DBAutoContext context)
        {
            _context = context;
        }


        // GET /api/auto
        [HttpGet]
        public List<Auto> Get()
        {
            return _context.Autos.ToList();
        }


        // GET /api/auto/id
        [HttpGet("{id}")]
        public ActionResult<Auto> Get(int id)
        {
            Auto auto = (from a in _context.Autos
                         where a.Id == id
                         select a).SingleOrDefault();
            if (auto == null)
            {
                return NotFound();
            }

            return auto;
        }



        // GET /api/auto/modelo-color/modelo-color
        [HttpGet("{parametro}/{dato}")]
        public dynamic Get(string parametro, string dato)
        {
            dynamic auto = null;
            switch (parametro)
            {
                case "modelo":
                    auto = (from a in _context.Autos
                            where a.Modelo == dato
                            select a);
                    break;
                case "color":
                    auto = (from a in _context.Autos
                            where a.Color == dato
                            select a);
                    break;
                default:
                    return NoContent();
            }

            if (auto == null)
            {
                return NotFound();
            }

            return auto;
        }


        // GET /api/auto/marca/modelo
        [HttpGet("{parametro}/{marca}/{modelo}")]
        public dynamic Get(string parametro, string marca, string modelo)
        {
            if (parametro != "marcamodelo")
            {
                return NoContent();
            }

            var autos = (from a in _context.Autos
                         where a.Marca == marca && a.Modelo == modelo
                         select a);
            if (autos == null)
            {
                return NotFound();
            }

            return autos;
        }


        // POST /api/auto
        [HttpPost]
        public ActionResult Post([FromBody] Auto auto)
        {
            _context.Autos.Add(auto);
            _context.SaveChanges();
            return Ok();
        }


        // PUT /api/auto
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Auto auto)
        {
            if (auto.Id != id)
            {
                return BadRequest();
            }

            _context.Entry(auto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }


        // DELETE /api/auto
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var auto = (from a in _context.Autos
                        where a.Id == id
                        select a).SingleOrDefault();
            if (auto == null)
            {
                return NotFound();
            }

            _context.Autos.Remove(auto);
            _context.SaveChanges();

            return Ok();
        }


    }
}
