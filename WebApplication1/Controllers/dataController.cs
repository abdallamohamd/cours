using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class dataController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
