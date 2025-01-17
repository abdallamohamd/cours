using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.repo;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [Authorize]
    
    public class catController : Controller
    {
        private readonly Icategory icategory;

        public catController(Icategory icategory)
        {
            this.icategory = icategory;
        }

        public IActionResult index()
        {
            List<category> categories  = icategory.all();

            return View(categories);
        }
        //

        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sadd(category category)
        {
            if (ModelState.IsValid)
            {

                icategory.add(category);
                icategory.save();
                return RedirectToAction("index");
            }
            return View("add", category);
        }
        //

        public IActionResult edite(int id)
        {
            category category = icategory.Get(id);
            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sedite(int id, category model)
        {
           category category = icategory.Get(id);

            if (ModelState.IsValid)
            {
               category.Name = model.Name;
                icategory.update(category);
                icategory.save();
                return RedirectToAction("index");
            }
            return View("edite", model);
        }

        //
        public IActionResult delete(int id)
        {
            category category = icategory.Get(id);
            if (category == null)
            {
                return Content("No course by this id");
            }
            icategory.delete(id);
            icategory.save();
            return RedirectToAction("index");
        }
    }
}
