using GamersCommunity.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GamersCommunity.Web.Controllers
{
    public class GCBaseController : Controller
    {
        private readonly SignInManager<GcUser> _signInManager;
        public GCBaseController(SignInManager<GcUser> signInManager)
        {
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        

        //public string SignedInUser
        //{
        //    get
        //    {
        //        if (_signInManager.IsSignedIn(User))
        //        {
        //            return (HttpContext.Session.SetString("SignedInUser", User.Identity.Name.ToString())).to;
        //        }

        //        return string.Empty;
        //    }
        //    set
        //    {
        //        Session["UserId"] = value;
        //    }
        //}

    }
}