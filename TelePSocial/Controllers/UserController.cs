using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TelePSocial.Areas.Identity.Data;
using TelePSocial.Clases;
using TelePSocial.Data;
using TelePSocial.Entidades;

namespace TelePSocial.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelePSociaDblContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment,
            UserManager<ApplicationUser> userManager, TelePSociaDblContext context)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = await _context.PubliUsers.Where(z => z.IdUser.Equals(usuario.UserName)).ToListAsync();
            foreach (var item in list)
            {
                item.CantiLikes = await _context.LikesPublics.Where(z => z.idPubliUsers.Equals(item.idPubliUsers)).CountAsync();
                var canlike = await _context.LikesPublics.Where(z => z.idPubliUsers.Equals(item.idPubliUsers) && z.IdUser.Equals(usuario.UserName)).CountAsync();
                item.Comentarios = await _context.CommentUsers.Where(z => z.idPubliUsers.Equals(item.idPubliUsers)).ToListAsync();
                foreach(var items in item.Comentarios)
                {
                    var usuarioComent = await _userManager.FindByNameAsync(items.IdUser);
                    items.username = usuarioComent.UserName;
                    items.usuario = usuarioComent.Nombre_Usuario;
                    items.desPhoto = usuarioComent.DesImage;
                    items.photo = usuarioComent.PhotoPerfil;

                }
                if (canlike.Equals(1))
                {
                    item.CanLike = false;
                }
                else
                {
                    item.CanLike = true;
                }
            }
            ViewBag.ListPub = list;
            return View(usuario);
        }

        public async Task<IActionResult> EditUser()
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);
            //NOM_ARCHI = await Util.UploadDocument(_hostingEnvironment, item, "Cotizaciones/"),
            return PartialView(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(ApplicationUser Model)
        {
            var usuario = await _userManager.FindByNameAsync(User.Identity.Name);


            if (Model.DOC_DOCUM != null)
                {
                    usuario.PhotoPerfil = await Util.UploadImg(_hostingEnvironment, Model.DOC_DOCUM, "Photos/");
                } 
            usuario.FirstName = Model.FirstName;
            usuario.LastName = Model.LastName;
            usuario.Gender = Model.Gender;
            usuario.PhoneNumber = Model.PhoneNumber;
            usuario.FirstName = Model.FirstName; 
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));  
        }
        public async Task<IActionResult> deletePublic(int idd)
        {
            var publicacion = await _context.PubliUsers.FindAsync(idd);
            _context.Remove(publicacion);
            await _context.SaveChangesAsync();
            //NOM_ARCHI = await Util.UploadDocument(_hostingEnvironment, item, "Cotizaciones/"),
            return RedirectToAction(nameof(EditUser));
        }
        public async Task<IActionResult> verPerfil(string idd)
        {
            var usuario = await _userManager.FindByNameAsync(idd);
            var usuarioLog = await _userManager.FindByNameAsync(User.Identity.Name);
            var list = await _context.PubliUsers.Where(z => z.IdUser.Equals(usuario.UserName)).ToListAsync();
            foreach (var item in list)
            {
                item.CantiLikes = await _context.LikesPublics.Where(z => z.idPubliUsers.Equals(item.idPubliUsers)).CountAsync();
                var canlike = await _context.LikesPublics.Where(z => z.idPubliUsers.Equals(item.idPubliUsers) && z.IdUser.Equals(usuarioLog.UserName)).CountAsync();
                item.Comentarios = await _context.CommentUsers.Where(z => z.idPubliUsers.Equals(item.idPubliUsers)).ToListAsync();
                item.userpubli = await _userManager.FindByNameAsync(item.IdUser);

                foreach (var items in item.Comentarios)
                {
                    var usuarioComent = await _userManager.FindByNameAsync(items.IdUser);
                    items.username = usuarioComent.UserName;
                    items.usuario = usuarioComent.Nombre_Usuario;
                    items.desPhoto = usuarioComent.DesImage;
                    items.photo = usuarioComent.PhotoPerfil;

                }
                if (canlike.Equals(1))
                {
                    item.CanLike = false;
                }
                else
                {
                    item.CanLike = true;
                }
            }
            ViewBag.ListPub = list;
            return View(usuario);
        }

        
        public async Task<IActionResult> BuscarUsuario(string param)
        { 
            var list = await _context.usp_AspNetUsers.FromSqlRaw("usp_AspNetUsers @p0", param).ToListAsync();
            ViewData["Filtro"] = param;
            return View(list);
        }
    }
} 