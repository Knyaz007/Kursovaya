﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursovaay.Models;
using Kursovaya.Models;
using System.Numerics;

namespace Kursovaya.Controllers
{
    public class UsersController : Controller
    {
        private readonly TravAgenDBContext _context;
        private readonly IWebHostEnvironment _appEnvironment; /*формирования абсолютного пути*/


        public UsersController(TravAgenDBContext context, IWebHostEnvironment
appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> Create( User user, IFormFile upload)
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
                if (upload != null)
                {
                    string path = "/Files/" + upload.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await upload.CopyToAsync(fileStream);
                    }
                    user.Photo = path;
                }
                _context.Add(user);
                await _context.SaveChangesAsync();/* Он сохраняет изменения в контексте с помощью*/
                return RedirectToAction(nameof(Index)); /*Он перенаправляет пользователя к Index действию*/
            }
            //Он возвращает player объект вместе с необходимыми данными в представление, используя return View(player).
            return View(user);
        }



     


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,LastName,Year,Email,Phone,Photo,IsAdmin")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
