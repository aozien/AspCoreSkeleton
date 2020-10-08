using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSkeletonZien.Data;
using AspCoreSkeletonZien.Models.Entities;

namespace AspCoreSkeletonZien.Core.Managers
{
    public class CitiesManager : Repository<City, ApplicationDbContext>
    {
        public CitiesManager(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<City>> GetCitiesInCountry(int countryId)
        {
            return await entities.Where(city => city.CountryId == countryId).ToListAsync();
        }
    }
}
