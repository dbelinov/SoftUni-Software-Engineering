using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
        }
        
        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; private set; }
        public IRepository<ICocktail> CocktailMenu { get; private set; }
        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount) => CurrentBill += amount;

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
            }
            else
            {
                IsReserved = true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");
            foreach (ICocktail cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine("-Delicacy menu:");
            foreach (IDelicacy delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }
            
            return sb.ToString().Trim();
        }
    }
}