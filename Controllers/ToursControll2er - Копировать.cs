using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursovaay.Models;
using Kursovaya.Models;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;
//using Kursovaya.Models.VModel;

namespace Kursovaya.Controllers
{
    public class ToursController2 : Controller
    {
        private readonly TravAgenDBContext _context;

        public ToursController2(TravAgenDBContext context)
        {
            _context = context;
        }
       

        // GET: Tours
        public async Task<IActionResult> Index()
        {
              return _context.Tours != null ? 
                          View(await _context.Tours.ToListAsync()) :
                          Problem("Entity set 'TravAgenDBContext.Tours'  is null.");
        }



        [HttpPost]
     

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddComment(Comment comment,int? TourId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Details", new { id = comment.IdTour });
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var tour = _context.Tours
        //            .Include(t => t.Comments)
        //            .FirstOrDefault(t => t.TourId == comment.IdTour);

        //        if (tour != null)
        //        {
        //            tour.AddComment(comment);
        //            await _context.SaveChangesAsync();
        //        }

        //        return RedirectToAction("Details", new { id = comment.IdTour });
        //    }

        //    // Обработка недопустимых данных комментария
        //    return View("Details", new { id = comment.IdTour });
        //    //return RedirectToAction("Index");
        //}










        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {



            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }
            tour = _context.Tours.Include(t => t.Comments).FirstOrDefault(t => t.TourId == id); /*Присваиваем комьентарий*/





            return View(tour);
        }


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
        public async Task<IActionResult> Create(Tour tour)
        {
            if (ModelState.IsValid)
            {

                _context.Add(tour);
               

                //// Добавление комментариев к туру
                //foreach (var comment in tour.Comments)
                //{
                //    comment.IdTour = tour.TourId;
                //    _context.Comments.Add(comment);
                //}

                await _context.SaveChangesAsync();


                //_context.Comments.Add(comment);
                //await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourId,Name,Description,Price,StartDate,EndDate,AvailableSpots")] Tour tour)
        {
            if (id != tour.TourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.TourId))
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
            return View(tour);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tours == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
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
            var tour = await _context.Tours.FindAsync(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
          return (_context.Tours?.Any(e => e.TourId == id)).GetValueOrDefault();
        }
    }
}
