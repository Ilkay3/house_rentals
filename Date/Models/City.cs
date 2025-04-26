using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Date.Models
{
    public class City
    {
        //[Key]
        public int CityId { get; set; }

        [Column(TypeName = "VarChar(50)")]
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<House> Houses { get; set; } = new List<House>();
    }
}
