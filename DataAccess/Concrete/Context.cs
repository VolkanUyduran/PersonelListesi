using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
   public class Context: DbContext
    {
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
