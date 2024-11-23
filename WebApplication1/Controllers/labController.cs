using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Identity.Client;
using WebApplication1.Models;
using WebApplication1.repo;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ex]
    public class labController : Controller
    {
        private readonly Ilabs ilabs;

        public labController(Ilabs ilabs)
        {
            this.ilabs = ilabs;
        }

        public IActionResult inndex()
        {
            List<labs> labs = ilabs.all();
            
            return View(labs );
        }
        //

        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sadd(labs labs)
        {
            if(ModelState.IsValid)
            {

                ilabs.add(labs);
                ilabs.save();
                return RedirectToAction("inndex");
            }
            return View("add",labs);
        }
        //

        public IActionResult edite(int id)
        {
           labs labs= ilabs.Get(id);
            return View(labs);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sedite(int id,labs model)
        {
            labs labs= ilabs.Get(id);

            if (ModelState.IsValid)
            {
                labs.name = model.name;
                ilabs.update(labs);
                ilabs.save();
                return RedirectToAction("inndex");
            }
            return View("edite", model);
        }

        //
        public IActionResult delete(int id)
        {
            labs labs = ilabs.Get(id);
            if (labs == null)
            {
                return Content("No course by this id");
            }
             ilabs.delete(id);
            ilabs.save();
            return RedirectToAction("inndex");
        }

    }
}
