using Telephony.IO.Interfaces;

namespace Telephony.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string text) => Console.WriteLine(text);
}