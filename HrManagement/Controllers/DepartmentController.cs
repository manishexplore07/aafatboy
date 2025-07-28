using HrManagement.Data;
using HrManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HrManagementDbContext db;
        public DepartmentController(HrManagementDbContext context)
        {
            this.db = context;
        }
        public async Task<IActionResult> Index()
        {
            var Departments = await db.departments.ToListAsync();

            return View(Departments);
        }
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await db.departments.AddAsync(department);
                await db.SaveChangesAsync();
                TempData["success"] = "Department Added SuccessFully";
                return RedirectToAction("Index");
            }

            return View(department);
        }
    }
}