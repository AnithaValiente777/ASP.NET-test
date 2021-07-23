using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancolombiaTest.Data;
using BancolombiaTest.Models;

namespace BancolombiaTest
{
    public class GerentesController : Controller
    {
        private readonly EFGContext _context;

        public GerentesController(EFGContext context)
        {
            _context = context;
        }

        // GET: Gerentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gerente.ToListAsync());
        }

        // GET: Gerentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerente = await _context.Gerente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }

            return View(gerente);
        }

        // GET: Gerentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gerentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodGte,NomGte")] Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gerente);
        }

        // GET: Gerentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerente = await _context.Gerente.FindAsync(id);
            if (gerente == null)
            {
                return NotFound();
            }
            return View(gerente);
        }

        // POST: Gerentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodGte,NomGte")] Gerente gerente)
        {
            if (id != gerente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerenteExists(gerente.Id))
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
            return View(gerente);
        }

        // GET: Gerentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerente = await _context.Gerente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }

            return View(gerente);
        }

        // POST: Gerentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerente = await _context.Gerente.FindAsync(id);
            _context.Gerente.Remove(gerente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerenteExists(int id)
        {
            return _context.Gerente.Any(e => e.Id == id);
        }
    }
}
