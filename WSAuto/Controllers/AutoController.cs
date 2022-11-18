using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        // GET /api/auto/modelo
        [HttpGet("{modelo}")]
        public dynamic Get(string modelo)
        {
            dynamic auto = (from a in _context.Autos
                            where a.Modelo == modelo
                            select a);
            if (auto == null)
            {
                return NotFound();
            }

            return auto;
        }


        // POST /api/auto
        [HttpPost]
        public ActionResult Post([FromBody] Auto auto)
        {
            _context.Autos.Add(auto);
            _context.SaveChanges();
            return Ok();
        }


    }
}
