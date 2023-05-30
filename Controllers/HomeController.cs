using Kursovaya.Areas.Identity.Data;
using Kursovaya.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Kursovaya.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;


namespace Kursovaya.Controllers
{

    //[Authorize]
    public class HomeController : Controller
    {
        public IActionResult ActionName()
        {
            // Получение данных пользователя из TempData
            var user = TempData["UserData"] as KursovayaUser; // Замените "KursovayaUser" на ваш класс пользователя

            if (user != null)
            {
                // Используйте данные пользователя по вашему усмотрению
                // ...

                // Очистите TempData после использования, если требуется
                TempData.Clear();
            }

            return View();
        }

        public IActionResult Feedback()
        {
        

            return View("Feedback");
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}