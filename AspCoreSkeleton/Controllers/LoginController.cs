
using Microsoft.AspNetCore.Mvc;
using AspCoreSkeletonZien.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AspCoreSkeletonZien.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        public LoginViewModel Input { get; set; }


        [TempData]
        public string ErrorMessage { get; set; }

        public LoginController(SignInManager<IdentityUser> signInManager,
          UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            if (_signInManager.IsSignedIn(User))
            { 
                    return LocalRedirect("~/");
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                var result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password,true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect("~/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Out()
        {
            await _signInManager.SignOutAsync();

                    return LocalRedirect("~/");
        }

    }

}
