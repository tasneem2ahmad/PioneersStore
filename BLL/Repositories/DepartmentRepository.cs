using Microsoft.EntityFrameworkCore;
using Pioneers.BLL.Interfaces;
using Pioneers.DAL.Context;
using Pioneers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.BLL.Repositories
{
    public class DepartmentRepository : IGenericRepository<Department>, IDepartmentRepository
    {
        private readonly StoreContext context;

        public DepartmentRepository(StoreContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Department department)
        {
            await context.Departments.AddAsync(department);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(Department department)
        {
            department.IsDeleted= true;
            await Update(department);
            return await context.SaveChangesAsync();
        }

        public async Task<Department> Get(int? id)
        {
            return await context.Departments.FindAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAll() => await context.Departments.Where(c => !c.IsDeleted).ToListAsync();
       

        public async Task<int> Update(Department department)
        {
            context.Update(department);
            return await context.SaveChangesAsync();
        }
    }
}
