using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.EmployeeType
{
    public class DetailsModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public DetailsModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        public Models.EmployeeType EmployeeType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeetype = await _context.EmployeeTypes.FirstOrDefaultAsync(m => m.EmployeeTypeId == id);
            if (employeetype == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeType = employeetype;
            }
            return Page();
        }
    }
}
