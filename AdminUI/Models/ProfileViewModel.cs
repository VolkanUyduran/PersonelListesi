using Business.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProfileViewModel
    {
        //[AllowFileSize(FileSize = 5 * 1024 * 1024, ErrorMessage = "İzin verilen dosya boyutu : 5 MB")] //Resim boyutu en fazla 5MB
        //[AllowExtensions(Extensions = "png,jpg,jpeg,gif,PNG,JPG,JPEG,GIF", ErrorMessage = "Desteklenen dosya uzantıları :  .png | .jpg | .jpeg | .gif")] //Desteklenen formatlar
        public string ProfileImage
        {
            get;
            set;
        }
        public FileInfo[] FileInfoes
        {
            get;
            set;
        }
    }
}