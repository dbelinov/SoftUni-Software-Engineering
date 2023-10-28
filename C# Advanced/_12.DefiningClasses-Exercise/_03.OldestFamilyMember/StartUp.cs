namespace DefiningClasses;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Family family = new Family();
        
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int age = int.Parse(tokens[1]);
            Person person = new Person(tokens[0], age);
            
            family.AddMember(person);
        }

        Console.WriteLine(family.GetOldestMember());
    }
}