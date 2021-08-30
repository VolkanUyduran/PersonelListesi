using Business.Abstract;
using Business.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

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

        public Director CheckLogin(LoginDto model)
        {
            var user = _directorDal.LoginCheck(model);
            return user;
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

        public Director GetUser(LoginDto model)
        {
            var user = _directorDal.GetUser(model);
            return user;
        }

        public bool IsExitsAdmin()
        {
            var user = _directorDal.IsExitsAdmin();
            return user;
        }

        public void Update(Director director)
        {
            _directorDal.Update(director);
        }
        public bool UpdatePassword(LoginDto dto,string newPassword) {

            var user = _directorDal.LoginCheck(dto);
            if (user!=null)
            {
                var keyNew = Helper.GeneratePassword(10);
                var hashPassowrd = Helper.EncodePassword(newPassword, keyNew);
                user.AdminPasswordHash = hashPassowrd;
                user.AdminPasswordSalt = keyNew;

                _directorDal.Update(user);
                return true;

            }
            return false;
        }
    }
}
