using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone5MVC.Models;
using System.Net.Http;

namespace Capstone5MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(int Id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44374");

            var response = await client.GetAsync($"cars/{Id}.json");
            var donut = await response.Content.ReadAsAsync<Cars>();

            return View(donut);
        }
    }
}
