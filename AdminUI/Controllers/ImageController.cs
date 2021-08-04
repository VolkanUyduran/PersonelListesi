using AdminUI.Models;
using Business.Concrete;
using DataAccess.EntitiyFramework;
using Entities.Concrete;
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

        public ActionResult GetPersonelImage(int id)
        {
            var files = imageFileManager.GetListByPersonelId(id);
            return View(files);
        }
        [HttpGet]
        public ActionResult AddImage(int id)
        {

            var value = imageFileManager.GetListByPersonelId(id);

            ImageViewModel imageModel = new ImageViewModel() { FileAttach = null, Message = string.Empty, IsValid = false };
            
            try { }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return this.View(imageModel);
        }
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult AddImage(ImageViewModel imageModel, ImageFile imageFile)
        {
            //Eger dosya yolu mevcut degilse,yeni dosya yolu olustur
            string folderPath = Server.MapPath("~/Images/Gallery/");


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                // Dogrulama Islemleri
                if (ModelState.IsValid)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string expansion = Path.GetExtension(Request.Files[0].FileName);
                    string path = "/Images/Gallery/" + fileName + expansion;

                    //Dosya yükleme istek kontrolü
                    if (Request.Files.Count > 0)
                    {
                        var fullPath = Server.MapPath("/Images/Gallery/") + fileName + expansion;
                        //Resim dosyasi isim kontrolü
                        if (System.IO.File.Exists(fullPath))
                        {
                            ViewBag.ActionMessage = "Bu dosya adında başka bir resim mevcuttur";
                        }
                        else
                        {
                            Request.Files[0].SaveAs(Server.MapPath(path));
                            imageFile.ImageName = fileName;
                            imageFile.ImagePath = "/Images/Gallery/" + fileName + expansion;
                            imageFileManager.Add(imageFile);
                            //ViewBag.ActionMessage = "Resim yükleme başarıyla gerçekleşmiştir.";
                            imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarılı.   ";
                            return RedirectToAction("AddImage");
                        }
                    }

                    // Ayarlar - Dogrulama gecerliyse 
                    //imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarılı.   ";
                    imageModel.IsValid = true;
                }
                else
                {
                    // Ayarlar - Dogrulama gecersizse  
                    imageModel.Message = "'" + imageModel.FileAttach.FileName + "' dosya yükleme başarısız!   ";
                    imageModel.IsValid = false;
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
            return View(imageModel);
        }
        public ActionResult DeleteImage(int Id)
        {
            var imageValues = imageFileManager.GetByIdImageFile(Id);
            imageFileManager.Delete(imageValues);
            return RedirectToAction("GetPersonelImage/3");
        }

    }
}
