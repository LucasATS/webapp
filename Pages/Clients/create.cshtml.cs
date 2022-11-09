using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Site_Aspnet.Pages.Clients;

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

