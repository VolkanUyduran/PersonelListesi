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
   public class DepartmentManager:IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void Add(Department department)
        {
            _departmentDal.Insert(department);
        }

        public void Delete(Department department)
        {
            _departmentDal.Delete(department);
        }

        public Department GetById(int id)
        {
            return _departmentDal.Get(x => x.DepartmentId == id);
        }

        public List<Department> GetList()
        {
            return _departmentDal.List();
        }

        public void Update(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
