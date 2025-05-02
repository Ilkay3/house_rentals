using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Date.Models
{
    public class Booking
    {
        //[Key]
        public int BookingId { get; set; }

        [ForeignKey(nameof(House))]
        public int HouseId { get; set; }
        public House House { get; set; } = null!;

        [ForeignKey(nameof(Tenant))]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
