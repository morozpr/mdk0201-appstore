using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.Stock
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
        ViewData["ItemTypeId"] = new SelectList(_context.ItemTypes, "ItemTypeId", "ItemTypeId");
            return Page();
        }

        [BindProperty]
        public Models.Stock Stock { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Stocks.Add(Stock);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
