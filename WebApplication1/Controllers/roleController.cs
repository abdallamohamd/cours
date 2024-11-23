using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.v_model;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [ex]
    public class roleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public roleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

       
        public IActionResult add()
        {
            return View("add");
        }
        public async Task<IActionResult> saverole(rolevm rolevm)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = rolevm.name;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    ViewBag.sucess = true;
                    return Content("role is added");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("add", rolevm);
        }
    }
}
