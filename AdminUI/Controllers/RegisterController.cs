using Business.Abstract;
using Business.Concrete;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
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
        IAuthService authService = new AuthManager(new DirectorManager(new EfDirectorDal()),new RoleManager(new EfRoleDal()));
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> valuedirector = (from x in roleManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.RoleName,
                                                      Value = x.RoleId.ToString()
                                                  }
                                               ).ToList();
            ViewBag.vlr = valuedirector;

            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminName,loginDto.AdminMail, loginDto.AdminPassword,loginDto.AdminRoleId);
            return RedirectToAction("Index", "Login");
        }
    }
}