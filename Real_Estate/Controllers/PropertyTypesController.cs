using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Data;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
    public class PropertyTypesController : Controller
    {
        private readonly RealEstateDbContext _context;

        public PropertyTypesController(RealEstateDbContext context)
        {
            _context = context;
        }

        // GET: PropertyTypes
        public async Task<IActionResult> Index()
        {
              return _context.PropertyTypes != null ? 
                          View(await _context.PropertyTypes.ToListAsync()) :
                          Problem("Entity set 'RealEstateDbContext.PropertyTypes'  is null.");
        }

        // GET: PropertyTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PropertyTypes == null)
            {
                return NotFound();
            }

            var propertyTypes = await _context.PropertyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyTypes == null)
            {
                return NotFound();
            }

            return View(propertyTypes);
        }

        // GET: PropertyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] PropertyTypes propertyTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyTypes);
        }

        // GET: PropertyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PropertyTypes == null)
            {
                return NotFound();
            }

            var propertyTypes = await _context.PropertyTypes.FindAsync(id);
            if (propertyTypes == null)
            {
                return NotFound();
            }
            return View(propertyTypes);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] PropertyTypes propertyTypes)
        {
            if (id != propertyTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyTypesExists(propertyTypes.Id))
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
            return View(propertyTypes);
        }

        // GET: PropertyTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PropertyTypes == null)
            {
                return NotFound();
            }

            var propertyTypes = await _context.PropertyTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyTypes == null)
            {
                return NotFound();
            }

            return View(propertyTypes);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PropertyTypes == null)
            {
                return Problem("Entity set 'RealEstateDbContext.PropertyTypes'  is null.");
            }
            var propertyTypes = await _context.PropertyTypes.FindAsync(id);
            if (propertyTypes != null)
            {
                _context.PropertyTypes.Remove(propertyTypes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyTypesExists(int id)
        {
          return (_context.PropertyTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
