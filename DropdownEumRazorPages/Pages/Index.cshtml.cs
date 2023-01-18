using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DropdownEumRazorPages.Pages;
public class IndexModel : PageModel
{
    public string? Message { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public Book Book { get; set; }
    public void OnGet()
    {
        Book = new Book() {Category = BookCategories.Programming};
    }
    public void OnPost()
    {
        Message = $"Selection <span class=\"text-primary fw-bold\">{Book.Category}</span>";
        if (Book.Category == BookCategories.Select)
        {
            Message = "Please select a <span class=\"text-danger fw-bold\">category</span>";
        }
    }
}
