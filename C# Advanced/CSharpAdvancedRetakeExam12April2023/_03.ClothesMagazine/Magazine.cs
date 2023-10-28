using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count + 1 <= Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth clothingToRemove = Clothes.FirstOrDefault(c => c.Color == color);
            if (clothingToRemove != null)
            {
                Clothes.Remove(clothingToRemove);
                return true;
            }

            return false;
        }

        public Cloth GetSmallestCloth()
        {
            return Clothes.MinBy(c => c.Size);
        }

        public Cloth GetCloth(string color)
        {
            return Clothes.First(c => c.Color == color);
        }

        public int GetClothCount() => Clothes.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");
            foreach (Cloth clothe in Clothes.OrderBy(c => c.Size))
            {
                sb.AppendLine(clothe.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
