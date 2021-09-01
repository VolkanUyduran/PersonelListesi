using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDirectorDal : IRepository<Director>
    {
        Director GetUser(LoginDto dto);
        Director LoginCheck(LoginDto dto);
        bool IsExitsAdmin();

        string CheckDirectorRole(int Id);
    }
}
