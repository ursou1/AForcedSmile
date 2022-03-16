using AForcedSmile.db;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AForcedSmile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //dont forget
        private readonly ForcedSmileContext dbContext;
        public ProductController(ForcedSmileContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //dont forget

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return dbContext.Products.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return dbContext.Products.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public int Post([FromBody] Product value)
        {
            dbContext.Products.Add(value);
            dbContext.SaveChanges();
            return value.Id;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            var oldProduct = dbContext.Products.FirstOrDefault(s => s.Id == id);
            if (oldProduct == null)
                return;
            dbContext.Entry(oldProduct).CurrentValues.SetValues(value);
            dbContext.SaveChanges();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var oldProduct = dbContext.Products.FirstOrDefault(s => s.Id == id);
            if (oldProduct == null)
                return;
            dbContext.Products.Remove(oldProduct);
            dbContext.SaveChanges();
        }
    }
}
