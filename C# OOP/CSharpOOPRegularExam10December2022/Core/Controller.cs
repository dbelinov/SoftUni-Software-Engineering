using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths = new BoothRepository();
        
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            
            Booth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);
            
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            
            if (booths.Models.Any(b => b.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            
            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booths.Models
                .Any(b => b.CocktailMenu.Models
                    .Any(c => c.Name == cocktailName && c.Size == size)))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;
            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null) //!
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            
            booth.ChangeStatus();
            
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            bool isCocktail = false;
            
            string[] tokens = order.Split("/");
            string itemTypeName = tokens[0];
            string itemName = tokens[1];
            int countOfOrderedPieces = int.Parse(tokens[2]);

            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            if (itemTypeName != nameof(Hibernation) 
                && itemTypeName != nameof(MulledWine) 
                && itemTypeName != nameof(Gingerbread)
                && itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName)
                && !booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                isCocktail = true;
            }

            if (isCocktail)
            {
                string size = tokens[3];
                
                if (!booth.CocktailMenu.Models.Any(c => c.GetType().Name == itemTypeName
                    && c.Name == itemName
                    && c.Size == size))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }
                
                ICocktail cocktail;
                if (itemTypeName == nameof(Hibernation))
                {
                    cocktail = new Hibernation(itemName, size);
                }
                else
                {
                    cocktail = new MulledWine(itemName, size);
                }
                
                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }

            if (!booth.DelicacyMenu.Models.Any(d => d.GetType().Name == itemTypeName
                && d.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            IDelicacy delicacy;
            if (itemTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(itemName);
            }
            else
            {
                delicacy = new Stolen(itemName);
            }
            
            booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);

            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);
            
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            return booth.ToString();
        }
    }
}