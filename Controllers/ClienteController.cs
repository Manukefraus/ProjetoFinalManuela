﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalManuela.Models;

namespace ProjetoFinalManuela.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Contexto _context;

        public ClienteController(Contexto context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index(string pesquisa)
        {
            if (pesquisa == null)
            {
                var contexto = _context.Cliente.Include(c => c.Cidade);
                return View(await contexto.ToListAsync());
            }
            else
            {
                var cliente =
                    _context.Cliente.Include(c => c.Cidade)
                    .Where(x => x.ClienteNome.Contains(pesquisa))
                    .OrderBy(x => x.ClienteNome);

                return View(cliente);
            }
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Cidade)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,ClienteNome,ClienteCpf,ClienteSexo,ClienteTelefone,ClienteEndereco,ClienteNumero,CidadeId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", cliente.CidadeId);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ClienteId, [Bind("ClienteId,ClienteNome,ClienteCpf,ClienteSexo,ClienteTelefone,ClienteEndereco,ClienteNumero,CidadeId")] Cliente cliente)
        {
            if (ClienteId != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeNome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.Cidade)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ClienteId)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'Contexto.Cliente'  is null.");
            }
            var cliente = await _context.Cliente.FindAsync(ClienteId);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Cliente?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }
    }
}
