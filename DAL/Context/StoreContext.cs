using Microsoft.EntityFrameworkCore;
using Pioneers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.DAL.Context
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext>options):base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ChildDepartment> ChildDepartments { get; set;}
    }
}
