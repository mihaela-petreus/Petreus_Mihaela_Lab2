using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Petreus_Mihaela_Lab2.Models;
using Petreus_Mihaela_Lab2;

namespace Petreus_Mihaela_Lab2.Pages.CategoryPages;

public class DetailsModel : PageModel
{
    private readonly Petreus_Mihaela_Lab2Context _context;
    public DetailsModel(Petreus_Mihaela_Lab2Context context)
    {
        _context = context;
    }

    public Category Category { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
        if (category is null)
        {
            return NotFound();
        }
        else
        {
            Category = category;
        }

        return Page();
    }
}
