using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSkeletonZien.Models.ViewModels
{
    public class LoginViewModel 
    {

            [Required]
            [DataType(DataType.EmailAddress)]
            [DisplayName("Email Address")]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

    }
}
