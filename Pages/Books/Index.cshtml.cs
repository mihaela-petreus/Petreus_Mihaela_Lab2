using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Petreus_Mihaela_Lab2.Models;

namespace Petreus_Mihaela_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Petreus_Mihaela_Lab2Context _context;

    public IndexModel(Petreus_Mihaela_Lab2Context context)
    {
        _context = context;
    }

    public IList<Book> Book { get; set; }
    public BookData BookD { get; set; }
    public int BookID { get; set; }
    public int CategoryID { get; set; }
    public string TitleSort { get; set; }
    public string AuthorSort { get; set; }

    public string CurrentFilter { get; set; }

    public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
    {
        BookD = new BookData();

        TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        AuthorSort = sortOrder == "author" ? "author_desc" : "author";

        CurrentFilter = searchString;

        var booksIQ = _context.Book
              .Include(b => b.Publisher)
              .Include(b => b.Author)
              .Include(b => b.BookCategories)
              .ThenInclude(b => b.Category)
              .AsNoTracking();

        if (!String.IsNullOrEmpty(searchString))
        {
            booksIQ = booksIQ.Where(s =>
                (s.Author != null && s.Author.FirstName != null && s.Author.FirstName.Contains(searchString)) ||
                (s.Author != null && s.Author.LastName != null && s.Author.LastName.Contains(searchString)) ||
                (s.Title != null && s.Title.Contains(searchString)));
        }

        switch (sortOrder)
        {
            case "title_desc":
                booksIQ = booksIQ.OrderByDescending(s => s.Title);
                break;
            case "author_desc":
                booksIQ = booksIQ.OrderByDescending(s => s.Author.LastName).ThenByDescending(s => s.Author.FirstName);
                break;
            case "author":
                booksIQ = booksIQ.OrderBy(s => s.Author.LastName).ThenBy(s => s.Author.FirstName);
                break;
            default:
                booksIQ = booksIQ.OrderBy(s => s.Title);
                break;
        }

        BookD.Books = await booksIQ.ToListAsync();

        if (id != null)
        {
            BookID = id.Value;
            Book book = BookD.Books
                .Where(i => i.ID == id.Value).FirstOrDefault();
            if (book != null)
            {
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}