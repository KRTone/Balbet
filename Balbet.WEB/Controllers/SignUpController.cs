using AutoMapper;
using Balbet.BL.Interfaces;
using Balbet.BL.ModelsDTO;
using Balbet.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Balbet.WEB.Controllers
{
    public class SignUpController : Controller
    {
        readonly IBusinessService businessService;
        public SignUpController(IBusinessService service)
        {
            this.businessService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                businessService.AddUser(Mapper.Map<UserViewModel, UserDTO>(viewModel));
                return View("SuccessCreating", viewModel);
            }
            return View();
        }

        public ActionResult SuccessCreating(UserViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}