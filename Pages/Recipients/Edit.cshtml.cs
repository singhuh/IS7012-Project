using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.Recipients
{
    public class EditModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public EditModel(Ship.Models.ShipContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recipient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipientExists(Recipient.Id))
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

        private bool RecipientExists(int id)
        {
            return _context.Recipient.Any(e => e.Id == id);
        }
    }
}
