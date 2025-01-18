using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleAppForWebApp.Models;
using SampleAppForWebApp.Services;

namespace SampleAppForWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KeyVaultService _keyVaultService;

        public HomeController(ILogger<HomeController> logger, KeyVaultService keyVaultService)
        {
            _logger = logger;
            _keyVaultService = keyVaultService;
        }
        
        public IActionResult Index()
        {
            var secret = Environment.GetEnvironmentVariable("SecretName");
            string secretValue = _keyVaultService.GetSecretValue(secret);

            ViewBag.SecretValue = secretValue;
            return View();
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
