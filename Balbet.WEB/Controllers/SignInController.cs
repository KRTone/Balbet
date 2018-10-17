using Balbet.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Balbet.BL.Services;
using Balbet.BL.Interfaces;

namespace Balbet.WEB.Controllers
{
    public class SignInController : Controller
    {
        readonly IBusinessService businessService;

        public SignInController(IBusinessService businessService)
        {
            this.businessService = businessService;
        }

        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserViewModel currentUser)
        {
            if (ModelState.IsValid)
            {
                var necessaryUser = this.businessService.GetUserByLogin(currentUser.Login);
                if (necessaryUser != null && currentUser.Password == necessaryUser.Password)
                {
                    HttpCookie newUserCookie = new HttpCookie("login", currentUser.Login);
                    newUserCookie.Expires.AddMinutes(5);
                    HttpContext.Response.SetCookie(newUserCookie);
                    return View("SuccessfulSignIn");
                }
            }
            return View(currentUser);
        }

        public ActionResult SuccessfulSignIn(UserViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}