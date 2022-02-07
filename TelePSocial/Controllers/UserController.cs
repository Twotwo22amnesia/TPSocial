using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TelePSocial.Areas.Identity.Data;
using TelePSocial.Data;
using TelePSocial.Entidades;

namespace TelePSocial.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelePSociaDblContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, TelePSociaDblContext context)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name); 
            return PartialView(usuario);
        }
    }
}
