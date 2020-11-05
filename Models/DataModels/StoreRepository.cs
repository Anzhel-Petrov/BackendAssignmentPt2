using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public class StoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public StoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products.Include(t => t.Tracks).Include(c => c.Category);
    }
}
