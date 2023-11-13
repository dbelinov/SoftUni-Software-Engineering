using BirthdayCelebrations.Engine;
using BirthdayCelebrations.IO;
using BirthdayCelebrations.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

Engine engine = new(reader, writer);
engine.Run();