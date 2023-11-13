using FoodShortage.Engine;
using FoodShortage.IO;
using FoodShortage.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

Engine engine = new(reader, writer);
engine.Run();