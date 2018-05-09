using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PotholeTrack.Models;

namespace PotholeTrack.Pages.Potholes
{
    [Authorize(Roles = "Administrator")]
    public class EditModel : PageModel
    {
        private readonly PotholeTrack.Models.PotholeContext _context;

        public EditModel(PotholeTrack.Models.PotholeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pothole Pothole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pothole = await _context.Pothole.SingleOrDefaultAsync(m => m.ID == id);

            if (Pothole == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pothole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PotholeExists(Pothole.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PotholeExists(int id)
        {
            return _context.Pothole.Any(e => e.ID == id);
        }
    }
}
