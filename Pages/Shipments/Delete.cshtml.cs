using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.Shipments
{
    public class DeleteModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public DeleteModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shipment Shipment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shipment = await _context.Shipment
                .Include(s => s.DeliverySpeed)
                .Include(s => s.Recipient)
                .Include(s => s.Sender).FirstOrDefaultAsync(m => m.ID == id);

            if (Shipment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shipment = await _context.Shipment.FindAsync(id);

            if (Shipment != null)
            {
                _context.Shipment.Remove(Shipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
