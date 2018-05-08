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
    public class IndexModel : PageModel
    {
        private readonly PotholeTrack.Models.PotholeContext _context;

        public IndexModel(PotholeTrack.Models.PotholeContext context)
        {
            _context = context;
        }

        public IList<Pothole> Pothole { get;set; }

        public async Task OnGetAsync()
        {
            Pothole = await _context.Pothole.ToListAsync();
        }
    }
}
