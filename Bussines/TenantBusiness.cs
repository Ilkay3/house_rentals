using house_rentals.Date.Models;
using house_rentals.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Bussines
{
    internal class TenantBusiness : ICRUD<Tenant>
    {
        private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

        public TenantBusiness() { }

        public void Add(Tenant item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                houseRentalsDBContext.Tenants.Add(item);
                houseRentalsDBContext.SaveChanges();
            }
        }

        public void Delete(Tenant item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var tenant = houseRentalsDBContext.Tenants.Find(item.TenantId);
                if (tenant != null)
                {
                    houseRentalsDBContext.Tenants.Remove(tenant);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }

        public Tenant Get(Tenant item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Tenants.Where(x => x.TenantId == item.TenantId).FirstOrDefault();
            }
        }

        public List<Tenant> GetAll()
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Tenants.ToList();
            }
        }

        public void Update(Tenant item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var tenant = houseRentalsDBContext.Tenants.Find(item.TenantId);
                if (tenant != null)
                {
                    houseRentalsDBContext.Entry(tenant).CurrentValues.SetValues(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }
    }
}
