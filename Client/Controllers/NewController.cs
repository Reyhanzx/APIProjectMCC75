using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class NewController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}