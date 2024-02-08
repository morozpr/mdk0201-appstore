using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.Price
{
    public class DeleteModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public DeleteModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Price Price { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Prices.FirstOrDefaultAsync(m => m.PriceId == id);

            if (price == null)
            {
                return NotFound();
            }
            else
            {
                Price = price;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Prices.FindAsync(id);
            if (price != null)
            {
                Price = price;
                _context.Prices.Remove(Price);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
