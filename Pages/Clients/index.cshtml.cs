﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages.Clients;

public class index : PageModel
{
    private readonly ILogger<index> _logger;

    public index(ILogger<index> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

