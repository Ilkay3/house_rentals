using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Date.Models
{
    public class Amenity
    {
        [Key]
        public int AmenityId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<House_amenitie> HouseAmenities { get; set; } = new List<House_amenitie>();
    }
}
