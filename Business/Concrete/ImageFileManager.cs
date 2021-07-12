using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public List<ImageFile> GetList()
        {
            return _ımageDal.List();
        }
        public List<ImageFile> GetListByPersonelId(int id)
        {
            return _ımageDal.List(x => x.ImageId == id);
        }

    }
}
