using house_rentals.Date.Models;
using house_rentals.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Bussines
{
        public class BookingBusiness : ICRUD<Booking>
        {
            private HouseRentalsDBContext houseRentalsDBContext = new HouseRentalsDBContext();

            public BookingBusiness(HouseRentalsDBContext houseRentalsDBContext)
            {
                this.houseRentalsDBContext = houseRentalsDBContext;
            }

            public void Add(Booking item)
            {
                using (houseRentalsDBContext = new HouseRentalsDBContext())
                {
                    houseRentalsDBContext.Bookings.Add(item);
                    houseRentalsDBContext.SaveChanges();
                }
            }

            public void Delete(Booking item)
            {
                using (houseRentalsDBContext = new HouseRentalsDBContext())
                {
                    var booking = houseRentalsDBContext.Bookings.Find(item.BookingId);
                    if (booking != null)
                    {
                        houseRentalsDBContext.Bookings.Remove(booking);
                        houseRentalsDBContext.SaveChanges();
                    }
                }
            }

            public Booking Get(Booking item)
            {
                using (houseRentalsDBContext = new HouseRentalsDBContext())
                {
                    return houseRentalsDBContext.Bookings.Where(x => x.BookingId == item.BookingId).FirstOrDefault();
                }
            }

            public List<Booking> GetAll()
            {
                using (houseRentalsDBContext = new HouseRentalsDBContext())
                {
                    return houseRentalsDBContext.Bookings.ToList();
                }
            }

            public void Update(Booking item)
            {
                using (houseRentalsDBContext = new HouseRentalsDBContext())
                {
                    var booking = houseRentalsDBContext.Bookings.Find(item.BookingId);
                    if (booking != null)
                    {
                        houseRentalsDBContext.Entry(booking).CurrentValues.SetValues(item);
                        houseRentalsDBContext.SaveChanges();
                    }
                }
            }
        }
}
