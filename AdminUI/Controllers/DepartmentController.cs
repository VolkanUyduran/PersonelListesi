using Business.Abstract;
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
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());
        PersonelManager personelManager = new PersonelManager(new EfPersonelDal());

        public ActionResult DepartmentList()
        {
            var value=departmentManager.GetList();
            return View(value);
        }
        public ActionResult GetListDepartmentId(int id)
        {
            var value=personelManager.GetListByDepartmentId(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {

            departmentManager.Add(department);
            return RedirectToAction("DepartmentList");
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        public ActionResult DeleteDepartment(int id)
        {
            var result = departmentManager.GetById(id);
            departmentManager.Delete(result);
            return RedirectToAction("DepartmentList");
        }
        [HttpGet]
        public ActionResult EditDepartment(int id)
        {
            var departmentvalue = departmentManager.GetById(id);
            return View(departmentvalue);
        }
        [HttpPost]
        public ActionResult EditDepartment(Department department)
        {
             departmentManager.Update(department);
            return RedirectToAction("DepartmentList");
        }
    }
}