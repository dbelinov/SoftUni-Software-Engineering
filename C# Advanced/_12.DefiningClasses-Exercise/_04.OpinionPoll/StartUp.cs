namespace DefiningClasses;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> olderThan30 = new List<Person>();
        
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int age = int.Parse(tokens[1]);

            Person person = new Person(tokens[0], age);
            
            if (person.Age > 30)
            {
                olderThan30.Add(person);
            }
        }

        olderThan30 = olderThan30.OrderBy(p => p.Name).ToList();

        foreach (var person in olderThan30)
        {
            Console.WriteLine(person);
        }
    }
}

