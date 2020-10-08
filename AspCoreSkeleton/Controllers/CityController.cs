using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreSkeletonZien.Core;
using AspCoreSkeletonZien.Models.Entities;

namespace AspCoreSkeletonZien.Controllers
{
    public class CityController : Controller
    {
        private readonly IUnitOfWork unit;

        public CityController(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        [HttpGet]
        public async Task< IActionResult> Cities(int countryId)
        {
           List<City> cities= await unit.Cities.GetCitiesInCountry(countryId);
            return Json(cities);
        }
    }
}
