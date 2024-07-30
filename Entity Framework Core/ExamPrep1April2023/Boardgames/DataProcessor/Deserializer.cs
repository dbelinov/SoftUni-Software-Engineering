using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Boardgames.Data.Models;
using Boardgames.DataProcessor.ImportDto;
using Boardgames.Helper;
using Boardgames.Data.Models.Enums;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var creatorDtos = XmlSerializationHelper
                .Deserialize<CreatorsImportDto[]>(xmlString, "Creators");
        
            StringBuilder sb = new StringBuilder();
            List<Creator> creators = new List<Creator>();
        
            foreach (var creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
        
                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName
                };
        
                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
        
                    creator.Boardgames.Add(new Boardgame()
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics
                    });
                }
                
                creators.Add(creator);
                sb.AppendLine(string
                    .Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                        creator.Boardgames.Count));
            }
            
            context.Creators.AddRange(creators);
            context.SaveChanges();
        
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sellerDtos = JsonConvert.DeserializeObject<SellersImportDto[]>(jsonString);

            List<Seller> sellers = new List<Seller>();
            StringBuilder sb = new StringBuilder();
            var boardgamesIds = context.Boardgames
                .Select(b => b.Id)
                .ToArray();
            
            foreach (var sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };

                foreach (int id in sellerDto.BoardgamesIds.Distinct())
                {
                    if (!boardgamesIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = id
                    };
                    
                    seller.BoardgamesSellers.Add(boardgameSeller);
                }
                
                sellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller,
                    seller.Name, seller.BoardgamesSellers.Count));
            }
            
            context.Sellers.AddRange(sellers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
