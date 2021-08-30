using Business.Abstract;
using Business.Concrete;
using DataAccess.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PublicUI.Controllers
{
    public class PersonelController : Controller
    {
        PersonelManager personelManager = new PersonelManager(new EfPersonelDal());
        ImageFileManager ımageFileManager = new ImageFileManager(new EFImageDal());
        [HttpGet]
        public ActionResult PersonelList()
        {
           
            var values = personelManager.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult GetPersonelImage(int id)
        {

            var value = ımageFileManager.GetListByPersonelId(id);
            return View(value);
        }
    }
}