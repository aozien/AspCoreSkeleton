using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSkeletonZien.Data;
using AspCoreSkeletonZien.Models.Entities;

namespace AspCoreSkeletonZien.Core.Managers
{
    public class CountriesManager : Repository<Country, ApplicationDbContext>
    {
        public CountriesManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
