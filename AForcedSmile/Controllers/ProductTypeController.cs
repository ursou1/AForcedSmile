using AForcedSmile.db;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AForcedSmile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public ProductTypeController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget


        // GET: api/<ProductTypeController>
        [HttpGet]
        public IEnumerable<ProductTypeApi> Get()
        {
            return dbContext.ProductTypes.ToList().Select(s => (ProductTypeApi)s);
        }

        // GET api/<ProductTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeApi>> Get(int id)
        {
            var result = await dbContext.ProductTypes.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ProductTypeApi)result);
        }

        // POST api/<ProductTypeController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ProductTypeApi value)
        {
            var newProductType = (ProductType)value;
            dbContext.ProductTypes.Add(newProductType);
            await dbContext.SaveChangesAsync();
            return Ok(newProductType.Id);
        }

        // PUT api/<ProductTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductTypeApi value)
        {
            var oldProductType = await dbContext.ProductTypes.FindAsync(id);
            if (oldProductType == null)
                return NotFound();
            dbContext.Entry(oldProductType).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ProductTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldProductType = await dbContext.ProductTypes.FindAsync(id);
            if (oldProductType == null)
                return NotFound();
            dbContext.ProductTypes.Remove(oldProductType);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
