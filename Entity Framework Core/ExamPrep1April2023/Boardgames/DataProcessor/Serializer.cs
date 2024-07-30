using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ExportDto;
using Boardgames.Helper;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToArray()
                .Select(c => new CreatorsExportDto()
                {
                    Name = string.Join(" ", c.FirstName, c.LastName),
                    BoardgamesCount = c.Boardgames.Count(),
                    Boardgames = c.Boardgames
                        .Select(bg => new BoardgamesExportDto()
                        {
                            Name = bg.Name,
                            YearPublished = bg.YearPublished
                        })
                        .OrderBy(bg => bg.Name)
                        .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            return XmlSerializationHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                    .Any(bgs => bgs.Boardgame.YearPublished >= year && 
                                bgs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(bgs => bgs.Boardgame.YearPublished >= year && 
                                      bgs.Boardgame.Rating <= rating)
                        .Select(bgs => new
                        {
                            Name = bgs.Boardgame.Name,
                            Rating = bgs.Boardgame.Rating,
                            Mechanics = bgs.Boardgame.Mechanics,
                            Category = bgs.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(bg => bg.Rating)
                        .ThenBy(bg => bg.Name)
                        .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}