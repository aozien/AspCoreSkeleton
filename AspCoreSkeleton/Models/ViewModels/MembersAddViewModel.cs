using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using AspCoreSkeletonZien.Models.Entities;

namespace AspCoreSkeletonZien.Models.ViewModels
{
    public class MembersAddViewModel
    {
        public Member Member { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public string Title { get; set; }
    }
}