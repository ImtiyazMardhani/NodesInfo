using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NodeStructure.Models;

namespace NodeStructure.Controllers
{
    public class NodesInfoController : Controller
    {
        private readonly AppDbContext _context;

        public NodesInfoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NodesInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.nodesInfo.ToListAsync());
        }

        // GET: NodesInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodesInfo = await _context.nodesInfo
                .FirstOrDefaultAsync(m => m.nodeId == id);
            if (nodesInfo == null)
            {
                return NotFound();
            }

            return View(nodesInfo);
        }

        // GET: NodesInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NodesInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nodeId,nodeName,parentNodeId,isActive,startDate")] NodesInfo nodesInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nodesInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nodesInfo);
        }

        // GET: NodesInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodesInfo = await _context.nodesInfo.FindAsync(id);
            if (nodesInfo == null)
            {
                return NotFound();
            }
            return View(nodesInfo);
        }

        // POST: NodesInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nodeId,nodeName,parentNodeId,isActive,startDate")] NodesInfo nodesInfo)
        {
            if (id != nodesInfo.nodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nodesInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NodesInfoExists(nodesInfo.nodeId))
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
            return View(nodesInfo);
        }

        // GET: NodesInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nodesInfo = await _context.nodesInfo
                .FirstOrDefaultAsync(m => m.nodeId == id);
            if (nodesInfo == null)
            {
                return NotFound();
            }

            return View(nodesInfo);
        }

        // POST: NodesInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nodesInfo = await _context.nodesInfo.FindAsync(id);
            if (nodesInfo != null)
            {
                _context.nodesInfo.Remove(nodesInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NodesInfoExists(int id)
        {
            return _context.nodesInfo.Any(e => e.nodeId == id);
        }
    }
}
