using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ship.Models
{
    public class Shipment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Waybill#")]
        public string WB { get; set; }

        [Required]
        [Display(Name = "Shipper")]
        public int SenderID { get; set; }
        public Sender Sender { get; set; }


        [Required]
        [Display(Name = "Recipient")]
        public int RecipientID { get; set; }
        public Recipient Recipient { get; set; }


        [Required]
        [Display(Name = "Ship Date")]
        [DataType(DataType.Date)]
        public DateTime? DateShipped { get; set; }

        [Required]
        [CustomValidation(typeof(Shipment), "DateValidation")]
        [Display(Name = "Deliver Date")]
        [DataType(DataType.Date)]
        public DateTime? DateDelivered { get; set; }
        public static ValidationResult DateValidation(DateTime? DateDelivered, ValidationContext context)
        {
            if (DateDelivered == null)
            {
                return ValidationResult.Success;
            }
            if (DateDelivered < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Delivered date must be before current time");
        }

        [Display(Name = "Delivery Status")]
        public string DeliveryStatus
        {
            get
            {
                if (DateDelivered == null)
                {
                    return "Not Delivered";
                }
                else
                {
                    return "Delivered";
                }
            }
        }

        [Display(Name = "Delivery Speed")]
        public int DeliverySpeedID { get; set; }
        public DeliverySpeed DeliverySpeed { get; set; }

        [Required]
        [Range(1, 5000)]
        [Display(Name = "Weight (grams)")]
        [CustomValidation(typeof(Shipment), "WeightValidation")]
        public double Weight { get; set; }

        public static ValidationResult WeightValidation(double Weight, ValidationContext context)
        {
            if (Weight == 0)
            {
                return ValidationResult.Success;
            }
            if (Weight > 0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Weight should be greater than zero");
        }

        [Display(Name = "Category")]
        public string Category
        {
            get
            {
                if (Weight > 1400)
                {
                    return "Bulk";
                }
                else
                {
                    return "Regular";
                }
            }
        }

    }
}