using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntitiyFramework
{
   public class EFImageDal:GenericRepository<ImageFile>,IImageDal
    {

    }
}
