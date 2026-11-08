using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Petreus_Mihaela_Lab2.Models;

namespace Petreus_Mihaela_Lab2.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly Petreus_Mihaela_Lab2Context _context;

        public IndexModel(Petreus_Mihaela_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; }
        public IList<Book> Books { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Category = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(c => c.Book)
                        .ThenInclude(t => t.Author)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                var category = Category.Where(i => i.ID == id.Value).FirstOrDefault();
                if (category != null)
                {
                    Books = category.BookCategories.Select(s => s.Book).ToList();
                }
            }
        }
    }
}