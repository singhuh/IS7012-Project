using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ship.Models
{
    public class Sender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Sender Name")]
        public string SName { get; set; }

        [Required]
        [Display(Name = "Sender Address")]
        public string SAddress { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
    }
}
