using System;
using System.Xml.Schema;

namespace _02.Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int doctors = 7;
            int checkedPatients = 0;
            int uncheckedPatients = 0;
            int totalChecked = 0;
            int totalUnchecked = 0;

            for (int day = 1; day <= period; day++)
            {
                int patientsForTheDay = int.Parse(Console.ReadLine());
                if (day % 3 == 0)
                {
                    if (totalUnchecked > totalChecked)
                    {
                        doctors++;
                    }
                }

                if (patientsForTheDay >= doctors)
                {
                    checkedPatients = doctors;
                }
                else
                {
                    checkedPatients = patientsForTheDay;
                }
     
                    uncheckedPatients = patientsForTheDay - checkedPatients;
                
                totalChecked += checkedPatients;
                totalUnchecked += uncheckedPatients;

            }

            Console.WriteLine($"Treated patients: {totalChecked}.");
            Console.WriteLine($"Untreated patients: {totalUnchecked}.");
        }
    }
}
