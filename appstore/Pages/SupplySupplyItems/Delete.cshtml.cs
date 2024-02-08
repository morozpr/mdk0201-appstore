using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.SupplySupplyItems
{
    public class DeleteModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public DeleteModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplySupplyItem SupplySupplyItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplysupplyitem = await _context.SupplySupplyItems.FirstOrDefaultAsync(m => m.SupplyItemsId == id);

            if (supplysupplyitem == null)
            {
                return NotFound();
            }
            else
            {
                SupplySupplyItem = supplysupplyitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplysupplyitem = await _context.SupplySupplyItems.FindAsync(id);
            if (supplysupplyitem != null)
            {
                SupplySupplyItem = supplysupplyitem;
                _context.SupplySupplyItems.Remove(SupplySupplyItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
