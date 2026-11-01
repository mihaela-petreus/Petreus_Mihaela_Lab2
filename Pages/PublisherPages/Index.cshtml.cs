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
    public class IndexModel : PageModel
    {
        private readonly Petreus_Mihaela_Lab2.Petreus_Mihaela_Lab2Context _context;

        public IndexModel(Petreus_Mihaela_Lab2.Petreus_Mihaela_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
