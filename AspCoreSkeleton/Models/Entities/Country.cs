using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSkeletonZien.Models.Entities
{
    public class Country
    {

        public Country()
        {
            /** To Avoid Null exceptions in case the database didn't have cities for this country**/
            this.Cities = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        /** Navigation Properties **/
        public virtual ICollection<City> Cities { get; set; }
    }
}
