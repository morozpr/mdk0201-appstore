using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appstore.Data;
using appstore.Models;

namespace appstore.Pages.OrderItems
{
    public class IndexModel : PageModel
    {
        private readonly appstore.Data.StoredbContext _context;

        public IndexModel(appstore.Data.StoredbContext context)
        {
            _context = context;
        }

        public IList<OrderItem> OrderItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderItem = await _context.OrderItems
                .Include(o => o.Item).ToListAsync();
        }
    }
}
