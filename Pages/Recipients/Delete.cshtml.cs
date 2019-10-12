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
    public class DeleteModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public DeleteModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipient = await _context.Recipient.FindAsync(id);

            if (Recipient != null)
            {
                _context.Recipient.Remove(Recipient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
