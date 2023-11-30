using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class CustomerController : Controller
    {
        public List<Customer> customers = new List<Customer>()
                {
                    new Customer{Name="sal",Id=1},
                    new Customer{Name="sallu",Id=2},
                    new Customer{Name="salmon",Id=3},
                };
        public IActionResult Index()
        {
            return View(customers);
        }
        [Route("Customer/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            foreach(var customer in customers)
            {
                if (customer.Id == id)
                    return Ok(customer.Name);
            }
            return NotFound();
        }
    }
}
