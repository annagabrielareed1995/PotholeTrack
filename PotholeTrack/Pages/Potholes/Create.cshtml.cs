using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PotholeTrack.Models;

namespace PotholeTrack.Pages.Potholes
{
    public class CreateModel : PageModel
    {
        private readonly PotholeTrack.Models.PotholeContext _context;

        public CreateModel(PotholeTrack.Models.PotholeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pothole Pothole { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pothole.Add(Pothole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}