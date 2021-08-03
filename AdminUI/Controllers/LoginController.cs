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
using System.Web.Security;

namespace AdminUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        IAuthService authService = new AuthManager(new DirectorManager(new EfDirectorDal()), new RoleManager(new EfRoleDal()));
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {

            if (authService.Login(loginDto))
            {
                FormsAuthentication.SetAuthCookie(loginDto.AdminMail, false);
                Session["AdminMail"] = loginDto.AdminMail;
                return RedirectToAction("PersonelList", "Personel");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}