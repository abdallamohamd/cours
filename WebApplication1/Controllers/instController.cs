using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;
using WebApplication1.repo;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ex]
    public class instController : Controller
    {
        private readonly Iinstructor iinstructor;

        public instController(Iinstructor iinstructor)
        {
            this.iinstructor = iinstructor;
        }

        public IActionResult index()
        {
            List<instructor> instructors = iinstructor.all();
            return View(instructors);
        }
        //

        public IActionResult add()
        {
            return View();
        }
         public IActionResult sadd(instructor instructor)
        {
            if (ModelState.IsValid)
            {
                iinstructor.add(instructor);
                iinstructor.save();
                return RedirectToAction("index");
            }
            return View("add",instructor);
        }

        public IActionResult edite(int id)
        {
               instructor instructor = iinstructor.Get(id); 
            return View(instructor);
        }
        public IActionResult sedite(int id,instructor model)
        {
            instructor instructor = iinstructor.Get(id);
            if(ModelState.IsValid)
            {
                instructor.sale = model.sale;
                instructor.phone= model.phone;
                instructor.Name = model.Name;
                iinstructor.save();
                return RedirectToAction("index");
            }
            return View("edite",model);
        }
        //
        public IActionResult delete(int id)
        {
           instructor instructor= iinstructor.Get(id);
            if (instructor == null)
            {
                return Content("Error");
            }
             iinstructor.delete(id);
            iinstructor.save();
            return RedirectToAction("index");
        }
    }
}
