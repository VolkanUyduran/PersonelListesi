using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Personel> Personels { get; set; }

    }
}
