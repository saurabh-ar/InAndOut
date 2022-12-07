using Microsoft.AspNetCore.Mvc;
using System;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();  
        }
        public IActionResult Details(int id)
        {
            return Ok($"this is test for the number passing through : {id}");
        }


    }

}
