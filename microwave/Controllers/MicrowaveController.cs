using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using microwave.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace microwave.Controllers
{
    public class MicrowaveController : MicrowaveBaseController  // Inherit from your abstract base controller
    {
        public IActionResult Index()
        {
            // You can use methods and properties from the base controller here
            int time = 90;
            int potency = 5;

            return Heating(time, potency);  // Example usage
        }
    }
}