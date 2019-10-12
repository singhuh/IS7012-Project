﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Pages.Senders
{
    public class IndexModel : PageModel
    {
        private readonly Ship.Models.ShipContext _context;

        public IndexModel(Ship.Models.ShipContext context)
        {
            _context = context;
        }

        public IList<Sender> Sender { get;set; }

        public async Task OnGetAsync()
        {
            Sender = await _context.Sender.ToListAsync();
        }
    }
}
