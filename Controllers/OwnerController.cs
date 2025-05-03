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
    public class OwnerController : IController<Owner>
    {
        private ICRUD<Owner> ownerBusiness = new OwnerBusiness();

        public OwnerController() { }

        public OwnerController(ICRUD<Owner> ownerBusiness)
        {
            this.ownerBusiness = ownerBusiness;
        }

        public void Add(Owner newOwner)
        {
            Owner owner = ownerBusiness.Get(newOwner);
            if (owner != null)
            {
                throw new ArgumentException("Owner with this ID already exists.");
            }
            ownerBusiness.Add(newOwner);
        }

        public void Delete(Owner findOwner)
        {
            Owner owner = ownerBusiness.Get(findOwner);
            if (owner != null)
            {
                ownerBusiness.Delete(findOwner);
            }
            else
            {
                throw new ArgumentException("Owner not found.");
            }
        }

        public Owner Get(Owner findOwner)
        {
            Owner owner = ownerBusiness.Get(findOwner);
            if (owner != null)
            {
                return owner;
            }
            else
            {
                throw new ArgumentException("Owner not found.");
            }
        }

        public List<Owner> ListAll()
        {
            var owners = ownerBusiness.GetAll();
            if (owners.Count > 0)
            {
                return owners;
            }
            else
            {
                throw new ArgumentException("The owners list is empty.");
            }
        }

        public void Update(Owner findOwner)
        {
            Owner owner = ownerBusiness.Get(findOwner);
            if (owner != null)
            {
                ownerBusiness.Update(findOwner);
            }
            else
            {
                throw new ArgumentException("Owner not found.");
            }
        }
    }
}
