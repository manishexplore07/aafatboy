using HrManagement.Data;
using HrManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HrManagementDbContext db;
        public EmployeeController(HrManagementDbContext context)
        {
            this.db = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employee = await db.employees.Include(e => e.Department).ToListAsync();
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await db.departments.ToListAsync();
            return View();
        }
        [HttpPost, ActionName("create")]
        public async Task<IActionResult> Save(Employee obj)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await db.departments.ToListAsync();
                return View(obj);
            }
            db.employees.Add(obj);
            await db.SaveChangesAsync();
            TempData["success"] = "Data Added Sussessfully";
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var employee = await db.employees.
                Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Emp_Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var employee = await db.employees.
                Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Emp_Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var employee = await db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            db.employees.Remove(employee);
            await db.SaveChangesAsync();
            TempData["success"] = "Emploee Data Deleted Sussessfully";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = await db.departments.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }

            var employee = await db.employees.
                Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Emp_Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                db.employees.Update(obj);
                await db.SaveChangesAsync();
                TempData["success"] = "Data Updated Sussessfully";
                return RedirectToAction("Index");

            }
            ViewBag.Departments = await db.departments.ToListAsync();
            return View(obj);
        }
    }
}