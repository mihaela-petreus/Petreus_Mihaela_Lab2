using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Petreus_Mihaela_Lab2;
using Petreus_Mihaela_Lab2.Models;

namespace Petreus_Mihaela_Lab2.Pages_PublisherPages
{
    public class DetailsModel : PageModel
    {
        private readonly Petreus_Mihaela_Lab2.Petreus_Mihaela_Lab2Context _context;

        public DetailsModel(Petreus_Mihaela_Lab2.Petreus_Mihaela_Lab2Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.ID == id);

            if (publisher is not null)
            {
                Publisher = publisher;

                return Page();
            }

            return NotFound();
        }
    }
}
