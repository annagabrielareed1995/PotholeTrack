using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PotholeTrack.Models;

namespace PotholeTrack.Pages.Potholes
{
    [Authorize(Roles = "Administrator")]
    public class DeleteModel : PageModel
    {
        private readonly PotholeTrack.Models.PotholeContext _context;

        public DeleteModel(PotholeTrack.Models.PotholeContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pothole = await _context.Pothole.FindAsync(id);

            if (Pothole != null)
            {
                _context.Pothole.Remove(Pothole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
