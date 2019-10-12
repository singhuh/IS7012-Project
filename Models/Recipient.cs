using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ship.Models
{
    public class Recipient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Recipient Name")]
        public string RName { get; set; }

        [Phone]
        [Display(Name = "Recipient Phone")]
        public string RPhone { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Recipient Address")]
        public string Rddress { get; set; }

        public ICollection<Shipment> Shipments { get; set; }

        [CustomValidation(typeof(Recipient), "DateValidation")]
        [Display(Name = "Date Received")]
        [DataType(DataType.Date)]
        public DateTime? DateReceived { get; set; }

        public static ValidationResult DateValidation(DateTime? DateReceived, ValidationContext context)
        {
            if (DateReceived == null)
            {
                return ValidationResult.Success;
            }
            if (DateReceived < DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Delivered date must be before current date");
        }

        [Display(Name = "Delivery Status")]
        public string DeliveryStatus
        {
            get
            {
                if (DateReceived == null)
                {
                    return "Not Delivered";
                }
                else
                {
                    return "Delivered";
                }
            }
        }
    }
}

