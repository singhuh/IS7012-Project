﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.Senders
{
    public class EditModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public EditModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sender Sender { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sender = await _context.Sender.FirstOrDefaultAsync(m => m.Id == id);

            if (Sender == null)
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

            _context.Attach(Sender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SenderExists(Sender.Id))
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

        private bool SenderExists(int id)
        {
            return _context.Sender.Any(e => e.Id == id);
        }
    }
}
