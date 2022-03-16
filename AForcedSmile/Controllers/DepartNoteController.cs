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
    public class DepartNoteController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public DepartNoteController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        [HttpGet]
        public IEnumerable<DepartNoteApi> Get()
        {
            return dbContext.DepartNotes.ToList().Select(s => (DepartNoteApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartNoteApi>> Get(int id)
        {
            var result = await dbContext.DepartNotes.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok((DepartNoteApi)result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] DepartNoteApi value)
        {
            var newDepartNote = (DepartNote)value;
            dbContext.DepartNotes.Add(newDepartNote);
            await dbContext.SaveChangesAsync();
            return Ok(newDepartNote.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DepartNoteApi value)
        {
            var oldDepartNote = await dbContext.DepartNotes.FindAsync(id);
            if (oldDepartNote == null)
                return NotFound();
            dbContext.Entry(oldDepartNote).CurrentValues.SetValues(value);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldDepartNote = await dbContext.DepartNotes.FindAsync(id);
            if (oldDepartNote == null)
                return NotFound();
            dbContext.DepartNotes.Remove(oldDepartNote);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
