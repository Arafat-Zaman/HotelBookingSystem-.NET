using HotelBookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HotelController : Controller
{
    private readonly HotelDbContext _context;

    public HotelController(HotelDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var hotels = _context.Hotels.Include(h => h.Rooms).ToList();
        return View(hotels);
    }

    public IActionResult Details(int id)
    {
        var hotel = _context.Hotels.Include(h => h.Rooms)
                      .FirstOrDefault(h => h.Id == id);

        if (hotel == null)
            return NotFound();

        return View(hotel);
    }
}
