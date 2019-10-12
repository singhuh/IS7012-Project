using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ship.Models;

namespace Ship.Models
{
    public class ShipContext : DbContext
    {
        public ShipContext (DbContextOptions<ShipContext> options)
            : base(options)
        {
        }

        public DbSet<Ship.Models.DeliverySpeed> DeliverySpeed { get; set; }

        public DbSet<Ship.Models.Recipient> Recipient { get; set; }

        public DbSet<Ship.Models.Sender> Sender { get; set; }

        public DbSet<Ship.Models.Shipment> Shipment { get; set; }
    }
}
