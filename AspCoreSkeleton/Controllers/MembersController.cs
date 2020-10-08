using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using AspCoreSkeletonZien.Core;
using AspCoreSkeletonZien.Models.Entities;
using AspCoreSkeletonZien.Models.ViewModels;

namespace AspCoreSkeletonZien.Controllers
{
 [Authorize]
    public class MembersController : Controller
    {
        private readonly IUnitOfWork unit;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MembersController( IUnitOfWork unit, 
                                  IWebHostEnvironment webHostEnvironment)
        {
            this.unit = unit;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var members = await unit.Members.GetAllAsync();
            return View(members);
        }
        public async Task<IActionResult> Add()
        {
            MemberViewModel memberViewModel = new MemberViewModel();
                ViewBag.Countries = (await unit.Countries.GetAllAsync())
                            .Select(country => new SelectListItem { Text = country.Name, Value = country.Id.ToString() })
                            .Prepend(new SelectListItem { Text = "Choose Country", Value = "" })
                            .ToList();
           
            ViewBag.Title = "Add New Member";

            return View(memberViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                string ImageName = UploadFile(member.UserProfileImage);

                Member newMember = new Member
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Gender = member.Gender,
                    CityId = member.CityId,
                    DateOfBirth = member.DateOfBirth,
                    MemberStatus= member.MemberStatus,
                    Notes = member.Notes,
                    PhoneNumber = member.PhoneNumber,
                    EmailAddress = member.EmailAddress,
                    UserProfileImage = ImageName,
                };
                var result =await unit.Members.AddAsync(newMember);
                if (result != null)
                {
                    TempData["Message"] = "Member was added successfully!";
                    ViewBag.Title = "Add New Member";
                }
                else return BadRequest();
            }
            return Redirect(nameof(Add));
        }


        private string UploadFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
