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
    public class ClientController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public ClientController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        [HttpGet]
        public IEnumerable<ClientApi> Get()
        {
            return dbContext.Clients.ToList().Select(s => (ClientApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientApi>> Get(int id)
        {
            var result = await dbContext.Clients.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((ClientApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ClientApi value)
        {
            var newClient = (Client)value;
            dbContext.Clients.Add(newClient);
            await dbContext.SaveChangesAsync();
            return Ok(newClient.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientApi value)
        {
            var oldClient = await dbContext.Clients.FindAsync(id);
            if (oldClient == null)
                return NotFound();
            dbContext.Entry(oldClient).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldClient = await dbContext.Clients.FindAsync(id);
            if (oldClient == null)
                return NotFound();
            dbContext.Clients.Remove(oldClient);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
