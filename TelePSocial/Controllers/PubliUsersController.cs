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
    public class PubliUsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelePSociaDblContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PubliUsersController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, TelePSociaDblContext context)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> CreatePubli()
        { 
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = usuario.Nombre_Usuario;
;
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePubli(PubliUsers model)
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            model.IdUser = usuario.UserName;
            model.FecPublic = DateTime.Now.Date;
            model.HorPublic = DateTime.Now.TimeOfDay;
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home" );
        }
        public async Task<IActionResult> LikePubli(int idd)
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            var publi = await _context.PubliUsers.FindAsync(idd);
            var likePubl = new LikesPublics{
                idPubliUsers = idd,
                IdUser = usuario.UserName
            }; 
            _context.Add(likePubl);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Comentar(int idd)
        {
            ViewBag.Id = idd;

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Comentar(CommentUsers model)
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            model.IdUser = usuario.UserName; 
            model.idPubliUsers = model.idPubliUsers;
            model.FecComment = DateTime.Now.Date;
            model.HorComment = DateTime.Now.TimeOfDay;
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
