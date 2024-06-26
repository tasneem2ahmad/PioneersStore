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
    public class ChildDepartmentRepository : IGenericRepository<ChildDepartment>, IChildDepartmentRepository
    {
        private readonly StoreContext context;

        public ChildDepartmentRepository(StoreContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(ChildDepartment item)
        {
            await context.ChildDepartments.AddAsync(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(ChildDepartment item)
        {
            item.IsDeleted = true;
            await Update(item);
            return await context.SaveChangesAsync();
        }

        public async Task<ChildDepartment> Get(int? id)
        {
            return await context.ChildDepartments.FindAsync(id);
        }

        public async Task<IEnumerable<ChildDepartment>> GetAll()
        {
            return await context.ChildDepartments.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<int> Update(ChildDepartment item)
        {
            context.Update(item);
            return await context.SaveChangesAsync();
        }
    }
}
