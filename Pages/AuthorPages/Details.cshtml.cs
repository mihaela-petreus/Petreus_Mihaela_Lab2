using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Petreus_Mihaela_Lab2.Models;
using Petreus_Mihaela_Lab2;

namespace Petreus_Mihaela_Lab2.Pages.AuthorPages;

public class DetailsModel : PageModel
{
    private readonly Petreus_Mihaela_Lab2Context _context;
    public DetailsModel(Petreus_Mihaela_Lab2Context context)
    {
        _context = context;
    }

    public Author Author { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
        if (author is null)
        {
            return NotFound();
        }
        else
        {
            Author = author;
        }

        return Page();
    }
}
