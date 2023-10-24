using Coleta_Colchao.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Coleta_Colchao.Data;

namespace Coleta_Colchao.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BancoContext  _bancoContext;
        
        public HomeController(ILogger<HomeController> logger, BancoContext bancoContext)
        {
            _logger = logger;
            _bancoContext = bancoContext;

        }
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acess");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}