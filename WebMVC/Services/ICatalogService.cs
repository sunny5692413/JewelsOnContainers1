using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{  //things I want my UI to konw , 2 drop downs and entire list 
    public interface ICatalogService  
    {
        Task<Catalog> GetCatalogItemsAsync(int page, int size, int? brand, int? type); // need to know what catalog is suppose to give the pageniteditem 
        Task<IEnumerable<SelectListItem>> GetBrandsAsync();//selectlistitem is the drop down
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
    }
}
