using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication5.Model;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        // POST: api/Manager
        [HttpPost]
        public ManagerViewModel Build(Manager manager)
        {
            var viewModel = new ManagerViewModel();
            viewModel.DisplayName = manager.FirstName + " " + manager.LastName + " (" + manager.Title + ")";
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
            if (manager.Location == "Store" && manager.Title == "Sales Manager")
            {
                viewModel.Responsibilities.Add("Oversee Floor");
                viewModel.Responsibilities.Add("Customer Service");
            }
            else if (manager.Location == "Store")
            {
                viewModel.Responsibilities.Add("Oversee Floor");
            }
            else
            {
                viewModel.Responsibilities.Add("Oversee Warehouse");
            }
            return viewModel;

        }
    }
}
