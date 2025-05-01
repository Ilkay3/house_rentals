using house_rentals.Bussines;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Controllers
{
    public class PaymentController : IController<Payment>
    {
        private ICRUD<Payment> paymentBusiness = new PaymentBusiness();

        public PaymentController() { }

        public PaymentController(ICRUD<Payment> paymentBusiness)
        {
            this.paymentBusiness = paymentBusiness;
        }

        public void Add(Payment newPayment)
        {
            Payment payment = paymentBusiness.Get(newPayment);
            if (payment != null)
            {
                throw new ArgumentException("Payment with this ID already exists.");
            }
            paymentBusiness.Add(newPayment);
        }

        public void Delete(Payment findPayment)
        {
            Payment payment = paymentBusiness.Get(findPayment);
            if (payment != null)
            {
                paymentBusiness.Delete(findPayment);
            }
            else
            {
                throw new ArgumentException("Payment not found.");
            }
        }

        public Payment Get(Payment findPayment)
        {
            Payment payment = paymentBusiness.Get(findPayment);
            if (payment != null)
            {
                return payment;
            }
            else
            {
                throw new ArgumentException("Payment not found.");
            }
        }

        public List<Payment> ListAll()
        {
            var payments = paymentBusiness.GetAll();
            if (payments.Count > 0)
            {
                return payments;
            }
            else
            {
                throw new ArgumentException("The payments list is empty.");
            }
        }

        public void Update(Payment findPayment)
        {
            Payment payment = paymentBusiness.Get(findPayment);
            if (payment != null)
            {
                paymentBusiness.Update(findPayment);
            }
            else
            {
                throw new ArgumentException("Payment not found.");
            }
        }
    }
}
