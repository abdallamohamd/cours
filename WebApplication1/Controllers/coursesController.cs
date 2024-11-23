using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.repo;
using WebApplication1.v_model;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ex]
    public class coursesController : Controller
    {
        private readonly Icourserepo icourserepo;
        private readonly Icategory icategory;
        private readonly Ilabs ilabs;
        private readonly Iinstructor iinstructor;
        private readonly appcomtext appcomtext;

        public coursesController(Icourserepo icourserepo,Icategory icategory,Ilabs ilabs,Iinstructor iinstructor,
            appcomtext appcomtext)
        {
            this.icourserepo = icourserepo;
            this.icategory = icategory;
            this.ilabs = ilabs;
            this.iinstructor = iinstructor;
            this.appcomtext = appcomtext;
        }

        public IActionResult check(string Name)
        {
         Courses courses= appcomtext.courses.FirstOrDefault(x => x.Name == Name);

            if(courses != null)

              return Json(false);

             return Json(true);
            
        }

        public IActionResult index()
        {
            List<Courses> courses = icourserepo.all(); 
            return View(courses);
        }

        public IActionResult add()
        {
            ViewData["clist"] = icategory.all();
            ViewData["lablist"] = ilabs.all();
            ViewData["inlist"] = iinstructor.all();

            return  View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sadd(Courses courses)
        {
            if (ModelState.IsValid)
            {
                icourserepo.add(courses);
                icourserepo.save();
                return RedirectToAction("index");
            }
            return View("add",courses);
        }
        //

        public IActionResult edite(int id)
        {
            Courses courses = icourserepo.Get(id);

            ViewData["clist"] = icategory.all();
            ViewData["lablist"] = ilabs.all();
            ViewData["inlist"] = iinstructor.all();

            return View(courses);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult sedite(int id,Courses model)
        {
            Courses course = icourserepo.Get(id);
            if (ModelState.IsValid)
            {
                course.Name=model.Name;
                course.Price=model.Price;
                course.startDate=model.startDate;
                course.categoryid=model.categoryid;
                course.insid=model.insid;
                course.labid = model.labid;
               // icourserepo.update(course);
                icourserepo.save();
               return RedirectToAction("index");
            }
            ViewData["clist"] = icategory.all();
            ViewData["lablist"] = ilabs.all();
            ViewData["inlist"] = iinstructor.all();
            return View("edite", model);
        }

        //
        
        public IActionResult delete(int id)
        {
          Courses courses=  icourserepo.Get(id);
            if (courses == null)
            {
                return Content("No course by this id");
            }
            icourserepo.delete(id);
            icourserepo.save();
            return RedirectToAction("index");
        }



    }
}
 