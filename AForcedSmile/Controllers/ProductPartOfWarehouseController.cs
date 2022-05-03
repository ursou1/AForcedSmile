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
    public class ProductPartOfWarehouseController : ControllerBase
    {

        //dont forget
        private readonly ForcedSmileContext dbContext;
        public ProductPartOfWarehouseController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        // GET: api/<ProductPartOfWarehouseController>
        [HttpGet]
        public IEnumerable<ProductPartOfWarehouseApi> Get()
        {
            return dbContext.ProductPartOfWarehouses.ToList().Select(s => (ProductPartOfWarehouseApi)s);
        }

        // GET api/<ProductPartOfWarehouseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPartOfWarehouseApi>> Get(int id)
        {
            var result = await dbContext.ProductPartOfWarehouses.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ProductPartOfWarehouseApi)result);
        }

        // POST api/<ProductPartOfWarehouseController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ProductPartOfWarehouseApi value)
        {
            var newProductPartOfWarehouse = (ProductPartOfWarehouse)value;
            dbContext.ProductPartOfWarehouses.Add(newProductPartOfWarehouse);
            await dbContext.SaveChangesAsync();
            return Ok(newProductPartOfWarehouse.Id);
        }

        // PUT api/<ProductPartOfWarehouseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductPartOfWarehouseApi value)
        {
            var oldProductPartOfWarehouse = await dbContext.ProductPartOfWarehouses.FindAsync(id);
            if (oldProductPartOfWarehouse == null)
                return NotFound();
            dbContext.Entry(oldProductPartOfWarehouse).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ProductPartOfWarehouseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldProductPartOfWarehouse = await dbContext.ProductPartOfWarehouses.FindAsync(id);
            if (oldProductPartOfWarehouse == null)
                return NotFound();
            dbContext.ProductPartOfWarehouses.Remove(oldProductPartOfWarehouse);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
