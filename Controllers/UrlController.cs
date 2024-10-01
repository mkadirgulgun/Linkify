using Linkify.Data;
using Linkify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Linkify.Controllers
{
    public class UrlController : Controller
    {
        private readonly AppDbContext _context;

        public UrlController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Linkify()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Linkify(string originalUrl)
        {
            string shortUrl = GenerateRandomString(6);

            string fullUrl = $"https://linkify.mkadirgulgun.com.tr/{shortUrl}";

            var url = new Url()
            {
                OriginalUrl = originalUrl,
                ShortUrl = shortUrl
            };

            _context.Urls.Add(url);
            _context.SaveChanges();

            ViewBag.FullUrl = fullUrl;
            ViewBag.ShortUrl = shortUrl;            
            return View("NewUrl");
        }
        public IActionResult RedirectToOriginal(string shortLink)
        {
            var url = _context.Urls.FirstOrDefault(u => u.ShortUrl == shortLink);

            if (url == null)
            {
                return BadRequest();
            }

            return Redirect(url.OriginalUrl);
        }
        private string GenerateRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz-0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public IActionResult NewUrl()
        {
            return View();
        }
    }
}
