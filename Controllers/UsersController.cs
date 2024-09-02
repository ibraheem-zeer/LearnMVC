using LearnMVC.Data;
using LearnMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext context;
        public UsersController(AppDbContext context)
        {
            this.context = context;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User usr)
        {
            context.Users.Add(usr);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUser = context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password);

            if(checkUser.Any()) return RedirectToAction("Index", "Employees");

            ViewBag.Error = "Invalid username or password";
            return View(user);

        }
    
    }
}
