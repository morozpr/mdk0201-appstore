using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.Provider
{
    public class DetailsModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public DetailsModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        public Models.Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FirstOrDefaultAsync(m => m.ProviderId == id);
            if (provider == null)
            {
                return NotFound();
            }
            else
            {
                Provider = provider;
            }
            return Page();
        }
    }
}
