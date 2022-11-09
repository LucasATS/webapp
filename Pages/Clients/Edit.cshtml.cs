using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages.Clients;

public class Edit : PageModel
{
    private readonly ILogger<Edit> _logger;

    public Edit(ILogger<Edit> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

