using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Boardgames.Helper;
using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using Invoices.DataProcessor.ImportDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Invoices.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            ClientImportDto[] clientsDtos = XmlSerializationHelper
                .Deserialize<ClientImportDto[]>(xmlString, "Clients");

            List<Client> clients = new List<Client>();
            StringBuilder sb = new StringBuilder();
            foreach (var clientDto in clientsDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                };

                foreach (var addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    Address address = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };
                    
                    client.Addresses.Add(address);
                }
                
                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }
            
            context.Clients.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var settings = new JsonSerializerSettings()
            {
                Culture = CultureInfo.InvariantCulture
            };
            
            var invoicesDtos = JsonConvert.DeserializeObject<InvoiceImportDto[]>(jsonString, settings);

            List<Invoice> invoices = new List<Invoice>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var invoiceDto in invoicesDtos)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var checkedIssueDate = DateTime
                    .TryParse(invoiceDto.IssueDate, CultureInfo.InvariantCulture, DateTimeStyles.None
                        , out DateTime validIssueDate);
                var checkedDueDate = DateTime
                    .TryParse(invoiceDto.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None
                        , out DateTime validDueDate);

                if (checkedDueDate == false 
                    || checkedIssueDate == false 
                    || DateTime.Compare(validDueDate, validIssueDate) < 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Clients.Any(cl => cl.Id == invoiceDto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = validIssueDate,
                    DueDate = validDueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId
                };
                
                invoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }
            
            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var productsDtos = JsonConvert.DeserializeObject<ProductImportDto[]>(jsonString);

            List<Product> products = new List<Product>();
            StringBuilder sb = new StringBuilder();

            foreach (var dto in productsDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    CategoryType = (CategoryType)dto.CategoryType,
                };

                foreach (int clientId in dto.Clients.Distinct())
                {
                    if (!context.Clients.Any(cl => cl.Id == clientId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ProductClient productClient = new ProductClient()
                    {
                        Product = product,
                        ClientId = clientId
                    };
                    
                    product.ProductsClients.Add(productClient);
                }
                
                products.Add(product);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }
            
            context.Products.AddRange(products);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
