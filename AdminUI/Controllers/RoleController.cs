using Business.Concrete;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class RoleController : Controller
    {
        RoleManager roleManager = new RoleManager(new EfRoleDal());

        public ActionResult RoleList()
        {
            var value = roleManager.GetList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            roleManager.Add(role);
            return RedirectToAction("RoleList");
        }
        [HttpGet]
        public ActionResult EditRole(int id)
        {
            var rolevalue = roleManager.GetById(id);
            return View(rolevalue);
        }
        [HttpPost]
        public ActionResult EditRole(Role role)
        {
            roleManager.Update(role);
            return RedirectToAction("RoleList");
        }
        public ActionResult DeleteRole(int id)
        {
            var result = roleManager.GetById(id);
            roleManager.Delete(result);
            return RedirectToAction("RoleList");
        }
    }
}