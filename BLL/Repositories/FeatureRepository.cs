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
    public class FeatureRepository : IGenericRepository<Feature>, IFeatureRepository
    {
        private readonly StoreContext context;

        public FeatureRepository(StoreContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Feature item)
        {
            context.Features.AddAsync(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(Feature item)
        {
            item.IsDelete = true;
            await Update(item);
            return await context.SaveChangesAsync();
        }

        public async Task<Feature> Get(int? id)
        {
            return await context.Features.FindAsync(id);
        }

        public async Task<IEnumerable<Feature>> GetAll()
        {
            return await context.Features.Where(c => !c.IsDelete).ToListAsync();
        }

        public async Task<int> Update(Feature item)
        {
             context.Features.Update(item);
            return await context.SaveChangesAsync();
        }
    }
}
