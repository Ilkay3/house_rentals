using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Date.Models
{
    public class Payment
    {
        //[Key]
        public int PaymentId { get; set; }

        [ForeignKey(nameof(Booking))]
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
        
        [Required]
        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string PaymentMethod { get; set; } = string.Empty;

    }
}
