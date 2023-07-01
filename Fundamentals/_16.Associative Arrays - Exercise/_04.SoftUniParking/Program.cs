using System;
using System.Collections.Generic;
using System.Linq;
/*
5
register John CS1234JS
register George JAVA123S
register Andy AB4142CD
register Jesica VR1223EE
unregister Andy
*/
namespace _04.SoftUniParking
{
    class User
    {
        public User(string name, string licensePlate)
        {
            Name = name;
            LicensePlate = licensePlate;
        }

        public string Name { get; set; }
        public string LicensePlate { get; set; }

        public override string ToString()
        {
            return $"{Name} => {LicensePlate}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> database = new Dictionary<string, User>();
            int commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string name = tokens[1];
                
                switch (command)
                {
                    case "register":
                        string licensePlate = tokens[2];
                        if (!database.ContainsKey(name))
                        {
                            User user = new User(name, licensePlate);
                            database.Add(name, user);
                            Console.WriteLine($"{name} registered {licensePlate} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {database[name].LicensePlate}");
                        }
                        break;
                    case "unregister":
                        if (!database.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        else
                        {
                            database.Remove(name);
                            Console.WriteLine($"{name} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var user in database.Values)
            {
                Console.WriteLine(user);
            }
        }
    }
}