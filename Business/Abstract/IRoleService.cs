using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IRoleService
    {
        List<Role> GetList();
        Role GetById(int id);
        void Add(Role role);
        void Delete(Role role);
        void Update(Role role);
    }
}
