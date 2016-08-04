using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkEmulator
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(): base("name=CourseworkConnection")
        {
        }

        public DbSet<Flower> Flowers { get; set; }
    }
}
