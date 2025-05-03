using house_rentals.Bussines;
using house_rentals.Date.Models;
using House_Rentals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Controllers
{
    public class BookingController : IController<Booking>
    {
        private ICRUD<Booking> bookingBusiness = new BookingBusiness();

        public BookingController() { }

        public BookingController(ICRUD<Booking> bookingBusiness)
        {
            this.bookingBusiness = bookingBusiness;
        }

        public void Add(Booking newBooking)
        {
            Booking booking = bookingBusiness.Get(newBooking);
            if (booking != null)
            {
                throw new ArgumentException("Booking with this ID already exists.");
            }
            bookingBusiness.Add(newBooking);
        }

        public void Delete(Booking findBooking)
        {
            Booking booking = bookingBusiness.Get(findBooking);
            if (booking != null)
            {
                bookingBusiness.Delete(findBooking);
            }
            else
            {
                throw new ArgumentException("Booking not found.");
            }
        }

        public Booking Get(Booking findBooking)
        {
            Booking booking = bookingBusiness.Get(findBooking);
            if (booking != null)
            {
                return booking;
            }
            else
            {
                throw new ArgumentException("Booking not found.");
            }
        }

        public List<Booking> ListAll()
        {
            var bookings = bookingBusiness.GetAll();
            if (bookings.Count > 0)
            {
                return bookings;
            }
            else
            {
                throw new ArgumentException("The bookings list is empty.");
            }
        }

        public void Update(Booking findBooking)
        {
            Booking booking = bookingBusiness.Get(findBooking);
            if (booking != null)
            {
                bookingBusiness.Update(findBooking);
            }
            else
            {
                throw new ArgumentException("Booking not found.");
            }
        }
    }
}
