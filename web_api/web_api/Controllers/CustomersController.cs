using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly MyContext _context;

        public CustomersController(MyContext context)
        {
            _context = context;
        }



        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            customer.ClientInfo=new Client();
            List<string> customer_names = new List<string>() { "abc", "cde", "efg" };
            List<string> customer_passwords = new List<string>() { "abc", "cde", "efg" };
            //List<int> customer_ids = new List<int>() { 1,2,3};
            List<int> customer_points = new List<int>() {10, 34, 53};
            
            Random rnd = new Random();
            customer.CustomerID = id;

            int r = rnd.Next(customer_names.Count);
            string x = customer_names[r];
            customer.ClientInfo.UserName = x;
            

            r = rnd.Next(customer_passwords.Count);
            customer.ClientInfo.Password = customer_passwords[r];

            r = rnd.Next(customer_points.Count);
            customer.Points = customer_points[r];

            return customer;
            
        }
        



        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }
    }
}