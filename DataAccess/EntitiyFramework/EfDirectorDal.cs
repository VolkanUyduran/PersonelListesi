using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntitiyFramework
{
    public class EfDirectorDal : GenericRepository<Director>, IDirectorDal
    {
        public Director GetUser(LoginDto dto)
        {
            var user = c.Directors.Where(x => x.Email == dto.AdminMail).FirstOrDefault();
            return user;
        }

        public bool IsExitsAdmin()
        {
            var user = c.Directors.Where(x => x.Email == "admin@gmail.com").FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public Director LoginCheck(LoginDto dto)
        {
            var user = c.Directors.Where(x => x.Email == dto.AdminMail && x.AdminPasswordHash == dto.AdminPassword).FirstOrDefault();
            return user;
        }

        public string CheckDirectorRole(int Id)
        {
            string RoleDirectorName = c.Directors.Where(x => x.DirectorId == Id).Select(s => s.Role.RoleName).FirstOrDefault();
            
            return RoleDirectorName;
        }


    }
}
