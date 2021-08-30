using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string AdminPasswordHash { get; set; }
        public string AdminPasswordSalt { get; set; }
        public ICollection<Personel> Personels { get; set; }

        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}