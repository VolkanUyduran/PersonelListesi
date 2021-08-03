using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
