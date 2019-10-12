using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.Recipients
{
    public class DetailsModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public DetailsModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        public Recipient Recipient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipient = await _context.Recipient.FirstOrDefaultAsync(m => m.Id == id);

            if (Recipient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
