using house_rentals.Date.Models;
using house_rentals.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Bussines
{
    public class HouseBusiness : ICRUD<House>
    {
        private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

        public HouseBusiness(HouseRentalsDBContext houseRentalsDBContext)
        {
            this.houseRentalsDBContext = houseRentalsDBContext;
        }

        public void Add(House item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                houseRentalsDBContext.Houses.Add(item);
                houseRentalsDBContext.SaveChanges();
            }
        }

        public void Delete(House item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var house = houseRentalsDBContext.Houses.Find(item.HouseId);
                if (house != null)
                {
                    houseRentalsDBContext.Houses.Remove(house);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }

        public House Get(House item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Houses.Where(x => x.HouseId == item.HouseId).FirstOrDefault();
            }
        }

        public List<House> GetAll()
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Houses.ToList();
            }
        }

        public void Update(House item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var house = houseRentalsDBContext.Houses.Find(item.HouseId);
                if (house != null)
                {
                    houseRentalsDBContext.Entry(house).CurrentValues.SetValues(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }
    }
}
