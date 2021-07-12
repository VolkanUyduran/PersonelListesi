using Business.Abstract;
using Business.Concrete;
using DataAccess.EntitiyFramework;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new DirectorManager(new EfDirectorDal()));
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminName,loginDto.AdminMail, loginDto.AdminPassword);
            return RedirectToAction("Index", "Login");
        }
    }
}