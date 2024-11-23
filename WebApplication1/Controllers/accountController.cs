using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.v_model;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [ex]
    public class accountController : Controller
    {
        private readonly appcomtext appcomtext;
        private readonly UserManager<appuser> userManager;
        private readonly SignInManager<appuser> signInManager;

        public accountController(appcomtext appcomtext,UserManager<appuser> userManager,SignInManager<appuser> signInManager)
        {
            this.appcomtext = appcomtext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
         public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> reg(regvm regvm)
        {
            appuser appuser= new appuser();
            if(ModelState.IsValid )
            {
                appuser.UserName=regvm.name;
                appuser.address=regvm.address;
                appuser.PasswordHash = regvm.password;
                appuser.PhoneNumber = regvm.phone;
               IdentityResult result=await  userManager.CreateAsync(appuser,regvm.password);
                if (result.Succeeded)
                {
                    
                  await  userManager.AddToRoleAsync(appuser, "admin");
                   await signInManager.SignInAsync(appuser,false);
                    return RedirectToAction("index", "data");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("add",regvm);
        }

        //
        public IActionResult log()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> slog(logvm logvm)
        {
            if (ModelState.IsValid)
            {
                appuser appuser = await userManager.FindByNameAsync(logvm.UserName);
                if (appuser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appuser, logvm.Password);
                    if (found == true)
                    {
                       
                        await signInManager.SignInAsync(appuser, logvm.Remmber);
                        return RedirectToAction("index", "data");
                    }
                }
                ModelState.AddModelError("", "name or password in valid");
            }
            return View("log", logvm);
        }


        public async Task<IActionResult> sout()
        {
            await signInManager.SignOutAsync();
            return View("log");
        }


    }
}
