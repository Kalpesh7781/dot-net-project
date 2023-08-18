using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carrentalapp.Data;
using carrentalapp.Model;

namespace carrentalapp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            return await _context.Bookings.Include(a=>a.user).Include(b=>b.car).ToListAsync();
        }


        // GET: api/Bookings1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(long id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'AppDbContext.Bookings'  is null.");
            }
            else
            {

                var c = await _context.Cars.FindAsync(booking.car_id);
                c.car_status = "Booked";
                _context.Entry(c).State = EntityState.Modified;


                await _context.SaveChangesAsync();
            }
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = booking.booking_id }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(long id)
        {
            if (_context.Bookings == null)
            {
                return NotFound();
            }
            var booking = await _context.Bookings.FindAsync(id);

            var c = await _context.Cars.FindAsync(booking.car_id);
            c.car_status = "Avail";
            _context.Entry(c).State = EntityState.Modified;

            var book = await _context.Bookings.FindAsync(id);
            Cancel c1 = new Cancel();
            c1.booking_id = book.booking_id;
            c1.ammt = book.ammt;
            c1.rentalDate = book.rentalDate;
            c1.returndate = book.returndate;
            c1.car = book.car;
            c1.user = book.user;
            c1.car_id = book.car_id;
            c1.user_no = book.user_no;
           
            if (booking == null)
            {
                return NotFound();
            }
            _context.Cancels.Add(c1);
            await _context.SaveChangesAsync();
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(long id)
        {
            return (_context.Bookings?.Any(e => e.booking_id == id)).GetValueOrDefault();
        }
    }
}
