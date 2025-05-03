using house_rentals.Controllers;
using house_rentals.Date.Models;
using House_Rentals.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    public class PaymentDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Payment> paymentController = new PaymentController();

        public PaymentDisplay()
        {
            Input();
        }

        public PaymentDisplay(IController<Payment> paymentController)
        {
            Input();
            this.paymentController = paymentController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU PAYMENTS" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add Payment");
            Console.WriteLine("2. Delete Payment");
            Console.WriteLine("3. Update Payment");
            Console.WriteLine("4. Extract Payment");
            Console.WriteLine("5. List All Payments");
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
                        Console.WriteLine("Exiting Payment Menu...");
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
                Payment newPayment = new Payment();
                do
                {
                    Console.WriteLine("Enter payment Id: ");
                    newPayment.PaymentId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newPayment.PaymentId));

                do
                {
                    Console.WriteLine("Enter booking Id: ");
                    newPayment.BookingId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newPayment.BookingId));

                do
                {
                    Console.WriteLine("Enter PaymentDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime paymentDate))
                    {
                        newPayment.PaymentDate = paymentDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(newPayment.PaymentDate));

                do
                {
                    Console.WriteLine("Enter payment method: ");
                    newPayment.PaymentMethod = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newPayment.PaymentMethod));

                paymentController.Add(newPayment);
                Console.WriteLine("Payment added to database.");
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
                Payment findPayment = new Payment();
                do
                {
                    Console.WriteLine("Enter payment Id to delete: ");
                    findPayment.PaymentId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findPayment.PaymentId));

                paymentController.Delete(findPayment);
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
                Payment findPayment = new Payment();
                do
                {
                    Console.WriteLine("Enter payment Id to update: ");
                    findPayment.PaymentId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findPayment.PaymentId));

                do
                {
                    Console.WriteLine("Enter booking Id: ");
                    findPayment.BookingId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findPayment.BookingId));

                do
                {
                    Console.WriteLine("Enter PaymentDate (format: dd-mm-yyyy): ");
                    string input = Console.ReadLine();

                    if (DateTime.TryParse(input, out DateTime paymentDate))
                    {
                        findPayment.PaymentDate = paymentDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
                while (Validators.IsDateNoValid(findPayment.PaymentDate));

                do
                {
                    Console.WriteLine("Enter payment method: ");
                    findPayment.PaymentMethod = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findPayment.PaymentMethod));

                paymentController.Update(findPayment);
                Console.WriteLine("Payment update to database.");
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
                Payment findPayment = new Payment();
                do
                {
                    Console.WriteLine("Enter payment Id to extract: ");
                    findPayment.PaymentId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findPayment.PaymentId));

                Payment payment = paymentController.Get(findPayment);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Payment ID: " + payment.PaymentId);
                Console.WriteLine("Booking ID: " + payment.BookingId);
                Console.WriteLine("Payment Date: " + payment.PaymentDate);
                Console.WriteLine("Payment Method: " + payment.PaymentMethod);
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
                Console.WriteLine(new string(' ', 16) + "PAYMENTS" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var payments = paymentController.ListAll();
                foreach (var payment in payments)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Payment ID: " + payment.PaymentId);
                    Console.WriteLine("Booking ID: " + payment.BookingId);
                    Console.WriteLine("Payment Date: " + payment.PaymentDate);
                    Console.WriteLine("Payment Method: " + payment.PaymentMethod);
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
