using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.SupplySupplyItems
{
    public class CreateModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public CreateModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SupplyId"] = new SelectList(_context.Supplies, "SupplyId", "SupplyId");
        ViewData["SupplyItemId"] = new SelectList(_context.SupplyItems, "SupplyItemId", "SupplyItemId");
            return Page();
        }

        [BindProperty]
        public SupplySupplyItem SupplySupplyItem { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SupplySupplyItems.Add(SupplySupplyItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
