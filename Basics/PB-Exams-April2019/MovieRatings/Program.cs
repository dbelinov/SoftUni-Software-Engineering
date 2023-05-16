using System;

namespace MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int movies = int.Parse(Console.ReadLine());

            double allRatings = 0;
            double highestRating = double.MinValue;
            string highestRatedMovie = "";
            double lowestRating = Double.MaxValue;
            string lowestRatedMovie = "";
            
            for (int i = 1; i <= movies; i++)
            {
                string movieName = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                allRatings += rating;

                if (rating > highestRating)
                {
                    highestRating = rating;
                    highestRatedMovie = movieName;
                }

                if (rating < lowestRating)
                {
                    lowestRating = rating;
                    lowestRatedMovie = movieName;
                }
            }

            double averageRating = allRatings / movies;

            Console.WriteLine($"{highestRatedMovie} is with highest rating: {highestRating:f1}");
            Console.WriteLine($"{lowestRatedMovie} is with lowest rating: {lowestRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}