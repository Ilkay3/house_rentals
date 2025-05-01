using house_rentals.Date.Models;
using house_rentals.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Bussines
{
    public class OwnerBusiness : ICRUD<Owner>
    {
        private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

        public OwnerBusiness() { }

        public void Add(Owner item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                houseRentalsDBContext.Owners.Add(item);
                houseRentalsDBContext.SaveChanges();
            }
        }

        public void Delete(Owner item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var owner = houseRentalsDBContext.Owners.Find(item.OwnerId);
                if (owner != null)
                {
                    houseRentalsDBContext.Owners.Remove(owner);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }

        public Owner Get(Owner item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Owners.Where(x => x.OwnerId == item.OwnerId).FirstOrDefault();
            }
        }

        public List<Owner> GetAll()
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Owners.ToList();
            }
        }

        public void Update(Owner item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var owner = houseRentalsDBContext.Owners.Find(item.OwnerId);
                if (owner != null)
                {
                    houseRentalsDBContext.Entry(owner).CurrentValues.SetValues(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }
    }
}
