Queue<int> programmerTimes = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
    
Stack<int> tasks = new(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

const int maxTime = 240;

int darthVaderDuckies = 0;
int thorDuckies = 0;
int bigBlueRubberDuckies = 0;
int smallYellowRubberDuckies = 0;

while (programmerTimes.Count > 0 || tasks.Count > 0)
{
    int currentTime = programmerTimes.Dequeue();
    int currentTask = tasks.Pop();

    int time = currentTime * currentTask;

    if (time > maxTime)
    {
        currentTask -= 2;
        tasks.Push(currentTask);
        programmerTimes.Enqueue(currentTime);
        continue;
    }

    if (time >= 0 && time <= 60)
    {
        darthVaderDuckies++;
    }
    else if (time >= 61 && time <= 120)
    {
        thorDuckies++;
    }
    else if (time >= 121 && time <= 180)
    {
        bigBlueRubberDuckies++;
    }
    else if (time >= 181)
    {
        smallYellowRubberDuckies++;
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
Console.WriteLine($"Darth Vader Ducky: {darthVaderDuckies}");
Console.WriteLine($"Thor Ducky: {thorDuckies}");
Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueRubberDuckies}");
Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowRubberDuckies}");