using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSkeletonZien.Models.Entities
{
    public class City
    {
        public City()
        {
            /** To Avoid Null exceptions in case the database didn't have cities for this country**/
            this.Members = new HashSet<Member>();
        }

        [Key]
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }

        /** Navigation Properties and Foreign Keys **/

        /* Country */
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        /* End of Country */
        
        /* Members */
        public virtual ICollection<Member> Members { get; set; }

    }
}
