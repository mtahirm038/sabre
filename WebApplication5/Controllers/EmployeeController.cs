using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Model;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [HttpGet]
        public EmployeeViewModel Get(Employee employee)
        {
            /*          Employee e = new Employee();
                        e.FirstName = "Muhammad";
                        e.LastName = "Tahir";
                        e.Location = "Philly";*/

            var viewModel = new EmployeeViewModel
            {
                DisplayName = employee.FirstName + " " + employee.LastName
            };
            if (employee.Location == "Store")
            {
                viewModel.Responsibilities.Add("Stock Shelves");
                viewModel.Responsibilities.Add("Customer Service");
            }
            else
            {
                viewModel.Responsibilities.Add("Load Warehouse Trucks");
            }
            return viewModel;
        }
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public EmployeeViewModel Build(Employee employee)
        {
            var viewModel = new EmployeeViewModel
            {
                DisplayName = employee.FirstName + " " + employee.LastName
            };
            if (viewModel.Responsibilities == null)
            {
                viewModel.Responsibilities = new List<string>();
            }
            if (employee.Location == "Store")
            {
                viewModel.Responsibilities.Add("Stock Shelves");
                viewModel.Responsibilities.Add("Customer Service");
            }
            else
            {
                viewModel.Responsibilities.Add("Load Warehouse Trucks");
            }
            return viewModel;
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
