using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petreus_Mihaela_Lab2;
using Petreus_Mihaela_Lab2.Models;

namespace Petreus_Mihaela_Lab2.Pages_PublisherPages
{
    public class CreateModel : PageModel
    {
        private readonly Petreus_Mihaela_Lab2.Petreus_Mihaela_Lab2Context _context;

        public CreateModel(Petreus_Mihaela_Lab2.Petreus_Mihaela_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
