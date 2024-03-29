﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictuerUrl { get; set; }
        public int CatalogBrandId { get; set; }
        public string CatalogBrand { get; set; }

        public string  CatalogType { get; set; }
        public int CatalogTypeId { get; set; }
    }
}
