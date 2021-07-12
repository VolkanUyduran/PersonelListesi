using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        List<Personel> GetList();
        Personel GetById(int id);
        void Add(Personel personel);
        void Delete(Personel personel);
        void Update(Personel personel);
        List<Personel> GetListByDepartmentId(int id);
    }
}
