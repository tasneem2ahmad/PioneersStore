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
    public class MarketRepository : IGenericRepository<Market>, IMarketRepository
    {
        private readonly StoreContext context;

        public MarketRepository(StoreContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Market market)
        {
            context.Markets.AddAsync(market);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(Market market)
        {
            market.IsDeleted = true;
            await Update(market);
            return await context.SaveChangesAsync();
        }

        public async Task<Market> Get(int? id)
        {
           return await context.Markets.FindAsync(id);
        }

        public async Task<IEnumerable<Market>> GetAll()
        {
            return await context.Markets.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<int> Update(Market market)
        {
            context.Update(market);
            return await context.SaveChangesAsync();
        }
    }
}
