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
    public class CoordinadoresController : Controller
    {
        private readonly EFGContext _context;

        public CoordinadoresController(EFGContext context)
        {
            _context = context;
        }

        // GET: Coordinadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coordinador.ToListAsync());
        }

        // GET: Coordinadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinador = await _context.Coordinador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordinador == null)
            {
                return NotFound();
            }

            return View(coordinador);
        }

        // GET: Coordinadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coordinadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodCoor,NomCoor")] Coordinador coordinador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coordinador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coordinador);
        }

        // GET: Coordinadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinador = await _context.Coordinador.FindAsync(id);
            if (coordinador == null)
            {
                return NotFound();
            }
            return View(coordinador);
        }

        // POST: Coordinadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodCoor,NomCoor")] Coordinador coordinador)
        {
            if (id != coordinador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coordinador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoordinadorExists(coordinador.Id))
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
            return View(coordinador);
        }

        // GET: Coordinadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coordinador = await _context.Coordinador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordinador == null)
            {
                return NotFound();
            }

            return View(coordinador);
        }

        // POST: Coordinadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coordinador = await _context.Coordinador.FindAsync(id);
            _context.Coordinador.Remove(coordinador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoordinadorExists(int id)
        {
            return _context.Coordinador.Any(e => e.Id == id);
        }
    }
}
