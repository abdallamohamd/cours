using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.repo;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [ex]
    public class coursController : Controller
    {
        private readonly Icourserepo icourserepo;
        private readonly Icategory icategory;

        public coursController(Icourserepo icourserepo,Icategory icategory)
        {
            this.icourserepo = icourserepo;
            this.icategory = icategory;
        }

        public IActionResult index( string sstring)
        {
            List<Courses> courses = icourserepo.all();
            if (!string.IsNullOrEmpty(sstring))
            {
                courses=courses.Where(x=>x.Name.Contains(sstring)).ToList();
            }
            return View(courses);
        }
    }
}
