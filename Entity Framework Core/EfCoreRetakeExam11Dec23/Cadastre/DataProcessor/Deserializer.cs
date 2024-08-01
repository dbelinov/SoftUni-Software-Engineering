using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Cadastre.Helper;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var districtDtos = XmlSerializationHelper
                .Deserialize<DistrictImportDto[]>(xmlDocument, "Districts");

            List<District> districts = new List<District>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in districtDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (districts.Any(d => d.Name == dto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District district = new District()
                {
                    Name = dto.Name,
                    PostalCode = dto.PostalCode,
                    Region = Enum.Parse<Region>(dto.Region) //!!
                };

                foreach (var propertyDto in dto.Properties)
                {
                    if (!IsValid(propertyDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDateCorrect = DateTime.TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDateOfAcquisition);

                    if (!isDateCorrect)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (district.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (district.Properties.Any(p => p.Address == propertyDto.Address)
                        || dbContext.Properties.Any(p => p.Address == propertyDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property property = new Property()
                    {
                        DistrictId = district.Id,
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = validDateOfAcquisition
                    };
                    
                    district.Properties.Add(property);
                }
                
                districts.Add(district);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }
            
            dbContext.Districts.AddRange(districts);
            dbContext.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var citizenDtos = JsonConvert.DeserializeObject<CitizenImportDto[]>(jsonDocument);

            List<Citizen> citizens = new List<Citizen>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in citizenDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dto.MaritalStatus != "Unmarried" && dto.MaritalStatus != "Married"
                    && dto.MaritalStatus != "Divorced" && dto.MaritalStatus != "Widowed")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isBirthDateValid = DateTime.TryParseExact(dto.BirthDate, "dd-MM-yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validBirthDate);

                if (!isBirthDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Citizen citizen = new Citizen()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    BirthDate = validBirthDate,
                    MaritalStatus = Enum.Parse<MaritalStatus>(dto.MaritalStatus)
                };

                foreach (int propertyId in dto.Properties)
                {
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        CitizenId = citizen.Id,
                        PropertyId = propertyId
                    };
                    
                    citizen.PropertiesCitizens.Add(propertyCitizen);
                }
                
                citizens.Add(citizen);
                sb.AppendLine(String.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName,
                    citizen.PropertiesCitizens.Count));
            }
            
            dbContext.Citizens.AddRange(citizens);
            dbContext.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
