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
    public class PartOfWarehouseController : ControllerBase
    {

        //dont forget
        private readonly ForcedSmileContext dbContext;
        public PartOfWarehouseController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        // GET: api/<PartOfWarehouseController>
        [HttpGet]
        public IEnumerable<PartOfWarehouseApi> Get()
        {
            return dbContext.PartOfWarehouses.ToList().Select(s => (PartOfWarehouseApi)s);
        }

        // GET api/<PartOfWarehouseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartOfWarehouseApi>> Get(int id)
        {
            var result = await dbContext.PartOfWarehouses.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((PartOfWarehouseApi)result);
        }

        // POST api/<PartOfWarehouseController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PartOfWarehouseApi value)
        {
            var newPartOfWarehouse = (PartOfWarehouse)value;
            dbContext.PartOfWarehouses.Add(newPartOfWarehouse);
            await dbContext.SaveChangesAsync();
            return Ok(newPartOfWarehouse.Id);
        }

        // PUT api/<PartOfWarehouseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PartOfWarehouseApi value)
        {
            var oldPartOfWarehouse = await dbContext.PartOfWarehouses.FindAsync(id);
            if (oldPartOfWarehouse == null)
                return NotFound();
            dbContext.Entry(oldPartOfWarehouse).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<PartOfWarehouseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldPartOfWarehouse = await dbContext.PartOfWarehouses.FindAsync(id);
            if (oldPartOfWarehouse == null)
                return NotFound();
            dbContext.PartOfWarehouses.Remove(oldPartOfWarehouse);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
