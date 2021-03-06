﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication5.Model;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
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
                try
                {
                    viewModel.Responsibilities = new List<string>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

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
    }
}
