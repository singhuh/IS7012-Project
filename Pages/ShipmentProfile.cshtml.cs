
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
    public class ShipmentProfileModel : PageModel
    {
        private ShipContext coreCrudContext;
        public ShipmentProfileModel(ShipContext coreCrudContext)
        {
            this.coreCrudContext = coreCrudContext;
        }
        public Shipment Shipments { get; set; }
        public Sender Senders { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Shipments = coreCrudContext.Shipment.Include(a => a.Sender).Where(c => c.ID == id).OrderBy(x => x.ID == id).FirstOrDefault();
            if (Shipments == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
