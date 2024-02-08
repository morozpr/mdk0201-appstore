using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public IndexModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        public IList<Models.Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Employee)
                .Include(o => o.OrderItems).ToListAsync();
        }
    }
}
