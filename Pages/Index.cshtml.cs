﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Timmy.Models;

namespace Timmy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet=true)]
        public string PageUser { get; set; }
        
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(PageUser))
                {
                    PageUser = "Joe";
                }

        }
    }
}
