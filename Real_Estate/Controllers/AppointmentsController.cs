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
    public class AppointmentsController : Controller
    {
        private readonly RealEstateDbContext _context;

        public AppointmentsController(RealEstateDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var realEstateDbContext = _context.Appointment.Include(a => a.Clients).Include(a => a.Owners).Include(a => a.Property).Include(a => a.PropertyTypes);
            return View(await realEstateDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Clients)
                .Include(a => a.Owners)
                .Include(a => a.Property)
                .Include(a => a.PropertyTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["clientId"] = new SelectList(_context.Clients, "Id", "Name");
            ViewData["ownerId"] = new SelectList(_context.Owners, "Id", "Name");
            ViewData["propertyId"] = new SelectList(_context.Properties, "Id", "Name");
            ViewData["propertytypesId"] = new SelectList(_context.PropertyTypes, "Id", "Name");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,propertyId,clientId,ownerId,propertytypesId,Status")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["clientId"] = new SelectList(_context.Clients, "Id", "Name", appointment.clientId);
            ViewData["ownerId"] = new SelectList(_context.Owners, "Id", "Name", appointment.ownerId);
            ViewData["propertyId"] = new SelectList(_context.Properties, "Id", "Name", appointment.propertyId);
            ViewData["propertytypesId"] = new SelectList(_context.PropertyTypes, "Id", "Name", appointment.propertytypesId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["clientId"] = new SelectList(_context.Clients, "Id", "Name", appointment.clientId);
            ViewData["ownerId"] = new SelectList(_context.Owners, "Id", "Name", appointment.ownerId);
            ViewData["propertyId"] = new SelectList(_context.Properties, "Id", "Name", appointment.propertyId);
            ViewData["propertytypesId"] = new SelectList(_context.PropertyTypes, "Id", "Name", appointment.propertytypesId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,propertyId,clientId,ownerId,propertytypesId,Status")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["clientId"] = new SelectList(_context.Clients, "Id", "Name", appointment.clientId);
            ViewData["ownerId"] = new SelectList(_context.Owners, "Id", "Name", appointment.ownerId);
            ViewData["propertyId"] = new SelectList(_context.Properties, "Id", "Name", appointment.propertyId);
            ViewData["propertytypesId"] = new SelectList(_context.PropertyTypes, "Id", "Name", appointment.propertytypesId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Clients)
                .Include(a => a.Owners)
                .Include(a => a.Property)
                .Include(a => a.PropertyTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appointment == null)
            {
                return Problem("Entity set 'RealEstateDbContext.Appointment'  is null.");
            }
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointment.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return (_context.Appointment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
