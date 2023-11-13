using BirthdayCelebrations.IO.Interfaces;

namespace BirthdayCelebrations.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string text) => Console.WriteLine(text);
}