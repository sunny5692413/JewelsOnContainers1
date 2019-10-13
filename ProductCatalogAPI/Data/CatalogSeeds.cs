using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogSeeds
    {
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();
            if(!context.CatalogBrands.Any())//if the count is not greater than zero which means there's no records in the table
            {
                context.CatalogBrands.AddRange(GetPreconfigurationCatalogBrands());//add a range of records into brand table
                context.SaveChanges();

            }


            if (!context.CatalogTypes.Any())
            {
                context.CatalogTypes.AddRange(GetPreconfigurationCatalogTypes());
                context.SaveChanges();

            }

            if (!context.CatalogItems.Any())
            {
                context.CatalogItems.AddRange(GetPreconfigurationCatalogItems());
                context.SaveChanges();

            }
        }

      

        private static IEnumerable <CatalogItem>GetPreconfigurationCatalogItems()
        {
            return new List<CatalogItem>()

            {

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=3, Description = "A ring that has been around for over 100 years", Name = "World Star", Price = 199.5M, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },

                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "will make you world champions", Name = "White Line", Price= 88.50M, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=3, Description = "You have already won gold medal", Name = "Prism White", Price = 129, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=2, Description = "Olympic runner", Name = "Foundation Hitech", Price = 12, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=1, Description = "Roslyn Red Sheet", Name = "Roslyn White", Price = 188.5M, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=2, Description = "Lala Land", Name = "Blue Star", Price = 112, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=1, Description = "High in the sky", Name = "Roslyn Green", Price = 212, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },

                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=1, Description = "Light as carbon", Name = "Deep Purple", Price = 238.5M, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },

                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "High Jumper", Name = "Antique Ring", Price = 129, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=3, Description = "Dunker", Name = "Elequent", Price = 12, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },

                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = "All round", Name = "Inredeible", Price = 248.5M, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },

                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=1, Description = "Pricesless", Name = "London Sky", Price = 412, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },

                new CatalogItem() { CatalogTypeId=3,CatalogBrandId=3, Description = "You ar ethe star", Name = "Elequent", Price = 123, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },

                new CatalogItem() { CatalogTypeId=3,CatalogBrandId=2, Description = "A ring popular in the 16th and 17th century in Western Europe that was used as an engagement wedding ring", Name = "London Star", Price = 218.5M, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },

                new CatalogItem() { CatalogTypeId=3,CatalogBrandId=1, Description = "A floppy, bendable ring made out of links of metal", Name = "Paris Blues", Price = 312, PictuerUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }



            };
        }

        private static IEnumerable<CatalogType> GetPreconfigurationCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "engagement ring" },
                new CatalogType() { Type = "wedding ring" },
                new CatalogType() { Type = "fashion ring" }

            };
        }
            private static IEnumerable<CatalogBrand> GetPreconfigurationCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand(){Brand="Tiffany"},
                new CatalogBrand(){Brand="Debeer"},
                new CatalogBrand(){Brand="Graff"}
            };
        }
    }
}

