using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class CatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; } //data for brands drop down 
        public IEnumerable<SelectListItem> Types { get; set; }//data for type drop down
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public int? BrandFilterApplied { get; set; }//which one is selected from the list
        public int? TypesFilterApplied { get; set; }


    }

}
