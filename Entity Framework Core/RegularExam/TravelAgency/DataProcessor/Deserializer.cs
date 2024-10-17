using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Helper;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var importDtos = XmlSerializationHelper
                .Deserialize<CustomerImportDto[]>(xmlString, "Customers");

            List<Customer> customers = new List<Customer>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in importDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Customers.Any(c => c.FullName == dto.FullName)
                    || context.Customers.Any(c => c.Email == dto.Email)
                    || context.Customers.Any(c => c.PhoneNumber == dto.PhoneNumber)
                    || customers.Any(c => c.FullName == dto.FullName)
                    || customers.Any(c => c.Email == dto.Email)
                    || customers.Any(c => c.PhoneNumber == dto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    FullName = dto.FullName,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email
                };
                
                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }
            
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var importDtos = JsonConvert.DeserializeObject<BookingImportDto[]>(jsonString);

            List<Booking> bookings = new List<Booking>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in importDtos)
            {
                //?
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDateValid = DateTime.TryParseExact(dto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime validBookingDate);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking booking = new Booking()
                {
                    BookingDate = validBookingDate,
                    CustomerId = context.Customers.First(c => c.FullName == dto.CustomerName).Id,
                    Customer = context.Customers.First(c => c.FullName == dto.CustomerName),
                    TourPackageId = context.TourPackages.First(tp => tp.PackageName == dto.TourPackageName).Id,
                    TourPackage = context.TourPackages.First(tp => tp.PackageName == dto.TourPackageName)
                };

                bookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, booking.TourPackage.PackageName,
                    booking.BookingDate.ToString("yyyy-MM-dd")));
            }
            
            context.Bookings.AddRange(bookings);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
