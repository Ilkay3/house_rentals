using house_rentals.Controllers;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    public class BookingDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Booking> bookingController = new BookingController();

        public BookingDisplay()
        {
            Input();
        }

        public BookingDisplay(IController<Booking> bookingController)
        {
            Input();
            this.bookingController = bookingController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU BOOKING" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add Booking");
            Console.WriteLine("2. Delete Booking");
            Console.WriteLine("3. Update Booking");
            Console.WriteLine("4. Extract Booking");
            Console.WriteLine("5. List All Bookings");
            Console.WriteLine("6. Exit");
        }

        public void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Delete();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Extract();
                        break;
                    case 5:
                        ListAll();
                        break;
                    case 6:
                        Console.WriteLine("Exiting Booking Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (operation != closeOperationId);
        }

        public void Add()
        {
            try
            {
                Booking newBooking = new Booking();
                do
                {
                    Console.WriteLine("Enter booking Id: ");
                    newBooking.BookingId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newBooking.BookingId));

                do
                {
                    Console.WriteLine("Enter house Id: ");
                    newBooking.HouseId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newBooking.HouseId));

                do
                {
                    Console.WriteLine("Enter tenant Id: ");
                    newBooking.TenantId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newBooking.TenantId));

                do
                {
                    Console.WriteLine("Enter StartDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime startDate))
                    {
                        newBooking.StartDate = startDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(newBooking.StartDate));

                do
                {
                    Console.WriteLine("Enter EndDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime endDate))
                    {
                        newBooking.EndDate = endDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(newBooking.EndDate));

                bookingController.Add(newBooking);
                Console.WriteLine("Booking added to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                Booking findBooking = new Booking();
                do
                {
                    Console.WriteLine("Enter booking Id to delete: ");
                    findBooking.BookingId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findBooking.BookingId));

                //do
                //{
                //    Console.WriteLine("Enter house Id: ");
                //    findBooking.HouseId = int.Parse(Console.ReadLine());
                //}
                //while (Validators.IsIntNoValid(findBooking.HouseId));

                //do
                //{
                //    Console.WriteLine("Enter tenant Id: ");
                //    findBooking.TenantId = int.Parse(Console.ReadLine());
                //}
                //while (Validators.IsIntNoValid(findBooking.TenantId));

                //do
                //{
                //    Console.WriteLine("Enter StartDate (format: dd-mm-yyyy): ");
                //    string input = Console.ReadLine();

                //    if (DateTime.TryParse(input, out DateTime startDate))
                //    {
                //        findBooking.StartDate = startDate;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Invalid date format. Please try again.");
                //    }
                //}
                //while (Validators.IsDateNoValid(findBooking.StartDate));

                //do
                //{
                //    Console.WriteLine("Enter EndDate (format: dd-mm-yyyy): ");
                //    string input = Console.ReadLine();

                //    if (DateTime.TryParse(input, out DateTime endDate))
                //    {
                //        findBooking.EndDate = endDate;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Invalid date format. Please try again.");
                //    }
                //}
                //while (Validators.IsDateNoValid(findBooking.EndDate));

                bookingController.Delete(findBooking);
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update()
        {
            try
            {
                Booking findBooking = new Booking();
                do
                {
                    Console.WriteLine("Enter booking Id to update: ");
                    findBooking.BookingId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findBooking.BookingId));

                do
                {
                    Console.WriteLine("Enter house Id: ");
                    findBooking.HouseId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findBooking.HouseId));

                do
                {
                    Console.WriteLine("Enter tenant Id: ");
                    findBooking.TenantId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findBooking.TenantId));

                do
                {
                    Console.WriteLine("Enter StartDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime startDate))
                    {
                        findBooking.StartDate = startDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(findBooking.StartDate));

                do
                {
                    Console.WriteLine("Enter EndDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime endDate))
                    {
                        findBooking.EndDate = endDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(findBooking.EndDate));

                bookingController.Update(findBooking);
                Console.WriteLine("Booking update to database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Extract()
        {
            try
            {
                Booking findBooking = new Booking();
                do
                {
                    Console.WriteLine("Enter booking Id to extract: ");
                    findBooking.BookingId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findBooking.BookingId));

                do
                {
                    Console.WriteLine("Enter house Id: ");
                    findBooking.HouseId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findBooking.HouseId));

                do
                {
                    Console.WriteLine("Enter tenant Id: ");
                    findBooking.TenantId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findBooking.TenantId));

                do
                {
                    Console.WriteLine("Enter StartDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime startDate))
                    {
                        findBooking.StartDate = startDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(findBooking.StartDate));

                do
                {
                    Console.WriteLine("Enter EndDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime endDate))
                    {
                        findBooking.EndDate = endDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(findBooking.EndDate));

                Booking booking = bookingController.Get(findBooking);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Booking ID: " + booking.BookingId);
                Console.WriteLine("House ID: " + booking.HouseId);
                Console.WriteLine("Tenant ID: " + booking.TenantId);
                Console.WriteLine("StartDate: " + booking.StartDate);
                Console.WriteLine("EndDate: " + booking.EndDate);
                Console.WriteLine(new string('-', 40));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListAll()
        {
            try
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 16) + "BOOKINGS" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var bookings = bookingController.ListAll();
                foreach (var booking in bookings)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Booking ID: " + booking.BookingId);
                    Console.WriteLine("House ID: " + booking.HouseId);
                    Console.WriteLine("Tenant ID: " + booking.TenantId);
                    Console.WriteLine("StartDate: " + booking.StartDate);
                    Console.WriteLine("EndDate: " + booking.EndDate);
                    Console.WriteLine(new string('-', 40));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
