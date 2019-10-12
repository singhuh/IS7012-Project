using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.Shipments
{
    public class EditModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public EditModel(Ship.Models.ShipContext context)
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
           ViewData["DeliverySpeedID"] = new SelectList(_context.DeliverySpeed, "ID", "ID");
           ViewData["RecipientID"] = new SelectList(_context.Recipient, "Id", "RName");
           ViewData["SenderID"] = new SelectList(_context.Sender, "Id", "SAddress");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(Shipment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShipmentExists(int id)
        {
            return _context.Shipment.Any(e => e.ID == id);
        }
    }
}
