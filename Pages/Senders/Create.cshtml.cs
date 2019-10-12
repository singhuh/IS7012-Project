using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ship.Models;

namespace Ship.Pages.Senders
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
        public Sender Sender { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sender.Add(Sender);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}