using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TelePSocial.Areas.Identity.Data;
using TelePSocial.Data;
using TelePSocial.Models;

namespace TelePSocial.Controllers
{  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelePSociaDblContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger,UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, TelePSociaDblContext context)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Login", "Account", new { area = "Identity" });
            //}
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.nombre = user.Nombre_Usuario;
            ViewBag.photo = user.PhotoPerfil;
            ViewBag.DesImage = user.DesImage; 
            var List = await _context.PubliUsers.Where(z => !z.IdUser.Equals(user.UserName)).ToListAsync();
            return View(List);
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index");
        }
    }
}
