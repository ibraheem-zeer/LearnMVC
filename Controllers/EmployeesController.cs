using LearnMVC.Data;
using LearnMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext dbCon;
        public EmployeesController(AppDbContext context)
        {
            this.dbCon = context;
        }
        public IActionResult Index()
        {
            var emps = dbCon.Employees.AsNoTracking().ToList(); 
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            dbCon.Employees.Add(emp);
            dbCon.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var employee = dbCon.Employees.Find(Id);
            dbCon.Employees.Remove(employee);
            dbCon.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var employee = dbCon.Employees.Find(id);
            return View(employee);
        }

        public IActionResult Update(Employee emp)
        {
            var employee = dbCon.Employees.Find(emp.Id);
            employee.Name = emp.Name;
            employee.Email = emp.Email;
            if(emp.Password != null)
            {
                employee.Password = emp.Password;
            }
            dbCon.SaveChanges();           
            return RedirectToAction("Index");           
        }
    }
}