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
    public class IndexModel : PageModel
    {
        private readonly ShipContext _context;
        public IndexModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CountOfShipment = _context.Shipment
                                            .Where(x => x.WB != null)
                                            .Count();
            CountOfShipper = _context.Shipment
                                    .Where(x => x.Sender != null)
                                    .Count();
            CountOfRecipient = _context.Shipment
                                    .Where(x => x.Recipient != null)
                                    .Count();
        }
        public int CountOfShipment { get; set; }
        public int CountOfShipper { get; set; }
        public int CountOfRecipient { get; set; }
    }
}