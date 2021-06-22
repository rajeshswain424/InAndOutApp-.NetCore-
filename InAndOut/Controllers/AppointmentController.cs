using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            String todays = DateTime.Now.ToShortDateString();
            // return View();       
            return Ok(todays);
            
        }
        public ViewResult Rajesh()
        {

            return View();
        }
    }
}
