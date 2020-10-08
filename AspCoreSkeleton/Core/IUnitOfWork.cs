using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSkeletonZien.Core.Managers;

namespace AspCoreSkeletonZien.Core
{
    public interface IUnitOfWork 
    {
        public MembersManager Members { get;  }
        public CitiesManager Cities { get;  }
        public CountriesManager Countries { get;  }
    }
}
