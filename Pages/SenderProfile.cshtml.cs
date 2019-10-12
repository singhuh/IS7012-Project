using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ship.Models;
using Microsoft.EntityFrameworkCore;

namespace ship.Pages
{
    public class SenderProfileModel : PageModel
    {
        private ShipContext coreCrudContext;
        public SenderProfileModel(ShipContext coreCrudContext)
        {
            this.coreCrudContext = coreCrudContext;
        }
        public Sender Senders { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Senders = coreCrudContext.Sender.Include(a => a.Shipments).Where(c => c.Id == id).OrderBy(x => x.Id == id).FirstOrDefault();
            if (Senders == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}