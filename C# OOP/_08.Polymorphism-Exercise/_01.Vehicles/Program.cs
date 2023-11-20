using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;

IWriter writer = new Writer();
IReader reader = new Reader();
IVehicleFactory factory = new VehicleFactory();

Engine engine = new(reader, writer, factory);
engine.Run();