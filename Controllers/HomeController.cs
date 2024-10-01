using Linkify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Linkify.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
