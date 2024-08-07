﻿using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
    
            //09
            // string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            // Console.WriteLine(ImportSuppliers(context, suppliersXml));
            
            //10
            // string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            // Console.WriteLine(ImportParts(context, partsXml));
            
            //11
            // string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            // Console.WriteLine(ImportCars(context, carsXml));
            
            //12
            // string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            // Console.WriteLine(ImportCustomers(context, customersXml));
            
            //13
            // string salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            // Console.WriteLine(ImportSales(context, salesXml));
            
            //14
            // Console.WriteLine(GetCarsWithDistance(context));
            
            //15
            // Console.WriteLine(GetCarsFromMakeBmw(context));
            
            //16
            // Console.WriteLine(GetLocalSuppliers(context));
            
            //17
            // Console.WriteLine(GetCarsWithTheirListOfParts(context));
            
            //18
            // Console.WriteLine(GetTotalSalesByCustomer(context));
            
            //19
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer 
                = new XmlSerializer(typeof(SupplierImportDto[]), 
                    new XmlRootAttribute("Suppliers"));

            SupplierImportDto[] importDtos;
            using (var reader = new StringReader(inputXml))
            {
                importDtos = (SupplierImportDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = importDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToArray();
            
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {importDtos.Length}";
        }
        
        //10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer 
                = new XmlSerializer(typeof(PartsImportDto[]), 
                    new XmlRootAttribute("Parts"));

            PartsImportDto[] partsImportDto;
            using (StringReader reader = new StringReader(inputXml))
            {
                partsImportDto = (PartsImportDto[])xmlSerializer.Deserialize(reader);
            }

            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            var partsWithValidSuppliers = partsImportDto
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToArray();

            Part[] parts = partsWithValidSuppliers
                .Select(p => new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();
            
            context.Parts.AddRange(parts);
            context.SaveChanges();
            
            return $"Successfully imported {parts.Length}";
        }
        
        //11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CarsImportDto[])
                ,new XmlRootAttribute("Cars"));

            CarsImportDto[] importDto;
            using (var reader = new StringReader(inputXml))
            {
                importDto = (CarsImportDto[])serializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();

            foreach (var dto in importDto)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };

                int[] carPartsIds = dto.PartIds
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                List<PartCar> carParts = new List<PartCar>();

                foreach (int id in carPartsIds)
                {
                    carParts.Add(new PartCar()
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }
            
            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(CustomersImportDto[]),
                    new XmlRootAttribute("Customers"));

            CustomersImportDto[] importDtos;
            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (CustomersImportDto[])serializer.Deserialize(reader);
            }

            Customer[] customers = importDtos
                .Select(dto => new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver
                })
                .ToArray();
            
            context.Customers.AddRange(customers);
            context.SaveChanges();
            
            return $"Successfully imported {customers.Length}";
        }

        //13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer
                = new XmlSerializer(typeof(SalesImportDto[]), 
                    new XmlRootAttribute("Sales"));

            SalesImportDto[] importDtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                importDtos = (SalesImportDto[])serializer.Deserialize(reader);
            }

            int[] validCarIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            SalesImportDto[] dtosWithValidIds = importDtos
                .Where(dto => validCarIds.Contains(dto.CarId))
                .ToArray();

            List<Sale> sales = new List<Sale>();

            foreach (var dto in dtosWithValidIds)
            {
                Sale sale = new Sale()
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId,
                    Discount = dto.Discount,
                };
                
                sales.Add(sale);
            }
            
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
        
        //14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarWithDistanceExportDto[] carsWithDistance = context.Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new CarWithDistanceExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            return SerializeToXml(carsWithDistance, "cars");
        }
        
        //15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            BmwCarsExportDto[] bmwCars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BmwCarsExportDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            return SerializeToXml(bmwCars, "cars");
        }
        
        //16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            LocalSuppliersExportDto[] localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSuppliersExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return SerializeToXml(localSuppliers, "suppliers");
        }
        
        //17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            CarsWithPartsExportDto[] carsWithParts = context.Cars
                .Select(c => new CarsWithPartsExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.Select(pc => new PartsForCarsExportDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            return SerializeToXml(carsWithParts, "cars");
        }
        
        //18
        public static string GetTotalSalesByCustomer(CarDealerContext context) //!!
        {
            var temp = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new 
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver 
                            ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    }).ToArray()
                }).ToArray();
            
            var customerSalesInfo = temp
                .OrderByDescending(x => 
                    x.SalesInfo.Sum(y => y.Prices))
                .Select(a => new CustomersExportDto()
                {
                    FullName = a.FullName,
                    BoughtCars = a.BoughtCars,
                    SpentMoney = a.SalesInfo.Sum(b => (decimal)b.Prices)
                })
                .ToArray();
            
            return SerializeToXml(customerSalesInfo, "customers");
        }
        
        //19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context) //!!
        {
            var sales = context.Sales
                .Select(s => new SaleWithDiscountExportDto()
                {
                    Car = new CarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars
                        .Sum(pc => pc.Part.Price),
                    PriceWithDiscount = Math.Round(
                        (double)(s.Car.PartsCars.Sum(p => p.Part.Price)
                                 * (1 - (s.Discount / 100))), 4)
                }).ToArray();

            return SerializeToXml(sales, "sales");
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