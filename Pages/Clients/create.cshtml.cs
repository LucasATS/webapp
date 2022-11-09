using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages.Clients;

public class create : PageModel
{
    private readonly ILogger<create> _logger;

    public create(ILogger<create> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

