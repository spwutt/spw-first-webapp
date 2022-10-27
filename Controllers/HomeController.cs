using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using spw_first_webapp.Model;
using spw_first_webapp.Models;
using spw_first_webapp.Services;
using System.Diagnostics;

namespace spw_first_webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfileService _profileservice;

        public HomeController(IProfileService profileservice)
        {
            _profileservice = profileservice;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var _myprofile = await _profileservice.GetProfile();
                return View(model: JsonConvert.SerializeObject(_myprofile));
            }
            catch
            {
                return View(model: $"Sorry, ");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}