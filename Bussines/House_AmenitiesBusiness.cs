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
    /*
        public class House_AmenitiesBusiness : ICRUD<House_Amenity>
        {
            private HouseRentalsDBContext dbContext = new HouseRentalsDBContext();

            public House_AmenitiesBusiness(HouseRentalsDBContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public void Add(House_Amenity item)
            {
                using (dbContext = new HouseRentalsDBContext())
                {
                    dbContext.House_Amenities.Add(item);
                    dbContext.SaveChanges();
                }
            }

            public void Delete(House_Amenity item)
            {
                using (dbContext = new HouseRentalsDBContext())
                {
                    var house_amenity = dbContext.House_Amenities.Find(item.House_AmenityId);
                    if (house_amenity != null)
                    {
                        dbContext.House_Amenities.Remove(house_amenity);
                        dbContext.SaveChanges();
                    }
                }
            }

            public House_Amenity Get(City item)
            {
                using (dbContext = new HouseRentalsDBContext())
                {
                    return dbContext.House_Amenities.Where(x => x.House_AmenityId == item.House_AmenityId).FirstOrDefault();
                }
            }

            public List<House_Amenity> GetAll()
            {
                using (dbContext = new HouseRentalsDBContext())
                {
                    return dbContext.House_Amenities.ToList();
                }
            }

            public void Update(House_Amenity item)
            {
                using (dbContext = new HouseRentalsDBContext())
                {
                    var house_amenity = dbContext.House_Amenities.Find(item.House_AmenityId);
                    if (house_amenity != null)
                    {
                        dbContext.Entry(city).CurrentValues.SetValues(item);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    */
}
