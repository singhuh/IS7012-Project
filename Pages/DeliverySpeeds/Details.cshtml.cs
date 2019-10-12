using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.DeliverySpeeds
{
    public class DetailsModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public DetailsModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

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
    }
}
