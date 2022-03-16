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
    public class ProviderController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public ProviderController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        // GET: api/<ProviderController>
        [HttpGet]
        public IEnumerable<ProviderApi> Get()
        {
            return dbContext.Providers.ToList().Select(s => (ProviderApi)s);
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderApi>> Get(int id)
        {
            var result = await dbContext.Providers.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ProviderApi)result);
        }

        // POST api/<ProviderController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ProviderApi value)
        {
            var newProvider = (Provider)value;
            dbContext.Providers.Add(newProvider);
            await dbContext.SaveChangesAsync();
            return Ok(newProvider.Id);
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProviderApi value)
        {
            var oldProvider = await dbContext.Providers.FindAsync(id);
            if (oldProvider == null)
                return NotFound();
            dbContext.Entry(oldProvider).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldProvider = await dbContext.Providers.FindAsync(id);
            if (oldProvider == null)
                return NotFound();
            dbContext.Providers.Remove(oldProvider);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
