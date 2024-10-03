using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interventions.Data;
using Interventions.Models;

namespace Interventions.Controllers
{
    public class IntervenantController : Controller
    {
        private readonly AppDbContext _context;

        public IntervenantController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Intervenant
        public async Task<IActionResult> Index()
        {
            return View(await _context.Intervenant.ToListAsync());
        }

        // GET: Intervenant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervenantModel = await _context.Intervenant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intervenantModel == null)
            {
                return NotFound();
            }

            return View(intervenantModel);
        }

        // GET: Intervenant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Intervenant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,Password,Lastname,Firstname,Gender,Birthdate,StreetNumber,Street,City,PostalCode,Department,CityCode,Longitude,Latitude,Country,AverageScore,Archive")] IntervenantModel intervenantModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intervenantModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(intervenantModel);
        }

        // GET: Intervenant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervenantModel = await _context.Intervenant.FindAsync(id);
            if (intervenantModel == null)
            {
                return NotFound();
            }
            return View(intervenantModel);
        }

        // POST: Intervenant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Password,Lastname,Firstname,Gender,Birthdate,StreetNumber,Street,City,PostalCode,Department,CityCode,Longitude,Latitude,Country,AverageScore,Archive")] IntervenantModel intervenantModel)
        {
            if (id != intervenantModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intervenantModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntervenantModelExists(intervenantModel.Id))
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
            return View(intervenantModel);
        }

        // GET: Intervenant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intervenantModel = await _context.Intervenant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intervenantModel == null)
            {
                return NotFound();
            }

            return View(intervenantModel);
        }

        // POST: Intervenant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intervenantModel = await _context.Intervenant.FindAsync(id);
            if (intervenantModel != null)
            {
                _context.Intervenant.Remove(intervenantModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntervenantModelExists(int id)
        {
            return _context.Intervenant.Any(e => e.Id == id);
        }
    }
}
