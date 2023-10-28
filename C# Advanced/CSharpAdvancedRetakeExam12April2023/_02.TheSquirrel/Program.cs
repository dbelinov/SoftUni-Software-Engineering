/*
5
left, left, up, right, up, up
**h**
t****
*h***
*h*s*
***** 
*/

int collectedHazelnuts = 0;

int size = int.Parse(Console.ReadLine());

char[,] field = new char[size, size];

Queue<string> commands = new(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries));

int squirrelRow = 0;
int squirrelCol = 0;

bool hasSteppedOut = false;
bool hasSteppedOnATrap = false;

for (int row = 0; row < size; row++)
{
    string rowValues = Console.ReadLine();
    for (int col = 0; col < size; col++)
    {
        field[row, col] = rowValues[col];

        if (field[row, col] == 's')
        {
            squirrelRow = row;
            squirrelCol = col;
            field[row, col] = '*';
        }
    }
}

while (collectedHazelnuts < 3 && commands.Count > 0)
{
    string command = commands.Dequeue();

    if (command == "left")
    {
        if (squirrelCol - 1 < 0)
        {
            hasSteppedOut = true;
            break;
        }
        squirrelCol--;
    }
    else if (command == "right")
    {
        if (squirrelCol + 1 >= size)
        {
            hasSteppedOut = true;
            break;
        }
        squirrelCol++;
    }
    else if (command == "down")
    {
        if (squirrelRow + 1 >= size)
        {
            hasSteppedOut = true;
            break;
        }
        squirrelRow++;
    }
    else if (command == "up")
    {
        if (squirrelRow - 1 < 0)
        {
            hasSteppedOut = true;
            break;
        }
        squirrelRow--;
    }

    if (field[squirrelRow, squirrelCol] == 'h')
    {
        collectedHazelnuts++;
        field[squirrelRow, squirrelCol] = '*';
    }

    if (field[squirrelRow, squirrelCol] == 't')
    {
        hasSteppedOnATrap = true;
        break;
    }
}

if (hasSteppedOut)
{
    Console.WriteLine("The squirrel is out of the field.");
}

if (hasSteppedOnATrap)
{
    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
}

if (collectedHazelnuts < 3 && !hasSteppedOnATrap && !hasSteppedOut)
{
    Console.WriteLine("There are more hazelnuts to collect.");
}
else if(collectedHazelnuts == 3)
{
    Console.WriteLine("Good job! You have collected all hazelnuts!");
}

Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");