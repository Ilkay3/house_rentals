using house_rentals.Date;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Bussines
{
    public class AmenityBusiness : ICRUD<Amenity>
    {
        private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

        public AmenityBusiness() { }

        public AmenityBusiness(HouseRentalsDBContext houseRentalsDBContext)
        {
            this.houseRentalsDBContext = houseRentalsDBContext;
        }

        public void Add(Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                houseRentalsDBContext.Amenities.Add(item);
                houseRentalsDBContext.SaveChanges();
            }
        }

        public void Delete(Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var amenity = houseRentalsDBContext.Amenities.Find(item.AmenityId);
                if (amenity != null)
                {
                    houseRentalsDBContext.Amenities.Remove(amenity);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }

        public Amenity Get(Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Amenities.Where(x => x.AmenityId == item.AmenityId).FirstOrDefault();
            }
        }

        public List<Amenity> GetAll()
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Amenities.ToList();
            }
        }

        public void Update(Amenity item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var amenity = houseRentalsDBContext.Amenities.Find(item.AmenityId);
                if (amenity != null)
                {
                    houseRentalsDBContext.Entry(amenity).CurrentValues.SetValues(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }
    }
}
