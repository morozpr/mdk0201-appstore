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
    public class DetailsModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public DetailsModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

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
    }
}
