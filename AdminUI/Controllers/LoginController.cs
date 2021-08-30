using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Hashing;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminUI.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new DirectorManager(new EfDirectorDal()), new RoleManager(new EfRoleDal()));
        IDirectorService directorService = new DirectorManager(new EfDirectorDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var isExitsAdmin = authService.IsExitsAdmin();
            if (!isExitsAdmin)
            {
                var role = new Role();
                role.RoleName = "adminRole";
                var newRole=roleManager.Add(role);
                if (newRole.RoleId!=0)
                {
                    var Register = authService.Register("admin", "admin@gmail.com", "12345", newRole.RoleId);
                }  
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            //FormsAuthentication.Initialize();
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, loginDto.AdminMail, DateTime.Now, DateTime.Now.AddDays(1), true, loginDto.AdminMail);
            //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            //HttpContext.Response.Cookies.Add(cookie);

            var getUser = authService.Login(loginDto);

            if (getUser != null)
            {
                var hashCode = getUser.AdminPasswordSalt;
                //Password Hasing Process Call Helper Class Method    
                var encodingPasswordString = Helper.EncodePassword(loginDto.AdminPassword, hashCode);
                //Check Login Detail User Name Or Password    
                loginDto.AdminPassword = encodingPasswordString;

                var query = directorService.CheckLogin(loginDto);


                if (query != null)
                {
                    //RedirectToAction("Details/" + id.ToString(), "FullTimeEmployees");    
                    //return View("../Admin/Registration"); url not change in browser    
                    FormsAuthentication.SetAuthCookie(loginDto.ToString(), false);
                    Session["Admin"] = loginDto;
                    Session["Email"] = loginDto.AdminMail;
                    return RedirectToAction("PersonelList", "Personel");
                }

                else
                {
                    ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                    return View();
                }

            }

            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePassword(string oldPass, string newPass, string reNewPass)
        {
            if (newPass != reNewPass)
            {
                ViewBag.Message = "Şifreler uyuşmuyor.";
                return View();
            }
            var email = Session["Email"].ToString();
            var loginDto = new LoginDto();
            loginDto.AdminMail = email;
            var getUser = authService.Login(loginDto);
            if (getUser != null)
            {
                var hashCode = getUser.AdminPasswordSalt;
                //Password Hasing Process Call Helper Class Method    
                var encodingPasswordString = Helper.EncodePassword(oldPass, hashCode);
                //Check Login Detail User Name Or Password    
                loginDto.AdminPassword = encodingPasswordString;
                var query = directorService.CheckLogin(loginDto);
                if (query != null)
                {
                    var updatePassword = directorService.UpdatePassword(loginDto, newPass);
                    if (updatePassword)
                    {
                        ViewBag.Message = "Başarılı";
                        return View();
                    }
                    else
                    {
                        ViewBag.Message = "Başarısız";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Başarısız";
                    return View();
                }
            }
            return View();
        }
    }
}