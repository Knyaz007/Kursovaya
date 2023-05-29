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
using Kursovaya.Models.VModel;
//using Kursovaya.Models.VModel;

namespace Kursovaya.Controllers
{
    public class ToursController : Controller
    {
        private readonly TravAgenDBContext _context;

        public ToursController(TravAgenDBContext context)
        {
            _context = context;
        }
       

        // GET: Tours
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Tours != null ? 
        //                  View(await _context.Tours.ToListAsync()) :
        //                  Problem("Entity set 'TravAgenDBContext.Tours'  is null.");
        //}

        public async Task<IActionResult> Index()
        {
            var tourViewModels = new List<qwe>();

            var tours = await _context.Tours.Include(t => t.Comments).ToListAsync();

            foreach (var tour in tours)
            {
                var viewModel = new qwe
                {
                    Tour = tour,
                    Comments = tour.Comments
                };

                tourViewModels.Add(viewModel);
            }

            return View(tourViewModels);
        }

        //public IActionResult Details(int id)
        //{
        //    // Retrieve the tour from the database
        //    var tour = _context.Tours.Include(t => t.Comments).FirstOrDefault(t => t.TourId == id);

        //    if (tour == null)
        //    {
        //        return NotFound();
        //    }

        //    // Create the TourViewModel
        //    var viewModel = new qwe
        //    {
        //        Tour = tour,
        //        Comments = tour.Comments
        //    };

        //    return View(viewModel);
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddComment(Comment comment, int? TourId)
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

        [HttpPost]
        public IActionResult AddComment(int IdTour, string Commentary, int Evaluation)
        {
            // Найдите тур в базе данных по его идентификатору
            var tour = _context.Tours.FirstOrDefault(t => t.TourId == IdTour);

            if (tour == null)
            {
                return NotFound(); // Обработка случая, когда тур не найден
            }

            // Создайте новый комментарий
            Comment comment = new Comment
            {
                Commentaryi = Commentary,
                Evaluation = Evaluation,
                IdTour = Evaluation
            };
            _context.Add(comment);
            if (tour.Comments == null)
            {

                List<Comment> comment1 = new List<Comment>
                {
                    comment
                };
                tour.Comments = comment1;
            }
            // Добавьте комментарий к туру
            tour.Comments.Add(comment);

            // Сохраните изменения в базе данных
            //await _context.SaveChangesAsync();
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = IdTour });
        }

        //[HttpPost]
        public IActionResult DeleteComment(int Comment_Id, int tourId)
        {
            // Найдите комментарий в базе данных по его идентификатору
            var comment = _context.Comments.FirstOrDefault(c => c.Comment_Id == Comment_Id);

            if (comment == null)
            {
                return NotFound(); // Обработка случая, когда комментарий не найден
            }

            // Удалите комментарий из базы данных
            _context.Comments.Remove(comment);

            // Сохраните изменения в базе данных
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = tourId });
        }


        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //var tour = await _context.Tours.Include(t => t.Comments).FirstOrDefaultAsync(t => t.TourId == id);

            //if (tour == null)
            //{
            //    return NotFound();
            //}

            //return View(tour);


            var tour = await _context.Tours.Include(t => t.Comments).FirstOrDefaultAsync(t => t.TourId == id);

            if (tour == null)
            {
                return NotFound();
            }

            var viewModel = new qwe 
            {
                Tour = tour,
                Comments = tour.Comments
            };

            return View(viewModel);










            //if (tours != null || _context.Tours != null)
            //{
            //    return NotFound();
            //}
            //foreach (var tour in tours)
            //{
            //    var viewModel = new qwe
            //    {
            //        Tour = tour,
            //        Comments = tour.Comments
            //    };

            //    tourViewModels.Add(viewModel);
            //}




            //if (id == null || _context.Tours == null)
            //{
            //    return NotFound();
            //}

            //var tour = await _context.Tours
            //    .FirstOrDefaultAsync(m => m.TourId == id);
            //if (tour == null)
            //{
            //    return NotFound();
            //}
            //tour = _context.Tours.Include(t => t.Comments).FirstOrDefault(t => t.TourId == id); /*Присваиваем комьентарий*/





            //return View(tourViewModels);
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
