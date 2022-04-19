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
    public class SoftDeleteController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public SoftDeleteController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        // GET: api/<SoftDeleteController>
        [HttpGet]
        public IEnumerable<SoftDeleteApi> Get()
        {
            return dbContext.SoftDeletes.ToList().Select(s => (SoftDeleteApi)s);
        }

        // GET api/<SoftDeleteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoftDeleteApi>> Get(int id)
        {
            var result = await dbContext.SoftDeletes.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((SoftDeleteApi)result);
        }

        // POST api/<SoftDeleteController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] SoftDeleteApi value)
        {
            var newSoftDelete = (SoftDelete)value;
            dbContext.SoftDeletes.Add(newSoftDelete);
            await dbContext.SaveChangesAsync();
            return Ok(newSoftDelete.Id);
        }

        // PUT api/<SoftDeleteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SoftDeleteApi value)
        {
            var oldSoftDelete = await dbContext.SoftDeletes.FindAsync(id);
            if (oldSoftDelete == null)
                return NotFound();
            dbContext.Entry(oldSoftDelete).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<SoftDeleteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldSoftDelete = await dbContext.SoftDeletes.FindAsync(id);
            if (oldSoftDelete == null)
                return NotFound();
            dbContext.SoftDeletes.Remove(oldSoftDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
