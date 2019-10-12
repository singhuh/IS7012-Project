using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ship.Models
{
    public class DeliverySpeed
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        [Display(Name = "Delivery Speed")]
        public string ShipSpeed { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
        public string ShipmentSpeed
        {
            get
            {
                if (ShipSpeed == "Express")
                {
                    return "Express Service";
                }
                else
                {
                    return "Regular Service";
                }
            }
        }
    }
}
