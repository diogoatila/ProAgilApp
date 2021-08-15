using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           
               var results = await _context.Eventos.ToListAsync();

               if(results.Count != 0)
                return Ok(results);

                //Erro
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha na requisição ao banco de dados");
 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             var results = await _context.Eventos.FirstOrDefaultAsync(e => e.EventoID == id);

               if(results != null)
                return Ok(results);

                //Erro
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha na requisição ao banco de dados");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
