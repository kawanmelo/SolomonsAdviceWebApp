﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SolomonsAdviceWebApp.Areas.Identity.Constants;
using SolomonsAdviceWebApp.Data;
using SolomonsAdviceWebApp.Models.Entities;

namespace SolomonsAdviceWebApp.Controllers
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Manager)]
    public class AdvicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Advices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Advices.ToListAsync());
        }

        // GET: Advices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advice = await _context.Advices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advice == null)
            {
                return NotFound();
            }

            return View(advice);
        }

        // GET: Advices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Chapter,Verses,Book")] Advice advice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advice);
        }

        // GET: Advices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advice = await _context.Advices.FindAsync(id);
            if (advice == null)
            {
                return NotFound();
            }
            return View(advice);
        }

        // POST: Advices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Chapter,Verses,Book")] Advice advice)
        {
            if (id != advice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdviceExists(advice.Id))
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
            return View(advice);
        }

        // GET: Advices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advice = await _context.Advices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advice == null)
            {
                return NotFound();
            }

            return View(advice);
        }

        // POST: Advices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advice = await _context.Advices.FindAsync(id);
            if (advice != null)
            {
                _context.Advices.Remove(advice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdviceExists(int id)
        {
            return _context.Advices.Any(e => e.Id == id);
        }
    }
}
