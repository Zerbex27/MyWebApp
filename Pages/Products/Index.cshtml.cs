using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;
using Microsoft.AspNetCore.Authorization;


namespace MyWebApp.Pages_Products
{
    
    [Authorize]  // 🔒 Esto exige que el usuario esté autenticado
    public class IndexModel : PageModel
    {
    
        private readonly MyWebApp.Data.ApplicationDbContext _context;

        public IndexModel(MyWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
