using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.ItemType
{
    public class EditModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public EditModel(appstore.Data.StoredbContext context)
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

            var itemtype =  await _context.ItemTypes.FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemtype == null)
            {
                return NotFound();
            }
            ItemType = itemtype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ItemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTypeExists(ItemType.ItemTypeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ItemTypeExists(int id)
        {
            return _context.ItemTypes.Any(e => e.ItemTypeId == id);
        }
    }
}
