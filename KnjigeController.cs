
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotekaMVC.Models;
using BibliotekaMVC.Data;

public class KnjigeController : Controller
{
    public IActionResult ResetAll()
    {
        foreach (var k in _context.Knjige)
        {
            k.Dostupna = true;
        }

        _context.Zaduzenja.RemoveRange(_context.Zaduzenja);

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    private readonly BibliotekaContext _context;

    public KnjigeController(BibliotekaContext context)
    {
        _context = context;
    }

    // GET: KNJIGAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Knjige.ToListAsync());
    }

    // GET: KNJIGAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var knjiga = await _context.Knjige
            .FirstOrDefaultAsync(m => m.Id == id);
        if (knjiga == null)
        {
            return NotFound();
        }

        return View(knjiga);
    }

    // GET: KNJIGAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: KNJIGAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Naslov,Autor,Dostupna")] Knjiga knjiga)
    {
        if (ModelState.IsValid)
        {
            _context.Add(knjiga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(knjiga);
    }

    // GET: KNJIGAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var knjiga = await _context.Knjige.FindAsync(id);
        if (knjiga == null)
        {
            return NotFound();
        }
        return View(knjiga);
    }

    // POST: KNJIGAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Naslov,Autor,Dostupna")] Knjiga knjiga)
    {
        if (id != knjiga.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(knjiga);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnjigaExists(knjiga.Id))
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
        return View(knjiga);
    }

    // GET: KNJIGAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var knjiga = await _context.Knjige
            .FirstOrDefaultAsync(m => m.Id == id);
        if (knjiga == null)
        {
            return NotFound();
        }

        return View(knjiga);
    }

    // POST: KNJIGAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var knjiga = await _context.Knjige.FindAsync(id);
        if (knjiga != null)
        {
            _context.Knjige.Remove(knjiga);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool KnjigaExists(int? id)
    {
        return _context.Knjige.Any(e => e.Id == id);
    }
}
