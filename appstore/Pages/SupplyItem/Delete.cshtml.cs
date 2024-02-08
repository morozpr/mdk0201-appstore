using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.SupplyItem
{
    public class DeleteModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public DeleteModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.SupplyItem SupplyItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyitem = await _context.SupplyItems.FirstOrDefaultAsync(m => m.SupplyItemId == id);

            if (supplyitem == null)
            {
                return NotFound();
            }
            else
            {
                SupplyItem = supplyitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyitem = await _context.SupplyItems.FindAsync(id);
            if (supplyitem != null)
            {
                SupplyItem = supplyitem;
                _context.SupplyItems.Remove(SupplyItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
