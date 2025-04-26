using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Date.Models
{
    public class House_amenitie
    {
        //[ForeignKey(nameof(House))]
        public int HouseId { get; set; }
        public House House { get; set; } = null!;

        //[ForeignKey(nameof(Amenity))]
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; } = null!;

        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
    }
}
