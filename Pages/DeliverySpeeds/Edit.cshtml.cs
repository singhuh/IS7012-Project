using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.DeliverySpeeds
{
    public class EditModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public EditModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeliverySpeed DeliverySpeed { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeliverySpeed = await _context.DeliverySpeed.FirstOrDefaultAsync(m => m.ID == id);

            if (DeliverySpeed == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeliverySpeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliverySpeedExists(DeliverySpeed.ID))
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

        private bool DeliverySpeedExists(int id)
        {
            return _context.DeliverySpeed.Any(e => e.ID == id);
        }
    }
}
