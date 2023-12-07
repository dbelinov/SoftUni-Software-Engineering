using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core;

public class Controller : IController
{
    private IRepository<IHotel> hotels = new HotelRepository();
    
    public string AddHotel(string hotelName, int category)
    {
        if (hotels.Select(hotelName) != default)
        {
            return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
        }

        Hotel hotel = new Hotel(hotelName, category);
        hotels.AddNew(hotel);
        return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
    }

    public string UploadRoomTypes(string hotelName, string roomTypeName)
    {
        IHotel hotel = hotels.Select(hotelName);
        if (hotel == default)
        {
            return string.Format(OutputMessages.HotelNameInvalid, hotelName);
        }

        if (hotel.Rooms.Select(roomTypeName) != default)
        {
            return OutputMessages.RoomTypeAlreadyCreated;
        }

        if (roomTypeName is not "Apartment" and not "DoubleBed" and not "Studio")
        {
            throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }

        IRoom room;
        if (roomTypeName == "Apartment")
        {
            room = new Apartment();
        }
        else if (roomTypeName == "DoubleBed")
        {
            room = new DoubleBed();
        }
        else 
        {
            room = new Studio();
        }
        
        hotel.Rooms.AddNew(room);
        return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
    }

    public string SetRoomPrices(string hotelName, string roomTypeName, double price)
    {
        IHotel hotel = hotels.Select(hotelName);
        if (hotel == default)
        {
            return string.Format(OutputMessages.HotelNameInvalid, hotelName);
        }
        
        if (roomTypeName is not "Apartment" and not "DoubleBed" and not "Studio")
        {
            throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }

        IRoom room = hotel.Rooms.Select(roomTypeName);
        if (room == default)
        {
            return OutputMessages.RoomTypeNotCreated;
        }

        if (room.PricePerNight > 0)
        {
            throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
        }
        
        room.SetPrice(price);
        return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
    }

    public string BookAvailableRoom(int adults, int children, int duration, int category)
    {
        var orderedHotels = hotels.All().OrderBy(h => h.FullName);

        List<IRoom> rooms = new List<IRoom>();
        foreach (IHotel hotel in orderedHotels)
        {
            foreach (IRoom room in hotel.Rooms.All())
            {
                if (room.PricePerNight > 0)
                {
                    rooms.Add(room);
                }
            }
        }

        rooms = rooms.OrderBy(r => r.BedCapacity).ToList();

        IRoom foundRoom = rooms.FirstOrDefault(r => r.BedCapacity >= adults + children);

        IHotel foundHotel = hotels.All().FirstOrDefault(h => h.Category == category);
        if (foundHotel == default)
        {
            return string.Format(OutputMessages.CategoryInvalid, category);
        }

        if (foundRoom == default)
        {
            return OutputMessages.RoomNotAppropriate;
        }

        int bookingNumber = foundHotel.Bookings.All().Count + 1;
        IBooking booking = new Booking(foundRoom, duration, adults, children, bookingNumber);
        foundHotel.Bookings.AddNew(booking);
        
        return string.Format(OutputMessages.BookingSuccessful, bookingNumber, foundHotel.FullName);
    }

    public string HotelReport(string hotelName)
    {
        IHotel hotel = hotels.Select(hotelName);
        if (hotel == default)
        {
            return string.Format(OutputMessages.HotelNameInvalid, hotelName);
        }
        
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Hotel name: {hotel.FullName}");
        sb.AppendLine($"--{hotel.Category} star hotel");
        sb.AppendLine($"-Turnover: {hotel.Turnover:F2} $");
        sb.AppendLine("--Bookings:");
        sb.AppendLine();
        
        if (hotel.Bookings.All().Count == 0)
        {
            sb.AppendLine("none");
        }
        else
        {
            foreach (IBooking booking in hotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
                sb.AppendLine();
            }
        }

        return sb.ToString().Trim();
    }
}