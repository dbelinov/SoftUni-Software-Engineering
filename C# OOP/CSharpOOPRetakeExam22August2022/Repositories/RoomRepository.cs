using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories;

public class RoomRepository : IRepository<IRoom>
{
    private List<IRoom> rooms = new List<IRoom>();

    public void AddNew(IRoom model) => rooms.Add(model);

    public IRoom Select(string roomTypeName) => rooms.FirstOrDefault(r => r.GetType().Name == roomTypeName); //!

    public IReadOnlyCollection<IRoom> All() => rooms.AsReadOnly();
}