using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.infrastructure
{
    public class ApiPaths//no instance member in it
    {
        public static class Catalog//sub class of ApiPaths 
        {
            public static string GetAllTypes(string baseUri)//base is from config of start up
            {
                return $"{baseUri}catalogtypes";
            }
            public static string GetAllBrands(string baseUri)
            {
                return $"{baseUri}catalogbrands";
            }
            public static string GetAllCatalogItems(string baseUri, int page, int take, int? brand, int? type)
            {
                var filterQs = string.Empty;
                if (brand.HasValue || type.HasValue)
                {
                    var brandsQs = (brand.HasValue) ? brand.Value.ToString() : "null";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}/brand/{brandsQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
                //Apipaths not only make a call also make up URL
            }



        }


    }
}
