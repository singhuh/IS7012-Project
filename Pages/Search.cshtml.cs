using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ship.Models;
using Microsoft.EntityFrameworkCore;

namespace Ship.Pages
{
    public class SearchShipmentsModel : PageModel
    {
        private ShipContext _context;
        public SearchShipmentsModel(ShipContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            SearchCompleted = false;
        }
        [BindProperty]
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<Shipment> SearchResults { get; set; }
        public void Onpost()
        {
            if (string.IsNullOrWhiteSpace(Search))
            {
                return;
            }
            SearchResults = _context.Shipment
                                    .Include(x => x.Sender)
                                    .Include(x => x.Recipient)
                                    .Where(x => x.WB == Search)
                                    .ToList();
            SearchCompleted = true;
        }
    }
}