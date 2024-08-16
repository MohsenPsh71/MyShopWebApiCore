using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApiCore.Models;

namespace SampleWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MyShopController : ControllerBase
    {
        private MyShopDbContext _context;
        public MyShopController(MyShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return new ObjectResult(_context.Customers);
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
