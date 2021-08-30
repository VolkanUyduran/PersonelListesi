using Business.Concrete;
using Business.Validation;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());
        PersonelManager personelManager = new PersonelManager(new EfPersonelDal());
        DepartmentValidator departmentvalidator = new DepartmentValidator();

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
            //ValidationResult validationResult = departmentvalidator.Validate(result);
            //if (validationResult.IsValid)
            //{
            //    var count = departmentManager.PersonelCountByDepartmentId(id);

            //    departmentManager.Delete(result);
            //    return RedirectToAction("DepartmentList");
            //}
            //else
            //{
            //    foreach (var item in validationResult.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            if (id==0)
            {
                return Json(new { failed = true, message = "Geçersiz id" });
            }

            var count = departmentManager.PersonelCountByDepartmentId(id);
            if (count==0)
            {
                departmentManager.Delete(result);
                return Json(new { failed = false, message = "Silindi" });
            }
            else
            {
                return Json(new { failed = true, message = "Departman içinde personeller bulunduğu için, silemezsiniz." });
            }
          

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