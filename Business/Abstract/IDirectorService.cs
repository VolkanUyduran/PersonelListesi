using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDirectorService
    {
        List<Director> GetList();
        Director GetById(int id);
        void Add(Director director);
        void Delete(Director director);
        void Update(Director director);
        Director GetUser(LoginDto model);
        Director CheckLogin(LoginDto model);
        bool IsExitsAdmin();
        bool UpdatePassword(LoginDto dto, string newPassword);
        string CheckDirectorRole(int Id);
    }
}
