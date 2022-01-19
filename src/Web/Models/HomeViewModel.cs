﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class HomeViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        //Return Categories with CategoryViewModel
        public List<SelectListItem> Categories{ get; set; }
        public List<SelectListItem> Brands { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
