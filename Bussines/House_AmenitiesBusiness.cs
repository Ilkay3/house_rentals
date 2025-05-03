using house_rentals.Date.Models;
using house_rentals.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace house_rentals.Bussines
{
    public class House_AmenitiesBusiness : ICRUD<House_Amenity>
    {
        private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

        public House_AmenitiesBusiness() { }

        public House_AmenitiesBusiness(HouseRentalsDBContext houseRentalsDBContext)
        {
            this.houseRentalsDBContext = houseRentalsDBContext;
        }

        public void Add(House_Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                houseRentalsDBContext.House_Amenities.Add(item);
                houseRentalsDBContext.SaveChanges();
            }
        }

        public void Delete(House_Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var house_amenity = houseRentalsDBContext.House_Amenities.FirstOrDefault(x => x.HouseId == item.HouseId && x.AmenityId == item.AmenityId);

                if (house_amenity != null)
                {
                    houseRentalsDBContext.House_Amenities.Remove(house_amenity);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }

        public House_Amenity Get(House_Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.House_Amenities.Include(x => x.House).Include(x => x.Amenity).FirstOrDefault(x => x.HouseId == item.HouseId && x.AmenityId == item.AmenityId);
            }
        }

        public List<House_Amenity> GetAll()
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.House_Amenities.Include(x => x.House).Include(x => x.Amenity).ToList();
            }
        }

        public void Update(House_Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var house_amenity = houseRentalsDBContext.House_Amenities.FirstOrDefault(x => x.HouseId == item.HouseId && x.AmenityId == item.AmenityId);

                if (house_amenity != null)
                {
                    houseRentalsDBContext.Entry(house_amenity).CurrentValues.SetValues(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }
    }
}
