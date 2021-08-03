using Business.Concrete;
using Business.Validation;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AdminUI.Controllers
{
    public class PersonelController : Controller
    {
        PersonelManager personelManager = new PersonelManager(new EfPersonelDal());
        DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());
        DirectorManager directorManager = new DirectorManager(new EfDirectorDal());
        PersonelValidator personelValidator = new PersonelValidator();

        public ActionResult PersonelList()
        {
            var values = personelManager.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddPersonel()
        {
            List<SelectListItem> valuedirector = (from x in directorManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.DirectorId.ToString()
                                                  }
                                                ).ToList();

            List<SelectListItem> valuedepartment = (from y in departmentManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = y.Name,
                                                        Value = y.DepartmentId.ToString()
                                                    }).ToList();
            ViewBag.vlw = valuedirector;
            ViewBag.vlc = valuedepartment;
            return View();
        }
        [HttpPost]
        public ActionResult AddPersonel(Personel personel)
        {
            ValidationResult validationResult = personelValidator.Validate(personel);
            if (validationResult.IsValid)
            {
                personelManager.Add(personel);
                return RedirectToAction("PersonelList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditPersonel(int id)
        {
            List<SelectListItem> valuedepartment = (from x in departmentManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.DepartmentId.ToString()
                                                    }
                                               ).ToList();

            List<SelectListItem> valuedirector = (from x in directorManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.DirectorId.ToString()
                                                  }
                                    ).ToList();
            ViewBag.vldi = valuedirector;
            ViewBag.vld = valuedepartment;
            var personelvalue = personelManager.GetById(id);
            return View(personelvalue);
        }
        [HttpPost]
        public ActionResult EditPersonel(Personel personel)
        {
            personelManager.Update(personel);
            return RedirectToAction("PersonelList");
        }
        public ActionResult DeletePersonel(int id)
        {
            var result = personelManager.GetById(id);
            personelManager.Delete(result);
            return RedirectToAction("PersonelList");
        }
    }
}