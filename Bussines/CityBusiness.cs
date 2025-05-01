using house_rentals.Date.Models;
using house_rentals.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Bussines
{
    public class CityBusiness : ICRUD<City>
    {
        private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

        public CityBusiness() { }

        public void Add(City item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                houseRentalsDBContext.Cities.Add(item);
                houseRentalsDBContext.SaveChanges();
            }
        }

        public void Delete(City item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var city = houseRentalsDBContext.Cities.Find(item.CityId);
                if (city != null)
                {
                    houseRentalsDBContext.Cities.Remove(city);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }

        public City Get(City item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Cities.Where(x => x.CityId == item.CityId).FirstOrDefault();
            }
        }

        public List<City> GetAll()
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Cities.ToList();
            }
        }

        public void Update(City item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var city = houseRentalsDBContext.Cities.Find(item.CityId);
                if (city != null)
                {
                    houseRentalsDBContext.Entry(city).CurrentValues.SetValues(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }
    }
}
