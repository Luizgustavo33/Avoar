using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agence3.Data;
using Agence3.Models;

namespace Agence3.Controllers
{
    public class ViagemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViagemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Viagems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Viagem.ToListAsync());
        }

        // GET: Viagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .FirstOrDefaultAsync(m => m.IDviagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Viagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDviagem,Embarque,Destino,Data_Embarque,Preço")] Viagem viagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viagem);
        }

        // GET: Viagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            return View(viagem);
        }

        // POST: Viagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDviagem,Embarque,Destino,Data_Embarque,Preço")] Viagem viagem)
        {
            if (id != viagem.IDviagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.IDviagem))
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
            return View(viagem);
        }

        // GET: Viagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagem
                .FirstOrDefaultAsync(m => m.IDviagem == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viagem = await _context.Viagem.FindAsync(id);
            _context.Viagem.Remove(viagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagem.Any(e => e.IDviagem == id);
        }
    }
}
