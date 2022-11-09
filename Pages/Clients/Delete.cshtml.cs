using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages.Clients;

public class Delete : PageModel
{
    private readonly ILogger<Delete> _logger;

    public Delete(ILogger<Delete> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

