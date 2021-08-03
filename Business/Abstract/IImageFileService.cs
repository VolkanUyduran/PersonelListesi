using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList(); 

        List<ImageFile> GetListByPersonelId(int id);

        ImageFile GetByIdImageFile(int id);
        void Add(ImageFile ımageFile);
        void Delete(ImageFile ımageFile);
        void Update(ImageFile ımageFile);

    }
}
