using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAssignmentPt2.Models
{
    public class StoreRepository : IStoreRepository
    {
        // Repository pattern - this is our implementation that stores and retrieve object from our SQL server.
        // This class will be registered as a service and passed to other classes as an instance using controller injection.
        private StoreDbContext context;
        public StoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products.Include(t => t.Tracks).Include(c => c.Category);
    }
}
