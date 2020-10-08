using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSkeletonZien.Data;
using AspCoreSkeletonZien.Models.Entities;

namespace AspCoreSkeletonZien.Core.Managers
{
    public class MembersManager : Repository<Member, ApplicationDbContext>
    {
        public MembersManager(ApplicationDbContext context) : base(context)
        {
        }
        public override async Task<ICollection<Member>> GetAllAsync()
        {
            return await entities.Include(x=> x.City)
                                    .ThenInclude(city=> city.Country) 
                                  .ToListAsync();
        }

    }
}
