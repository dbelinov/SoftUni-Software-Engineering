using Telephony.Engine;
using Telephony.IO;
using Telephony.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

Engine engine = new Engine(reader, writer);
engine.Run();

