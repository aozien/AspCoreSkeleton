using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSkeletonZien.Models.Enums;

namespace AspCoreSkeletonZien.Models.Entities
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Active")]
        public bool MemberStatus { get; set; }

        public string Notes { get; set; }


        [Display(Name = "User Profile Image")]
        public string UserProfileImage { get; set; }


        /** Navigation Properties and Foreign Keys **/

        //Note: 
        //To Maintain database integrity and avoid duplication, we shouldn't store the country in the users table, 
        //instead, we store the city and get the country when needed

        /*[Required]
          [ForeignKey(nameof(Country))]
          [Display(Name = "Country")]
          public int CountryId { get; set; }
          public Country Country { get; set; }*/
        
        [Required]
        [ForeignKey(nameof(City))]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
