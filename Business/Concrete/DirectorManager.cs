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
   public class DirectorManager:IDirectorService
    {
        IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public void Add(Director director)
        {
            _directorDal.Insert(director);
        }

        public void Delete(Director director)
        {
            _directorDal.Delete(director);
        }

        public Director GetById(int id)
        {
            return _directorDal.Get(x => x.DirectorId == id);
        }

        public List<Director> GetList()
        {
            return _directorDal.List();
        }

        public void Update(Director director)
        {
            _directorDal.Update(director);
        }
    }
}
