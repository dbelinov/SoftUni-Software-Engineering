using System.Diagnostics;
using Humanizer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            string productInfo = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(GetUsersWithProducts(context));
        }

        //01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            
            context.Users.AddRange(users);
            context.SaveChanges();
            
            return $"Successfully imported {users.Count}";
        }

        //02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            
            context.Products.AddRange(products);
            context.SaveChanges();
            
            return $"Successfully imported {products.Count}";
        }

        //03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            
            categories.RemoveAll(c => c.Name == null);
            
            context.Categories.AddRange(categories);
            context.SaveChanges();
            
            return $"Successfully imported {categories.Count}";
        }

        //04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            
            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();
            
            return $"Successfully imported {categoryProducts.Count}";
        }

        //05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            
            return JsonConvert.SerializeObject(products, settings);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var productsBuyers = context.Users
                .Where(u => u.ProductsSold
                    .Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold.Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName,
                        })
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            return JsonConvert.SerializeObject(productsBuyers, settings);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = $"{c.CategoriesProducts.Average(cp => cp.Product.Price):f2}",
                    TotalRevenue = $"{c.CategoriesProducts.Sum(cp => cp.Product.Price):f2}"
                })
                .ToList();
            
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            
            return JsonConvert.SerializeObject(categories, settings);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToArray()
                })
                .OrderByDescending(u => u.SoldProducts.Length)
                .ToArray();
            
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            var output = new
            {
                UsersCount = users.Length,
                Users = users
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        u.Age,
                        SoldProducts = new
                        {
                            Count = u.SoldProducts.Length,
                            Products = u.SoldProducts
                        }
                    })
            };
            
            return JsonConvert.SerializeObject(output, settings);
        }
    }
}