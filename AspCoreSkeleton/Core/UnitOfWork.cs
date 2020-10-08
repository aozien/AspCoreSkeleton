using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSkeletonZien.Core.Managers;
using AspCoreSkeletonZien.Data;

namespace AspCoreSkeletonZien.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private MembersManager members;
        private CitiesManager cities;
        private CountriesManager countries;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        /*---   Managers (Lazy Loaded)   ---*/

        public MembersManager Members
        {
            get
            {
                if (members == null) members = new MembersManager(context);
                return members;
            }
        }

        public CitiesManager Cities
        {
            get
            {
                if (cities == null) cities = new CitiesManager(context);
                return cities;
            }
        }
        public CountriesManager Countries
        {
            get
            {
                if (countries == null) countries = new CountriesManager(context);
                return countries;
            }
        }


    }
}
