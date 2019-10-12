using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ship.Models;

namespace Ship.Pages.Shipments
{
    public class CreateModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public CreateModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeliverySpeedID"] = new SelectList(_context.DeliverySpeed, "ID", "ID");
        ViewData["RecipientID"] = new SelectList(_context.Recipient, "Id", "RName");
        ViewData["SenderID"] = new SelectList(_context.Sender, "Id", "SAddress");
            return Page();
        }

        [BindProperty]
        public Shipment Shipment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shipment.Add(Shipment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}