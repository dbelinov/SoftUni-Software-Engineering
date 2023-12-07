using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories;

public class BookingRepository : IRepository<IBooking>
{
    private List<IBooking> bookings = new List<IBooking>();

    public void AddNew(IBooking model) => bookings.Add(model);

    public IBooking Select(string bookingNumberToString)
        => bookings.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumberToString);

    public IReadOnlyCollection<IBooking> All() => bookings.AsReadOnly();
}