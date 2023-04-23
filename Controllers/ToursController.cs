using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursovaya.Models;
using System.Numerics;
using Kursovaya.Models.ViewModels;

namespace Kursovaya.Controllers
{
    public class ToursController : Controller
    {
        private readonly TravAgenDBContext _context;

        public ToursController(TravAgenDBContext context)
        {
            _context = context;
        }




        /// <summary>
        public IActionResult AddPlayerToTeam(int id)
        {
            ViewBag.ToursId = id;
            return View(_context.Customers.Where(p => p.ToursId == null));
        }

        [HttpPost]
        public async Task<IActionResult> AddPlayerToTeam(int ToursId, int CustomersId)
        {
            Customers customer = _context.Customers.Find(CustomersId);
            customer.ToursId = ToursId;
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = ToursId });
        }
        /// </summary>
        /// <returns></returns>
        // GET: Tours
        public async Task<IActionResult> Index()
        {
              return _context.Tours != null ? 
                          View(await _context.Tours.ToListAsync()) :
                          Problem("Entity set 'TravAgenDBContext.Tours'  is null.");
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours  /*находит тур по  и отправляет на представление*/
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tours == null)
            {
                return NotFound();
            }
            TeamDetailsViewModel viewModel = new TeamDetailsViewModel();/// создаем новый обьект который передадим в прдеставление
            viewModel.Tour = tours;//// Заполняем его 
            viewModel.Customers = _context.Customers.Where(p => p.ToursId == tours.ID);/// Добавляем покупателей в его сисок 
            return View(viewModel);
        }

        //// GET: Tours/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Tours == null)
        //    {
        //        return NotFound();
        //    }

        //    var tours = await _context.Tours
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (tours == null)
        //    {
        //        return NotFound();
        //    }
        //    TeamDetailsViewModel viewModel = new TeamDetailsViewModel();/// чТО ЭТО
        //    viewModel.Tour = tours;//// ПРИСВАЕВЫАЕМ 
        //    viewModel.Customers = _context.Customers.Where(p => p.ToursId == tours.ID);///
        //    return View(tours);
        //}

        // GET: Tours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,tour_start_date,end_date_of_the_tour,type_of_tour,type_of_power_supply,hotel,departure_flight,arrival_flight")] Tours tours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tours);
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours.FindAsync(id);
            if (tours == null)
            {
                return NotFound();
            }
            return View(tours);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,tour_start_date,end_date_of_the_tour,type_of_tour,type_of_power_supply,hotel,departure_flight,arrival_flight")] Tours tours)
        {
            if (id != tours.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToursExists(tours.ID))
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
            return View(tours);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tours == null)
            {
                return NotFound();
            }

            return View(tours);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tours == null)
            {
                return Problem("Entity set 'TravAgenDBContext.Tours'  is null.");
            }
            var tours = await _context.Tours.FindAsync(id);
            if (tours != null)
            {
                _context.Tours.Remove(tours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToursExists(int id)
        {
          return (_context.Tours?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
