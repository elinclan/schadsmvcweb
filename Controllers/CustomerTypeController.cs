using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using schadTestWeb.Models;

namespace schadTestWeb.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly MvcTestInvoceContext _context;

        public CustomerTypeController(MvcTestInvoceContext context)
        {
            _context = context;
        }

        // GET: CustomerType
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerTypes.ToListAsync());
        }

        // GET: CustomerType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTypes = await _context.CustomerTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerTypes == null)
            {
                return NotFound();
            }

            return View(customerTypes);
        }

        // GET: CustomerType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] CustomerTypes customerTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerTypes);
        }

        // GET: CustomerType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTypes = await _context.CustomerTypes.FindAsync(id);
            if (customerTypes == null)
            {
                return NotFound();
            }
            return View(customerTypes);
        }

        // POST: CustomerType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] CustomerTypes customerTypes)
        {
            if (id != customerTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTypesExists(customerTypes.Id))
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
            return View(customerTypes);
        }

        // GET: CustomerType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTypes = await _context.CustomerTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerTypes == null)
            {
                return NotFound();
            }

            return View(customerTypes);
        }

        // POST: CustomerType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerTypes = await _context.CustomerTypes.FindAsync(id);
            _context.CustomerTypes.Remove(customerTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTypesExists(int id)
        {
            return _context.CustomerTypes.Any(e => e.Id == id);
        }
    }
}
