using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            
            //01
            // string data = File.ReadAllText("../../../Datasets/users.xml");
            // Console.WriteLine(ImportUsers(context, data));
            
            //02
            // string data = File.ReadAllText("../../../Datasets/products.xml");
            // Console.WriteLine(ImportProducts(context, data));
            
            //03
            // string data = File.ReadAllText("../../../Datasets/categories.xml");
            // Console.WriteLine(ImportCategories(context, data));
            
            //04
            // string data = File.ReadAllText("../../../Datasets/categories-products.xml");
            // Console.WriteLine(ImportCategoryProducts(context, data));
            
            //05
            // Console.WriteLine(GetProductsInRange(context));
            
            //06
            // Console.WriteLine(GetSoldProducts(context));
            
            //07
            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        //01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UsersImportDto[]),
                new XmlRootAttribute("Users"));

            UsersImportDto[] importDtos;
            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (UsersImportDto[])serializer.Deserialize(reader);
            }

            User[] users = importDtos
                .Select(dto => new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                })
                .ToArray();
            
            context.AddRange(users);
            context.SaveChanges();
            
            return $"Successfully imported {users.Length}";
        }

        //02
        //Works in Judge
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsImportDto[]),
                new XmlRootAttribute("Products"));

            ProductsImportDto[] importDtos;
            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (ProductsImportDto[])serializer.Deserialize(reader);
            }

            Product[] products = importDtos
                .Select(dto => new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    BuyerId = dto.BuyerId,
                    SellerId = dto.SellerId
                })
                .ToArray();
            
            context.AddRange(products);
            context.SaveChanges();
            
            return $"Successfully imported {products.Length}";
        }

        //03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesImportDto[]),
                new XmlRootAttribute("Categories"));

            CategoriesImportDto[] importDtos;
            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (CategoriesImportDto[])serializer.Deserialize(reader);
            }

            var categories = importDtos
                .Select(dto => new Category()
                {
                    Name = dto.Name
                })
                .ToList();
            
            context.AddRange(categories);
            context.SaveChanges();
            
            return $"Successfully imported {categories.Count}";
        }

        //04
        //Works in Judge
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesProductsImportDto[]),
                new XmlRootAttribute("CategoryProducts"));

            CategoriesProductsImportDto[] importDtos;
            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (CategoriesProductsImportDto[])serializer.Deserialize(reader);
            }

            var categoriesProducts = importDtos
                .Select(dto => new CategoryProduct()
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId
                })
                .ToList();
            
            context.AddRange(categoriesProducts);
            context.SaveChanges();
            
            return $"Successfully imported {categoriesProducts.Count}";
        }

        //05
        //? ;(
        public static string GetProductsInRange(ProductShopContext context)
        {
            ProductsInRangeExportDto[] productsInRange = context.Products
                .Select(p => new ProductsInRangeExportDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerName = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .Where(dto => dto.Price >= 500 && dto.Price <= 1000)
                .OrderBy(dto => dto.Price)
                .Take(10)
                .ToArray();

            return SerializeToXml(productsInRange, "Products");
        }

        //06
        //Works in Judge
        public static string GetSoldProducts(ProductShopContext context)
        {
            var sellersProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new SellersWithSoldProductsExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new SoldProductsExportDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .Take(5)
                .ToList();

            return SerializeToXml(sellersProducts, "Users");
        }

        //07
        //Works in judge
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoriesExportDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(dto => dto.Count)
                .ThenBy(dto => dto.TotalRevenue)
                .ToList();

            return SerializeToXml(categories, "Categories");
        }

        //?
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Select(u => new UsersProductsExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = u.ProductsSold
                        .Select(p => new ProductsExportDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToList();

            return SerializeToXml(usersWithProducts, "users");
        }
        
        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
            StringBuilder stringBuilder = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = omitDeclaration,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return stringBuilder.ToString();
        }
    }
}