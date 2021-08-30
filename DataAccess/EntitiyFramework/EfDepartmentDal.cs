using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntitiyFramework
{
    public class EfDepartmentDal : GenericRepository<Department>, IDepartmentDal
    {
        public int PersonelCountByDepartmentId(int departmentId)
        {
            var personelCount = c.Personels.Where(x => x.DepartmentId == departmentId).ToList();
            return personelCount.Count();
        }
    }
}
