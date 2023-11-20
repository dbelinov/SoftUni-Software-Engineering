using Vehicles.Core;
using Vehicles.IO;
using Vehicles.IO.Interfaces;

IWriter writer = new Writer();
IReader reader = new Reader();

Engine engine = new(writer, reader);
engine.Run();