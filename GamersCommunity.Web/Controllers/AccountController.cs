using System.Threading.Tasks;
using GamersCommunity.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GamersCommunity.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<GcUser> _userManager;
        private readonly SignInManager<GcUser> _signInManager;

        public AccountController(UserManager<GcUser> userManager, SignInManager<GcUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        #region Signup
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(GcSignUpUser user)
        {
            if (ModelState.IsValid)
            {
                var _user = new GcUser { UserName = user.Email, Email = user.Email };
                var _result = await _userManager.CreateAsync(_user, user.Password);

                if (_result.Succeeded)
                {
                    await _signInManager.SignInAsync(_user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                //showing all errors
                foreach (var error in _result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        #endregion

        #region Signin
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(GcSignInUser user)
        {
            if (ModelState.IsValid)
            {
                var _result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (_result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                //wrong password
                ModelState.AddModelError("", "Sign In Failed!!!");

            }
            return View();
        }
        #endregion

        #region Sign Out
        [HttpPost]
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}