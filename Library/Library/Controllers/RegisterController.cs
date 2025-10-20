using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Data;

namespace Library.Controllers
{
    public class RegisterController : Controller
    {
        private readonly LibraryContext _context;

        public RegisterController(LibraryContext context)
        {
            _context = context;
        }

        // GET: /Register/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Register/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("Name,Email,Phone,Password")] User user)
        {
            if (_context.Users.Any(u=>u.Name == user.Name))
            {
                ModelState.AddModelError("Name", "This username is already taken");
            }
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered.");
            }

            if (ModelState.IsValid)
            {
                user.Password = HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            return View(user);
        }

        private string HashPassword(string password)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var sb = new System.Text.StringBuilder();
                foreach (var b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
