using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Date.Models
{
    public class Tenant
    {
        //[Key]
        public int TenantId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string First_Name { get; set; } = string.Empty;

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string Last_Name { get; set; } = string.Empty;

        [Column(TypeName = "VarChar(10)")]
        [Required]
        public string EGN { get; set; } = string.Empty;

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string Email { get; set; } = string.Empty;

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
