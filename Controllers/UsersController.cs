using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursovaay.Models;
using Kursovaya.Models;
using System.Numerics;
using Microsoft.AspNetCore.Identity;
using Kursovaya.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Kursovaya.Controllers
{
    //[Authorize(Roles = "admin, director")]
    public class UsersController : Controller
    {
        private readonly TravAgenDBContext _context;
        private readonly IWebHostEnvironment _appEnvironment; /*формирования абсолютного пути*/
        private readonly UserManager<KursovayaUser> _userManager;  /*   Для доступа к данным пользователей          */

        public UsersController(TravAgenDBContext context, UserManager<KursovayaUser> userManaher, IWebHostEnvironment
appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _userManager = userManaher;
        }

         


        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.User != null ? 
                          View(await _context.User.ToListAsync()) :
                          Problem("Entity set 'TravAgenDBContext.User'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var user1 = await _context.User /*Обращаемся к класу в контексте*/ 
               .FirstOrDefaultAsync(m => m.UserId == id);  /*ищем его по айди*/

            byte[] photodata = System.IO.File.ReadAllBytes(user1.Photo);

            ViewBag.Photodata = photodata;

            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IFormFile upload)
        {


            //if (ModelState.IsValid) /*введенные пользователем и связанные с моделью, являются достоверными и прошли все проверки валидации.*/
            //{
            //    if (user != null )
            //{
            //    // Генерация уникального имени файла
            //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + user.Photo;

            //    // Определение пути сохранения файла
            //    string filePath = Path.Combine(_appEnvironment.WebRootPath, "uploads", uniqueFileName);

            //    // Сохранение файла на сервере
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await upload.CopyToAsync(stream);
            //    }

            //    // Сохранение пути к файлу в модели клиента
            //    user.Photo = uniqueFileName;

            //        return RedirectToAction(nameof(Index));
            //    }
            //}

            if (ModelState.IsValid)
            {

                string path = upload.FileName;
                string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "uploads");
                string uniqueFileName = upload.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await upload.CopyToAsync(fileStream);
                }

                user.Photo = uniqueFileName;
            

            _context.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



            //if (upload != null)
            //    {
            //        string path = "/Files/" + upload.FileName;
            //        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //        {
            //            await upload.CopyToAsync(fileStream);
            //        }
            //        user.Photo = path;
            //    }
            //    _context.Add(user);
            //    await _context.SaveChangesAsync();/* Он сохраняет изменения в контексте с помощью*/
            //    return RedirectToAction(nameof(Index)); /*Он перенаправляет пользователя к Index действию*/
            //}
            //Он возвращает player объект вместе с необходимыми данными в представление, используя return View(player).
            return View(user);
        }



     


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var user1 = await _context.User /*Обращаемся к класу в контексте*/
               .FirstOrDefaultAsync(m => m.UserId == id);  /*ищем его по айди*/

            byte[] photodata = System.IO.File.ReadAllBytes(user1.Photo);

            ViewBag.Photodata = photodata;



            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user, IFormFile upload)
        {


            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string path = upload.FileName;
                    string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = upload.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await upload.CopyToAsync(fileStream);
                    }
                    //if (!user.Photo.IsNullOrEmpty())
                    //{
                    //    System.IO.File.Delete(_appEnvironment.WebRootPath +
                    //   player.Photo);
                    //}
                    //player.Photo = path;


                    user.Photo = uniqueFileName;


                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'TravAgenDBContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
