using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TelePSocial.Data;

namespace TelePSocial.Controllers
{
    public class LogSesController : Controller
    {
        private readonly TelePSociaDblContext _context;

        public LogSesController(TelePSociaDblContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.LogSes.OrderBy(t => t.IdUser).ToListAsync());
        } 
    }
}
