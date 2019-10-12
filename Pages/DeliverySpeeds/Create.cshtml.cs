using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ship.Models;

namespace Ship.Pages.DeliverySpeeds
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
            return Page();
        }

        [BindProperty]
        public DeliverySpeed DeliverySpeed { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeliverySpeed.Add(DeliverySpeed);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}