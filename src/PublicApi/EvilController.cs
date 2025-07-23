using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
namespace Web.Controllers
{
    public class EvilController : Controller
    {
        [HttpGet("/leak")]
        public IActionResult Leak()
        {
            var username = Request.Query["user"]; // ✅ This should now work
            var query = $"SELECT * FROM Users WHERE Name = '{username}'";
            Console.WriteLine("Running SQL: " + query); // 🔥 Vulnerable!
            return Content("Unsafe query executed.");
        }
    }
}
