using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;
using WebApplication1.Models;
using WebApplication1.repo;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ex]
    public class trainerController : Controller
    {
        private readonly Itrainer itrainer;
        private readonly Icourserepo icourserepo;

        public trainerController(Itrainer itrainer,Icourserepo icourserepo)
        {
            this.itrainer = itrainer;
            this.icourserepo = icourserepo;
        }

        public IActionResult index()
        {
            List<trainer> trainers = itrainer.all();
            return View(trainers);
        }
        //
        public IActionResult add()
        {
            ViewData["cslist"] = icourserepo.all();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sadd( trainer trainer)
        {
            if (ModelState.IsValid)
            {
                itrainer.add(trainer);
                itrainer.save();
                return RedirectToAction("index");
            }
            return View("add",trainer);
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edite(int id)
        {
            trainer trainer= itrainer.Get(id);
            ViewData["cslist"] = icourserepo.all();
            return View(trainer);
        }
        [HttpPost]
         public IActionResult sedite(int id,trainer model)
        {
            trainer trainer =itrainer.Get(id);
            if (ModelState.IsValid)
            {
                trainer.Name=model.Name;
                trainer.phone= model.phone;
                trainer.address= model.address;
                trainer.courseid= model.courseid;
                trainer.age= model.age;
                 
                itrainer.save();
                return RedirectToAction("index");
            }
            ViewData["cslist"] = icourserepo.all();
            return View("edite", model);
        }
        //

        public IActionResult delete(int id)
        {
            trainer trainer = itrainer.Get(id);
            if (trainer == null)
            {
                return Content("No course by this id");
            }
            itrainer.delete(id);
           itrainer.save();
            return RedirectToAction("index");
        }

    }
}
