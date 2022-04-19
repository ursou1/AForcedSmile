using AForcedSmile.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AForcedSmile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public UnitController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        // GET: api/<UnitController>
        [HttpGet]
        public IEnumerable<UnitApi> Get()
        {
            return dbContext.Units.ToList().Select(s => (UnitApi)s);
        }

        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitApi>> Get(int id)
        {
            var result = await dbContext.Units.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((UnitApi)result);
        }

        // POST api/<UnitController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] UnitApi value)
        {
            var newUnit = (Unit)value;
            dbContext.Units.Add(newUnit);
            await dbContext.SaveChangesAsync();
            return Ok(newUnit.Id);
        }

        // PUT api/<UnitController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UnitApi value)
        {
            var oldUnit = await dbContext.Units.FindAsync(id);
            if (oldUnit == null)
                return NotFound();
            dbContext.Entry(oldUnit).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<UnitController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldUnit = await dbContext.Units.FindAsync(id);
            if (oldUnit == null)
                return NotFound();
            dbContext.Units.Remove(oldUnit);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
