using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.Domain;
using ProductCatalogAPI.VIewModels;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;
        public CatalogController(CatalogContext context,IConfiguration config ) //injection
        {
            _context = context;//have access to database
            _config = config;//have access to config through out my class
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult>Items(
            [FromQuery] int pageIndex =0 ,
            [FromQuery] int pageSize=6) //grab the catalog item in the following code
        {
           var itemCount= await _context.CatalogItems.LongCountAsync();//get total # of items from catalog context
            var items=await _context.CatalogItems.OrderBy(c => c.Name)
                                  .Skip(pageIndex * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();
            items = ChangePictuerURL(items);//pass items from context to the method then return new items with replaced value
            var model = new PaginatedItemsViewModel<CatalogItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemCount,
                Data = items

            };
            return Ok(model);//return with ok status and items, can we not used Ok in the code ?
        }


        [HttpGet]
        [Route("[action]/type/{catalogTypeId}/brand/{catalogbBrandId}")]//why put curly brackets here ?
        public async Task<IActionResult> Items( int ? catalogTypeId, int? catalogBrandId,
           [FromQuery] int pageIndex = 0,
           [FromQuery] int pageSize = 6) //grab the catalog item in the following code
        {

            var root = (IQueryable<CatalogItem>) _context.CatalogItems;
            

            if (catalogTypeId.HasValue)
            { root = root.Where(c => c.CatalogTypeId == catalogTypeId); }

            if (catalogBrandId.HasValue)
            { root = root.Where(c => c.CatalogBrandId == catalogBrandId); }

            var itemCount = await root.LongCountAsync();//get total # of items from catalog context
            var items = await root.OrderBy(c => c.Name)
                                  .Skip(pageIndex * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();
            items = ChangePictuerURL(items);//pass items from context to the method then return new items with replaced value
            var model = new PaginatedItemsViewModel<CatalogItem>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemCount,
                Data = items

            };
            return Ok(model);//return with ok status and items, can we not used Ok in the code ?
        }
        private List<CatalogItem> ChangePictuerURL(List<CatalogItem> items)//not used by other API
        {
            items.ForEach(c => c.PictuerUrl=c.PictuerUrl.Replace("http://externalcatalogbaseurltobereplaced", 
                _config["ExternalCatalogBaseUrl"]));//strings are emutable,need to replace the old url with replaced string

            return items;


        }
        
        [HttpGet]
        [Route("[action]")]
        private  async Task<IActionResult> CatalogTypes()
        {
            var items = await _context.CatalogTypes.ToListAsync();
                return Ok(items);
        }


        [HttpGet]
        [Route("[action]")]
        private async Task<IActionResult> CatalogBrands()
        {
            var items = await _context.CatalogBrands.ToListAsync();
            return Ok(items);
        }


    }


}