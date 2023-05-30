using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursovaay.Models;
using Kursovaya.Models;
using Kursovaya.Models.VModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Kursovaya.Controllers
{
    [Authorize(Roles = "admin, director")]
    public class BookingsController : Controller
    {
        private readonly TravAgenDBContext _context;

        public BookingsController(TravAgenDBContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var travAgenDBContext = _context.Bookings.Include(b => b.Flight).Include(b => b.Hotel).Include(b => b.Tour).Include(b => b.User);
            return View(await travAgenDBContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Hotel)
                .Include(b => b.Tour)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["FlightId"] = new SelectList(_context.Flights, "Flight_Id", "Flight_Id");
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id");
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "Flight_Id", "Flight_Id", booking.FlightId);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id", booking.HotelId);
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId", booking.TourId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", booking.UserId);
            return View(booking);
        }
       
        public async Task<IActionResult> AddBooking(Booking booking)
        {

            var viewModel = new AddBoooking
            {
                Booking = booking,
                Tours = await _context.Tours.ToListAsync()    //

                };

            ViewBag.addBoooking = viewModel;



            return View("1AddTourInBooking", viewModel );  
            //RedirectToAction("AddBookingANDUser", new { addBoooking = viewModel });
            
            
            //return RedirectToAction("AddBookingANDUser");


            //return RedirectToAction("AddBookingANDUser");


            //return RedirectToAction("AddTourInBooking"); возвращает перенаправление на действие AddTourInBooking в том же контроллере, который выполняет текущую операцию.




        }
        
        public async Task<IActionResult> AddBookingANDUser(AddBoooking addBoooking, int Tour_Id) // choce Выбрать
        {
            

            var tour = _context.Tours.Include(t => t.Comments).FirstOrDefault(t => t.TourId == Tour_Id);
            addBoooking.Tour = tour;
            addBoooking.Users = await _context.Users.ToListAsync();

            
            return View("2AddUserInBooking",  addBoooking );


             
        }

        public async Task<IActionResult> AddBookingANDUserCreateTourForBokking(Booking booking) // Создаем тур Если его нет при бронирование --Заглушим
        {

            var viewModel = new AddBoooking
            {
                Booking = booking,
                Tours = await _context.Tours.ToListAsync()

            };



            //var tourViewModels = new List<qwe>();

            //var tours = await _context.Tours.Include(t => t.Comments).ToListAsync();

            //foreach (var tour in tours)
            //{
            //    var viewModel = new qwe
            //    {
            //        Tour = tour,
            //        Comments = tour.Comments
            //    };

            //    tourViewModels.Add(viewModel);
            //}

            //return View(tourViewModels);

            return RedirectToAction("AddTourInBooking", new { viewModel });


            ////return View(_context.Players.Where(p => p.TeamId == null));




            //return RedirectToAction(nameof(AddTourInBooking));
        }


        public async Task<IActionResult> AddBookingANDUserANDHotel(AddBoooking addBoooking, int Tour_Id, int UserId)
        {
            var user = _context.Users.FirstOrDefault(t => t.UserId == UserId);
            var tour = _context.Tours.FirstOrDefault(t => t.TourId == Tour_Id);

            addBoooking.User = user;
            addBoooking.Tour = tour;

            addBoooking.Hotels = await _context.Hotels.ToListAsync();


            //ViewBag.addBoooking.User = user;


            ////ViewBag.addBoooking.User = user;
            //ViewBag.User = User;
            //Tour rr = ViewBag.Tour;


            return View("3AddHotelInBooking", addBoooking);


            //return View(_context.Players.Where(p => p.TeamId == null));

        }
        public async Task<IActionResult> AddBookingANDFlight(AddBoooking addBoooking, int Tour_Id, int UserId, int HotelId)
        {
            var hotel = _context.Hotels.FirstOrDefault(t => t.Id == HotelId);
            var user = _context.Users.FirstOrDefault(t => t.UserId == UserId);
            var tour = _context.Tours.FirstOrDefault(t => t.TourId == Tour_Id);

            addBoooking.Hotel = hotel;
            addBoooking.User = user;
            addBoooking.Tour = tour;

            addBoooking.Flights = await _context.Flights.ToListAsync();


            
            return View("4AddFlightInBooking", addBoooking);


            //return View(_context.Players.Where(p => p.TeamId == null));

        }
        public async Task<IActionResult> AddBookingEnd(AddBoooking addBoooking, int Tour_Id, int UserId, int HotelId, int Flight_Id)
        {
            var flight = _context.Flights.FirstOrDefault(t => t.Flight_Id == Flight_Id);
            var hotel = _context.Hotels.FirstOrDefault(t => t.Id == HotelId);
            var user = _context.Users.FirstOrDefault(t => t.UserId == UserId);
            var tour = _context.Tours.FirstOrDefault(t => t.TourId == Tour_Id);

            addBoooking.Hotel = hotel;
            addBoooking.User = user;
            addBoooking.Tour = tour;
            addBoooking.Flight = flight;



            //addBoooking.Flight = flight;

            //ViewBag.addBoooking.flight = flight;


            //var tourViewModels = new List<Booking>();

            //var tours = await _context.Tours.Include(t => t.Comments).ToListAsync();

            var viewModel1 = new Booking
            {
                 Tour = addBoooking.Tour,
                 User = addBoooking.User,
                 Hotel = addBoooking.Hotel,
                 Flight = addBoooking.Flight,

                 TourId = addBoooking.Tour.TourId,
                 UserId = addBoooking.User.UserId,
                 HotelId = addBoooking.Hotel.Id,
                 FlightId = addBoooking.Flight.Flight_Id,
                 ParticipantsCount= 1,
                 BookingDate = DateTime.Now

             };
            _context.Bookings.Add(viewModel1);
        

               await _context.SaveChangesAsync();



            //var travAgenDBContext = _context.Bookings.Include(b => b.Flight).Include(b => b.Hotel).Include(b => b.Tour).Include(b => b.User);





            //return View("Index", travAgenDBContext);

            return RedirectToAction(nameof(Index));
            //return View("Index");

            //return View(_context.Players.Where(p => p.TeamId == null));

        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "Flight_Id", "Flight_Id", booking.FlightId);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id", booking.HotelId);
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId", booking.TourId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", booking.UserId);
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", booking.UserId); /*- поковырятся если время будет(напротив Id будет почта))*/
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,TourId,UserId,FlightId,HotelId,ParticipantsCount,BookingDate,IsConfirmed")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.Flights, "Flight_Id", "Flight_Id", booking.FlightId);
            ViewData["HotelId"] = new SelectList(_context.Hotels, "Id", "Id", booking.HotelId);
            ViewData["TourId"] = new SelectList(_context.Tours, "TourId", "TourId", booking.TourId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", booking.UserId);
            //ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.Hotel)
                .Include(b => b.Tour)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'TravAgenDBContext.Bookings'  is null.");
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.Bookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
