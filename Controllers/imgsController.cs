using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kursovaya.Models;
using Kursovaay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Numerics;
using static Kursovaya.Controllers.imgsController;

namespace Kursovaya.Controllers
{
    public class imgsController : Controller
    {
        private readonly TravAgenDBContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public imgsController(TravAgenDBContext context, IWebHostEnvironment
appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
       

        // GET: imgs
        public async Task<IActionResult> Index()
        {
            return _context.img != null ?
                          View(await _context.img.ToListAsync()) :
                          Problem("Entity set 'TravAgenDBContext.img'  is null.");
        }

        // GET: imgs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var img1 = await _context.img
                .FirstOrDefaultAsync(m => m.Img_id == id);

            byte[] photodata =System.IO.File.ReadAllBytes(img1.Photo);

             ViewBag.Photodata = photodata;

            if (id == null || _context.img == null)
            {
                return NotFound();
            }

            var img = await _context.img
                .FirstOrDefaultAsync(m => m.Img_id == id);
            if (img == null)
            {
                return NotFound();
            }

            return View(img);
        }

        // GET: imgs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: imgs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(img image, IFormFile upload)
        {

            if (ModelState.IsValid)
            {
                if (upload != null && upload.Length > 0)
                {
                    string path = upload.FileName;
                    string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = upload.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await upload.CopyToAsync(fileStream);
                    }

                    image.Photo = uniqueFileName;
                }

                _context.Add(image);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(image);





//            uploadsFolder - это переменная, которая содержит путь к папке, 
//                в которой будут сохраняться загруженные файлы. Path.Combine используется для объединения пути к корневой папке веб - 
//                приложения(_appEnviron
//                ment.WebRootPath) и подпапки "uploads".Таким образом, uploadsFolder будет содержать полный путь к папке "uploads".

//uniqueFileNameменная, которая генерирует уникальное
//                имя файла для сохранения.Здесь используется<wbr>, чтобы сгенерировать уникальный 
//                    идентификатор в виде строки, а затем этот идентификатор объединяется с исходным
                    
//                    именем загруженного файла (< wbr >) с помощью символа подчеркиванияGuid.NewGuid().ToString()upload.FileNameuniqueFileName будет сод























            //if (ModelState.IsValid)
            //{

            //    if (upload != null)
            //    {
            //        string path = "/Files/" + upload.FileName;
            //        using (var fileStream = new
            //       FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //        {
            //            await upload.CopyToAsync(fileStream);
            //        }
            //        img.Photo = path;
            //    }
            //    _context.Add(img);
            //    await _context.SaveChangesAsync();/* Он сохраняет изменения в контексте с помощью*/
            //    return RedirectToAction(nameof(Index)); /*Он перенаправляет пользователя к Index действию*/


            //    _context.Add(img);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(img);
        }

        // GET: imgs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.img == null)
            {
                return NotFound();
            }

            var img = await _context.img.FindAsync(id);
            if (img == null)
            {
                return NotFound();
            }
            return View(img);
        }

        // POST: imgs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, img img, IFormFile upload)
        {
            if (id != img.Img_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (upload != null && upload.Length > 0)
                {
                    string path = upload.FileName;
                    string uploadsFolder = Path.Combine(_appEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = upload.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await upload.CopyToAsync(fileStream);
                    }

                    img.Photo = uniqueFileName;

                        _context.Update(img);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                }




               
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!imgExists(img.Img_id))
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
            return View(img);
        }

        // GET: imgs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.img == null)
            {
                return NotFound();
            }

            var img = await _context.img
                .FirstOrDefaultAsync(m => m.Img_id == id);
            if (img == null)
            {
                return NotFound();
            }

            return View(img);
        }

        // POST: imgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.img == null)
            {
                return Problem("Entity set 'TravAgenDBContext.img'  is null.");
            }
            var img = await _context.img.FindAsync(id);
            if (img != null)
            {
                _context.img.Remove(img);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool imgExists(int id)
        {
          return (_context.img?.Any(e => e.Img_id == id)).GetValueOrDefault();
        }
    }
}
