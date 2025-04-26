using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Date.Models
{
    public class House
    {
        //[Key]
        public int HouseId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string Address { get; set; } = string.Empty;

        //[ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        [Required]
        [Column(TypeName = "VarChar(50)")]
        public string Description { get; set; } = string.Empty;

        //[Required]
        [Column(TypeName = "DOUBLE")]
        public double Price { get; set; }

       //[ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; } = null!;

        public ICollection<House_amenitie> HouseAmenities { get; set; } = new List<House_amenitie>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
