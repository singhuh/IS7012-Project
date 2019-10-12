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
    public class QuickGlanceModel : PageModel
    {
        private ShipContext context;
        public QuickGlanceModel(ShipContext context)
        {
            this.context = context;
        }
        public ICollection<Shipment> Shipments { get; set; }
        public void OnGet()
        {
            Shipments = context.Shipment.OrderBy(a => a.ID).Include(x => x.Sender).OrderBy(m => m.Sender.SName).ToList();
        }
    }
}




