using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.ItemType
{
    public class DeleteModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public DeleteModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.ItemType ItemType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemtype = await _context.ItemTypes.FirstOrDefaultAsync(m => m.ItemTypeId == id);

            if (itemtype == null)
            {
                return NotFound();
            }
            else
            {
                ItemType = itemtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemtype = await _context.ItemTypes.FindAsync(id);
            if (itemtype != null)
            {
                ItemType = itemtype;
                _context.ItemTypes.Remove(ItemType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
