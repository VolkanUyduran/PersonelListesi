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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Role Add(Role role)
        {
            _roleDal.Insert(role);
            return role;
        }

        public void Delete(Role role)
        {
            _roleDal.Delete(role);
        }

        public Role GetById(int id)
        {
            return _roleDal.Get(x => x.RoleId == id);
        }

        public List<Role> GetList()
        {
            return _roleDal.List();
        }

        public void Update(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
