using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Drawing.Drawing2D;

namespace Business.Concrete
{
    public class ImageFileManager: IImageFileService
    {
        IImageDal _ımageDal;

        public ImageFileManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }

        public void Add(ImageFile ımageFile)
        {
            _ımageDal.Insert(ımageFile);
        }

        public void Delete(ImageFile ımageFile)
        {
            _ımageDal.Delete(ımageFile);
        }

        public ImageFile GetByIdImageFile(int id)
        {
            return _ımageDal.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetList()
        {
            return _ımageDal.List();
        }
        public List<ImageFile> GetListByPersonelId(int id)
        {
            return _ımageDal.List(x => x.Id == id);
        }

        public void Update(ImageFile ımageFile)
        {
            _ımageDal.Update(ımageFile);
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public string ImageResize(Image img,int MaxWidth,int MaxHeight)
        {
            if (img.Width>MaxWidth || img.Height>MaxHeight)
            {
                double widthratio = (double)img.Width / (double)MaxWidth;
                double heighratio = (double)img.Height / (double)MaxHeight;
                double ratio = Math.Max(widthratio, heighratio);
                int newWidth = (int)(img.Width / ratio);
                int newHeight = (int)(img.Height / ratio);

                return newHeight.ToString() + "," + newWidth.ToString();
            }
            else
            {
                return img.Height.ToString() + "," + img.Width.ToString();
            }
        }
    }
}
