using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using Tasks = ToDo.Models.Tasks;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
       
        public TaskListContext taskListDb { get; set; } = new TaskListContext();

        public IActionResult Index()
        {
            return View(taskListDb.Tasks.ToList());
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
