using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspCoreSkeletonZien.Models.Entities;
using AspCoreSkeletonZien.Models.Enums;

namespace AspCoreSkeletonZien.Models.ViewModels
{
    public class MemberViewModel
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
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

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


        [Display(Name = "Member Profile Image")]
        [Required]
        public IFormFile UserProfileImage { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
    }
}
