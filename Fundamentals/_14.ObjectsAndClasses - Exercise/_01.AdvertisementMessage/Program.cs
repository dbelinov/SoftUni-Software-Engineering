using System;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[]
            {
                "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can't live without this product."
            };
            string[] events = new string[]
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            string[] authors = new string[] {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            string[] cities = new string[] {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            int messages = int.Parse(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < messages; i++)
            {
                int randomPhraseIndex = random.Next(0, phrases.Length - 1);
                int randomEventIndex = random.Next(0, events.Length - 1);
                int randomAuthorIndex = random.Next(0, authors.Length - 1);
                int randomCityIndex = random.Next(0, cities.Length - 1);

                Console.WriteLine($"{phrases[randomPhraseIndex]} {events[randomEventIndex]} {authors[randomAuthorIndex]} - {cities[randomCityIndex]}.");
            }
        }
    }
}