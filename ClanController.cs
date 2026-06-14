
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotekaMVC.Models;
using BibliotekaMVC.Data;

public class ClanController : Controller
{
    private readonly BibliotekaContext _context;

    public ClanController(BibliotekaContext context)
    {
        _context = context;
    }

    // GET: CLANS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Clanovi.ToListAsync());
    }

    // GET: CLANS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clan = await _context.Clanovi
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clan == null)
        {
            return NotFound();
        }

        return View(clan);
    }

    // GET: CLANS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CLANS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Email")] Clan clan)
    {
        if (ModelState.IsValid)
        {
            _context.Add(clan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(clan);
    }

    // GET: CLANS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clan = await _context.Clanovi.FindAsync(id);
        if (clan == null)
        {
            return NotFound();
        }
        return View(clan);
    }

    // POST: CLANS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Ime,Prezime,Email")] Clan clan)
    {
        if (id != clan.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(clan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanExists(clan.Id))
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
        return View(clan);
    }

    // GET: CLANS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clan = await _context.Clanovi
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clan == null)
        {
            return NotFound();
        }

        return View(clan);
    }

    // POST: CLANS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var clan = await _context.Clanovi.FindAsync(id);
        if (clan != null)
        {
            _context.Clanovi.Remove(clan);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClanExists(int? id)
    {
        return _context.Clanovi.Any(e => e.Id == id);
    }
}
