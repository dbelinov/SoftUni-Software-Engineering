using Vehicles.IO.Interfaces;

namespace Vehicles.IO;

public class Writer : IWriter
{
    public void WriteLine(string text) => Console.WriteLine(text);
}