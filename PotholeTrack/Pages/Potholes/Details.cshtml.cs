using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PotholeTrack.Models;

namespace PotholeTrack.Pages.Potholes
{
    public class DetailsModel : PageModel
    {
        private readonly PotholeTrack.Models.PotholeContext _context;

        public DetailsModel(PotholeTrack.Models.PotholeContext context)
        {
            _context = context;
        }

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
    }
}
