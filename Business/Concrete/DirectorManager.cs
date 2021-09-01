using Business.Abstract;
using Business.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DirectorManager : IDirectorService
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
        public bool UpdatePassword(LoginDto dto, string newPassword)
        {

            var user = _directorDal.LoginCheck(dto);
            if (user != null)
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
        public string CheckDirectorRole(int Id)
        {
            return _directorDal.CheckDirectorRole(Id);
        }

        public bool IsDeletedAdmin(string LoginAdminRoleName, string DeletedAdminRoleName)
        {
            int LoginId = getRoleId(LoginAdminRoleName);
            int DeletedId = getRoleId(DeletedAdminRoleName);

            if (LoginId>DeletedId)
            {
                return true;
            }
            else if (LoginId < DeletedId)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int getRoleId(string LoginAdminRoleName)
        {
            int RoleId=0;
            switch (LoginAdminRoleName)
            {
                case "A":
                    return RoleId = 3;
                    break;
                case "B":
                    return RoleId = 2;
                    break;
                case "C":
                    return RoleId = 1;
                    break;
            }
            return RoleId;
        }
    }
}
