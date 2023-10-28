using System.Threading.Channels;

Queue<int> monsters = new(Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
    
Stack<int> soldiers = new(Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

int monstersKilled = 0;

while (soldiers.Count > 0 && monsters.Count > 0)
{
    int currentMonster = monsters.Dequeue();
    int currentSoldier = soldiers.Pop();

    if (currentSoldier >= currentMonster)
    {
        monstersKilled++;
        currentSoldier -= currentMonster;
        
        if (soldiers.Count > 0)
        {
            int nextSoldier = soldiers.Pop();
            nextSoldier += currentSoldier;
            soldiers.Push(nextSoldier);
        }
        else
        {
            if (currentSoldier > 0)
            {
                soldiers.Push(currentSoldier);
            }
        }
    }
    else
    {
        currentMonster -= currentSoldier;
        monsters.Enqueue(currentMonster);
    }
}

if (monsters.Count == 0)
{
    Console.WriteLine("All monsters have been killed!");
}

if (soldiers.Count == 0)
{
    Console.WriteLine($"The soldier has been defeated.");
}

Console.WriteLine($"Total monsters killed: {monstersKilled}");