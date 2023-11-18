using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CustomersController : ControllerBase
    {
        private readonly MyContext _context;

        public CustomersController(MyContext context)
        {
            _context = context;
        }

        // GET: api/login/user/pass
        [HttpGet("login/{user}/{pass}")]
        public async Task<ActionResult<string>> GetCustomer(string user, string pass)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserName == user);

            if (customer == null)
            {
                return "user not found";
            }

            if (customer.Password == pass)
            {
                return "correct password";
            }
            return "incorect password";
        }


        // GET: api/points/User
        [HttpGet("points/{user}")]
        public async Task<ActionResult<int>> GetCustomer(string user)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserName == user);

            if (customer == null)
            {
                return NotFound();
            }
            return customer.Points;
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

        //POST: api/AddPoints/username&points
        [HttpPost("AddPoints/{username}&{points}")]
        public async Task<ActionResult<string>> PostCustomer(string username, int points)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'MyContext.Customers'  is null.");
            }

            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserName == username);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            customer.CustomerID = 0;
            if (points > customer.Points && points < 0)
            {
                return "not enough points";
            }
            customer.Points += points;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return "added customer";
        }


        // POST: api/Customers/username&password
        [HttpPost("Customers/{username}&{password}")]
        public async Task<ActionResult<string>> PostCustomer(string username, string password)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'MyContext.Customers'  is null.");
            }
            Customer customer = new Customer();
            customer.UserName = username;
            customer.Password = password;
            customer.CustomerID = 0;
            customer.Points = 0;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return "added customer";
        }


        // POST: api/ModifyCustomers/5
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
            if (customer.Password == "string")
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