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
    public class DeliveryNoteController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public DeliveryNoteController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        [HttpGet]
        public IEnumerable<DeliveryNoteApi> Get()
        {
            return dbContext.DeliveryNotes.ToList().Select(s => (DeliveryNoteApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryNoteApi>> Get(int id)
        {
            var result = await dbContext.DeliveryNotes.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((DeliveryNoteApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] DeliveryNoteApi value)
        {
            var newDeliveryNote = (DeliveryNote)value;
            dbContext.DeliveryNotes.Add(newDeliveryNote);
            await dbContext.SaveChangesAsync();
            return Ok(newDeliveryNote.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DeliveryNoteApi value)
        {
            var oldDeliveryNote = await dbContext.DeliveryNotes.FindAsync(id);
            if (oldDeliveryNote == null)
                return NotFound();
            dbContext.Entry(oldDeliveryNote).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldDeliveryNote = await dbContext.DeliveryNotes.FindAsync(id);
            if (oldDeliveryNote == null)
                return NotFound();
            dbContext.DeliveryNotes.Remove(oldDeliveryNote);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
