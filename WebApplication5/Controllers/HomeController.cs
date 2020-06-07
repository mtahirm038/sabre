using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            List<Employee> oEmployess = new List<Employee>() {
                new Employee(){FirstName = "jen", LastName="Lee", Location= "Philadelphia"},
                new Employee(){FirstName = "jen", LastName="Lee", Location= "Philadelphia"},
            };

            return oEmployess;
        }
    }
}