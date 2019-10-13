using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogContext:DbContext
    {
        public CatalogContext(DbContextOptions options): base(options)// getting injected,passing options parameters to base class(CatalogContext)
        {

        }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }//brands make up my table,it's collection of brand


        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//plug in when the model is created
        {
            modelBuilder.Entity<CatalogBrand>(ConfigureCatalogBrand);//tell modelbuilder there are some configuration 
            modelBuilder.Entity<CatalogType>(ConfigureCatalogType);
            modelBuilder.Entity<CatalogItem>(ConfigureCatalogItem);

        }

        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_hilo");

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);
               
            builder.Property(c => c.Price)
                   .IsRequired();
            builder.HasOne(c => c.CatalogType)
                    .WithMany()
                    .HasForeignKey(c => c.CatalogTypeId);

            builder.HasOne(c => c.CatalogBrand)
                    .WithMany()
                    .HasForeignKey(c => c.CatalogBrandId);


        }

        private void ConfigureCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogTypes");
            builder.Property(t => t.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_type_hilo");
            builder.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);

        }

        private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrands");//table is build with the name of CatalogBrand, not the name used internally in code
            builder.Property(b => b.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo( "catalog_brand_hilo" );//set the low and hight automatic value
            builder.Property(b => b.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
