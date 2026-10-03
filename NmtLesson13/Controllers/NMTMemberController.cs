using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMT.Data;
using NMT.Models;

namespace NMT.Controllers;

public class NMTMemberController : Controller
{
    private readonly NMTDbContext _context;

    public NMTMemberController(NMTDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var members = await _context.Members
            .OrderBy(m => m.NMTFullName)
            .ToListAsync();

        return View(members);
    }

    [HttpGet]
    public IActionResult NMTCreate()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NMTCreate(NMTMember member)
    {
        if (!ModelState.IsValid)
        {
            return View(member);
        }

        member.NMTMemberId = Guid.NewGuid().ToString();
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> NMTEdit(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var member = await _context.Members.FirstOrDefaultAsync(m => m.NMTMemberId == id);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NMTEdit(string id, NMTMember member)
    {
        if (id != member.NMTMemberId)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(member);
        }

        try
        {
            var currentMember = await _context.Members.FirstOrDefaultAsync(m => m.NMTMemberId == id);
            if (currentMember == null)
            {
                return NotFound();
            }

            currentMember.NMTUserName = member.NMTUserName;
            currentMember.NMTPassword = member.NMTPassword;
            currentMember.NMTFullName = member.NMTFullName;
            currentMember.NMTEmail = member.NMTEmail;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Members.AnyAsync(m => m.NMTMemberId == id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> NMTDetails(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var member = await _context.Members.FirstOrDefaultAsync(m => m.NMTMemberId == id);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    [HttpGet]
    public async Task<IActionResult> NMTDelete(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var member = await _context.Members.FirstOrDefaultAsync(m => m.NMTMemberId == id);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    [HttpPost]
    [ActionName("NMTDelete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NMTDeleteConfirmed(string id)
    {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.NMTMemberId == id);
        if (member == null)
        {
            return NotFound();
        }

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
