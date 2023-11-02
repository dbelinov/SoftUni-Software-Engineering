namespace PersonsInfo;

/*
5
Andrew Williams -6 2200
B Gomez 57 3333
Carolina Richards 27 670
Gilbert H 44 666,66
Joshua Anderson 35 300
20
*/

public class StartUp
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            try
            {
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]));
                    persons.Add(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        var parcentage = decimal.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(parcentage));
        persons.ForEach(p => Console.WriteLine(p.ToString()));

    }
}