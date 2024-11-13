using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeHub.Data;
using EmployeeHub.Models;

namespace EmployeeHub.Controllers
{
    public class SalaryHistoryController : Controller
    {
        private readonly AppDbContext _context;

        public SalaryHistoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SalaryHistory
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SalaryHistories.Include(s => s.Department).Include(s => s.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SalaryHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryHistory = await _context.SalaryHistories
                .Include(s => s.Department)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.SalaryID == id);
            if (salaryHistory == null)
            {
                return NotFound();
            }

            return View(salaryHistory);
        }

        // GET: SalaryHistory/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName");
            return View();
        }

        // POST: SalaryHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryID,EmployeeID,SalaryAmount,EffectiveDate,DepartmentID")] SalaryHistory salaryHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", salaryHistory.DepartmentID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName", salaryHistory.EmployeeID);
            return View(salaryHistory);
        }

        // GET: SalaryHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryHistory = await _context.SalaryHistories.FindAsync(id);
            if (salaryHistory == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", salaryHistory.DepartmentID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName", salaryHistory.EmployeeID);
            return View(salaryHistory);
        }

        // POST: SalaryHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryID,EmployeeID,SalaryAmount,EffectiveDate,DepartmentID")] SalaryHistory salaryHistory)
        {
            if (id != salaryHistory.SalaryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryHistoryExists(salaryHistory.SalaryID))
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
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", salaryHistory.DepartmentID);
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName", salaryHistory.EmployeeID);
            return View(salaryHistory);
        }

        // GET: SalaryHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryHistory = await _context.SalaryHistories
                .Include(s => s.Department)
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.SalaryID == id);
            if (salaryHistory == null)
            {
                return NotFound();
            }

            return View(salaryHistory);
        }

        // POST: SalaryHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaryHistory = await _context.SalaryHistories.FindAsync(id);
            if (salaryHistory != null)
            {
                _context.SalaryHistories.Remove(salaryHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryHistoryExists(int id)
        {
            return _context.SalaryHistories.Any(e => e.SalaryID == id);
        }
    }
}
