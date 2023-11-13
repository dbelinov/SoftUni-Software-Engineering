using BorderControl.Engine;
using BorderControl.IO;
using BorderControl.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

Engine engine = new(reader, writer);
engine.Run();