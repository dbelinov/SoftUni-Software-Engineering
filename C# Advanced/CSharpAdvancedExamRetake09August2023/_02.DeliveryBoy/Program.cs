int[] sizes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = sizes[0];
int cols = sizes[1];

char[,] field = new Char[rows, cols];

int initialRow = 0;
int initialCol = 0;

int boyRow = 0;
int boyCol = 0;

bool hasLeft = false;

for (int row = 0; row < rows; row++)
{
    string rowValues = Console.ReadLine();
    for (int col = 0; col < cols; col++)
    {
        field[row, col] = rowValues[col];

        if (field[row, col] == 'B')
        {
            boyRow = row;
            boyCol = col;
            initialRow = row;
            initialCol = col;
            field[row, col] = '.';
        }
    }
}

while (true)
{
    string command = Console.ReadLine();

    if (command == "up")
    {
        if (boyRow - 1 < 0)
        {
            Console.WriteLine("The delivery is late. Order is canceled.");
            hasLeft = true;
            break;
        }
        
        if (field[boyRow - 1, boyCol] != '*')
        {
            boyRow--;
        }
    }
    else if (command == "down")
    {
        if (boyRow + 1 >= rows)
        {
            Console.WriteLine("The delivery is late. Order is canceled.");
            hasLeft = true;
            break;
        }
        
        if (field[boyRow + 1, boyCol] != '*')
        {
            boyRow++;
        }
    }
    else if (command == "right")
    {
        if (boyCol + 1 >= cols)
        {
            Console.WriteLine("The delivery is late. Order is canceled.");
            hasLeft = true;
            break;
        }
        
        if (field[boyRow, boyCol + 1] != '*')
        {
            boyCol++;
        }
    }
    else if (command == "left")
    {
        if (boyCol - 1 < 0)
        {
            Console.WriteLine("The delivery is late. Order is canceled.");
            hasLeft = true;
            break;
        }
        
        if (field[boyRow, boyCol - 1] != '*')
        {
            boyCol--;
        }
    }

    if (field[boyRow, boyCol] == '-')
    {
        field[boyRow, boyCol] = '.';
    }
    else if (field[boyRow, boyCol] == 'P')
    {
        field[boyRow, boyCol] = 'R';
        Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
    }
    else if (field[boyRow, boyCol] == 'A')
    {
        field[boyRow, boyCol] = 'P';
        Console.WriteLine("Pizza is delivered on time! Next order...");
        break;
    }
}

boyRow = initialRow;
boyCol = initialCol;

if (hasLeft)
{
    field[boyRow, boyCol] = ' ';
}
else
{
    field[boyRow, boyCol] = 'B';
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write(field[row,col]);
    }

    Console.WriteLine();
}