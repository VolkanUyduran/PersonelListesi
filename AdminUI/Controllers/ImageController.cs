using AdminUI.Models;
using Business.Concrete;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace AdminUI.Controllers
{
    public class ImageController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EFImageDal());
        // GET: Image
        [HttpGet]
        public ActionResult GetPersonelImage(int id, ImageFile imageFile)
        {
            List<string> Listimg = new List<string>();
            List<ImageFile> files = imageFileManager.GetListByPersonelId(id);
            if (files.Count > 0)
            {
                foreach (ImageFile item in files)
                {
                    var imgsrc = item.ImagePath.Replace("\\", "/").Split('/');
                    Listimg.Add(imgsrc[imgsrc.Length - 1].ToString());
                }
                ViewBag.ImgList = Listimg;
                return View(files);
            }
            return RedirectToAction("PersonelList", "Personel");
        }
        [HttpGet]
        public ActionResult AddImage(int id)
        {
            var value = imageFileManager.GetListByPersonelId(id);
            ProfileViewModel model = new ProfileViewModel();
            model.FileInfoes = new DirectoryInfo(Server.MapPath("~/images/")).GetFiles();
            return View(model);

        }
        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase profileFile, ImageFile imageFile)
        {
            if (profileFile != null)
            {
                string pic = System.IO.Path.GetFileName(profileFile.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), pic);
                profileFile.SaveAs(path);
                imageFile.ImageName = pic;
                imageFile.ImagePath = path;

                ResizeSettings resizeSetting = new ResizeSettings
                {
                    Width = 250,
                    Height = 250,
                    Format = "png"
                };
                ImageBuilder.Current.Build(path, path, resizeSetting);
                imageFileManager.Add(imageFile);
            }
            return RedirectToAction("AddImage");
        }
        public ActionResult DeleteImage(int Id)
        {
            var imageValues = imageFileManager.GetByIdImageFile(Id);
            imageFileManager.Delete(imageValues);
            return RedirectToAction("PersonelList", "Personel");
        }

    }
}
