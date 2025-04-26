using house_rentals.Date.Models;
using house_rentals.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Bussines
{
    internal class PaymentBusiness : ICRUD<Payment>
    {
        private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

        public PaymentBusiness(HouseRentalsDBContext houseRentalsDBContext)
        {
            this.houseRentalsDBContext = houseRentalsDBContext;
        }

        public void Add(Payment item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                houseRentalsDBContext.Payments.Add(item);
                houseRentalsDBContext.SaveChanges();
            }
        }

        public void Delete(Payment item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var payment = houseRentalsDBContext.Payments.Find(item.PaymentId);
                if (payment != null)
                {
                    houseRentalsDBContext.Payments.Remove(payment);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }

        public Payment Get(Payment item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Payments.Where(x => x.PaymentId == item.PaymentId).FirstOrDefault();
            }
        }

        public List<Payment> GetAll()
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                return houseRentalsDBContext.Payments.ToList();
            }
        }

        public void Update(Payment item)
        {
            using (houseRentalsDBContext = new HouseRentalsDBContext())
            {
                var payment = houseRentalsDBContext.Payments.Find(item.PaymentId);
                if (payment != null)
                {
                    houseRentalsDBContext.Entry(payment).CurrentValues.SetValues(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }
        }
    }
}
