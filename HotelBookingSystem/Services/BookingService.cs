using HotelBookingSystem.Models;

public class BookingService : IRoomBooking
{
    private readonly HotelDbContext _context;

    public BookingService(HotelDbContext context)
    {
        _context = context;
    }

    public void BookRoom(Room room, Customer customer, DateTime checkOutDate)
    {
        room.BookRoom();

        var booking = new Booking
        {
            RoomId = room.Id,
            CustomerName = customer.Name,
            BookingDate = DateTime.Now,
            CheckOutDate = checkOutDate
        };

        _context.Bookings.Add(booking);
        _context.SaveChanges();
    }

    public void ReleaseRoom(Room room)
    {
        room.ReleaseRoom();
        _context.SaveChanges();
    }

    public Room GetRoom(int roomId)
    {
        return _context.Rooms.SingleOrDefault(room => room.Id == roomId);
    }

    public List<Booking> GetBookingHistory(string customerName)
    {
        return _context.Bookings
            .Where(b => b.CustomerName == customerName)
            .ToList();
    }
}
