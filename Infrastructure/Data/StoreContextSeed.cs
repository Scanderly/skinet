using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Core.Entities;
using System.IO;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContent context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandData=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach(var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                 if(!context.ProductTypes.Any())
                {
                    var typesdata=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types=JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                    foreach(var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                 if(!context.Products.Any())
                {
                    var productsData=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products=JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach(var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger=loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);

            }
        }
    }
}