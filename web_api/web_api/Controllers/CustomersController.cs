using Microsoft.AspNetCore.Mvc;

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
            List<string> customer_names = new List<string>() { "abc", "cde", "efg" };
            List<string> customer_passwords = new List<string>() { "abc", "cde", "efg" };
            //List<int> customer_ids = new List<int>() { 1,2,3};
            List<int> customer_points = new List<int>() {10, 34, 53};
            
            Random rnd = new Random();
            customer.CustomerID = id;

            int r = rnd.Next(customer_names.Count);
            string x = customer_names[r];
            customer.UserName = x;
            

            r = rnd.Next(customer_passwords.Count);
            customer.Password = customer_passwords[r];

            r = rnd.Next(customer_points.Count);
            customer.Points = customer_points[r];

            return customer;
            
        } 
    }
}