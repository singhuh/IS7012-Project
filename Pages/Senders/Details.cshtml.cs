using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.Senders
{
    public class DetailsModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public DetailsModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        public Sender Sender { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sender = await _context.Sender.FirstOrDefaultAsync(m => m.Id == id);

            if (Sender == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
