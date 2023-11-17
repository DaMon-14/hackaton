using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace web_api.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/")]
    public class CustomersController : ControllerBase
    {
        private readonly MyContext _context;

        public CustomersController(MyContext context)
        {
            _context = context;
        }


        // GET: api/Customers/5
        [HttpGet("Customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Customers/")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'MyContext.Customers'  is null.");
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
        }

        // POST: api/ModifyCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ModifyCustomers/{id}")]
        public async Task<ActionResult<Customer>> ModifyCustomer(Customer customer, int id)
        {
            if (_context.Customers == null)
            {
                return Problem("nothing to modify");
            }
            Customer getcustomer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(getcustomer);
            if (customer.UserName == "string")
            {
                customer.UserName = getcustomer.UserName;
            }
            if(customer.Password == "string")
            {
                customer.Password = getcustomer.Password;
            }
            if (customer.Points == 0)
            {
                customer.Points = getcustomer.Points;
            }
            customer.CustomerID = id;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("Customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}