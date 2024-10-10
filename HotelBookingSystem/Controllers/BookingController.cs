using Microsoft.AspNetCore.Mvc;

public class BookingController : Controller
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public IActionResult BookRoom(int roomId, string customerName, DateTime checkOutDate)
    {
        var room = _bookingService.GetRoom(roomId);
        var customer = new Customer { Name = customerName };

        _bookingService.BookRoom(room, customer, checkOutDate);

        return RedirectToAction("BookingHistory", new { customerName });
    }

    public IActionResult BookingHistory(string customerName)
    {
        var history = _bookingService.GetBookingHistory(customerName);
        return View(history);
    }
}
