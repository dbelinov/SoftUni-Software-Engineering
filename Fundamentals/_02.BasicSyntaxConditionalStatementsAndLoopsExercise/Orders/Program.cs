using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int orderAmount = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int order = 1; order <= orderAmount; order++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double priceForCoffee = pricePerCapsule * days * capsuleCount;
                totalPrice += priceForCoffee;

                Console.WriteLine($"The price for the coffee is: ${priceForCoffee:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}