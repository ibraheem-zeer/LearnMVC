using LearnMVC.Data;
using LearnMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnMVC.Controllers
{
    public class EmployeesController : Controller
    {
        AppDbContext dbCon = new AppDbContext();
        public IActionResult Index()
        {
            var emps = dbCon.Employees.ToList();
            emps.ForEach(e => Console.WriteLine(e.Name));
            return View(emps);
            //return View("Index",emps);
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
            employee.Password = emp.Password;

            dbCon.SaveChanges();

            return Content($"{employee.Name} .... {employee.Email} .... {employee.Password}");
            return RedirectToAction("Index");
        }
    }
}