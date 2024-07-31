using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Medicines.Helper;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var patientDtos = JsonConvert.DeserializeObject<PatientImportDto[]>(jsonString);

            List<Patient> patients = new List<Patient>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in patientDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = dto.FullName,
                    AgeGroup = (AgeGroup)dto.AgeGroup,
                    Gender = (Gender)dto.Gender,
                };

                foreach (int medicineDto in dto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(pm => pm.MedicineId == medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        MedicineId = medicineDto,
                        PatientId = patient.Id
                    };
                    
                    patient.PatientsMedicines.Add(patientMedicine);
                }
                
                patients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName,
                    patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var pharmaciesDtos = XmlSerializationHelper
                .Deserialize<PharmacyImportDto[]>(xmlString, "Pharmacies");

            List<Pharmacy> pharmacies = new List<Pharmacy>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in pharmaciesDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!bool.TryParse(dto.IsNonStop, out bool isNonStop))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = dto.Name,
                    PhoneNumber = dto.PhoneNumber,
                    IsNonStop = isNonStop
                };

                foreach (var medicineDto in dto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isProductionDateValid = DateTime
                        .TryParseExact(medicineDto.ProductionDate, 
                            "yyyy-MM-dd", 
                            CultureInfo.InvariantCulture, 
                            DateTimeStyles.None, 
                            out DateTime productionDate);

                    bool isExpiryDateValid = DateTime
                        .TryParseExact(medicineDto.ExpiryDate, 
                            "yyyy-MM-dd", 
                            CultureInfo.InvariantCulture, 
                            DateTimeStyles.None, 
                            out DateTime expiryDate);

                    if (!isProductionDateValid || !isExpiryDateValid || productionDate >= expiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (pharmacy.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    Medicine medicine = new Medicine()
                    {
                        Name = medicineDto.Name,
                        Price = medicineDto.Price,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = medicineDto.Producer,
                        Category = (Category)medicineDto.Category
                    };

                    pharmacy.Medicines.Add(medicine);
                }
                
                pharmacies.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }
            
            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();

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
