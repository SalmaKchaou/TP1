using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using TP1.Models;
using TP1.Models.ViewModels;

namespace TP1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Customer> customers = new List<Customer>()
                {
                    new Customer{Name="sal"},
                    new Customer{Name="sallu"},
                    new Customer{Name="salmon"},
                };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            
            viewModel.Movie = new Movie { Name="MOVIE",ReleaseDate= new DateTime(2023, 1, 1) };
            viewModel.Customers = customers;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}