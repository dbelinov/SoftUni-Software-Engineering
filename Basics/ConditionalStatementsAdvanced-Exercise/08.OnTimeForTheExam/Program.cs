using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examNorm = examHour * 60 + examMinutes;
            int arrivalNorm = arrivalHour * 60 + arrivalMinutes;
            string output = "";
            string keyword = "";
            int differenceHours = 0;
            int differenceMinutes = 0;


            if(arrivalNorm > examNorm)
            {
                output = "Late";
                keyword = "after";
            }
            else if (arrivalNorm < examNorm)
            {
                if (examNorm - arrivalNorm > 30)
                {
                    output = "Early";
                    keyword = "before";
                }
                else
                {
                    output = "On time";
                    keyword = "before";
                }
            }
            else if (arrivalNorm == examNorm)
            {
                output = "On time";
            }
            int difference = Math.Abs(arrivalNorm - examNorm);

            if (difference >= 60)
            {
                differenceHours = difference / 60;
                differenceMinutes = difference % 60;
            }

            Console.WriteLine($"{output}");
            if(differenceHours > 0 && arrivalNorm != examNorm)
            {
                if(differenceMinutes < 10)
                {
                    Console.WriteLine($"{differenceHours}:0{differenceMinutes} hours {keyword} the start");
                }
                else
                {
                    Console.WriteLine($"{differenceHours}:{differenceMinutes} hours {keyword} the start");
                }   
            }
            else if (arrivalNorm != examNorm)
            {
                Console.WriteLine($"{difference} minutes {keyword} the start");
            }
        }
    }
}
