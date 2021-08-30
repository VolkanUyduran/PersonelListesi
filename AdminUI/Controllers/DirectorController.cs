using Business.Concrete;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace AdminUI.Controllers
{

    public class DirectorController : Controller
    {
        DirectorManager directorManager = new DirectorManager(new EfDirectorDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        public ActionResult DirectorList()
        {
           var value= directorManager.GetList();
            return View(value);
        }
        public ActionResult DeleteDirector(int id)
        {
            var result = directorManager.GetById(id);
            directorManager.Delete(result);
            return RedirectToAction("DirectorList");
        }
        [HttpGet]
        public ActionResult UpdateDirector(int id)
        {
            var adminValue = directorManager.GetById(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult UpdateDirector(Director director)
        {
            directorManager.Update(director);
            return RedirectToAction("DirectorList");
        }
    }
}