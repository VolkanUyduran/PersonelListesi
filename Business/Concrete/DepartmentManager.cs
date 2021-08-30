using Business.Abstract;
using Business.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
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

        public int PersonelCountByDepartmentId(int departmentId) {
            var personelCount = _departmentDal.PersonelCountByDepartmentId(departmentId);
            return personelCount;
        }

    }
}
