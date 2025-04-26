using house_rentals.Bussines;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Controllers
{
        public class AmenityController : IController<Amenity>
        {
            private ICRUD<Amenity> amenityBusiness = new AmenityBusiness();

            public AmenityController() { }

            public AmenityController(ICRUD<Amenity> amenityBusiness)
            {
                this.amenityBusiness = amenityBusiness;
            }

            public void Add(Amenity newAmenity)
            {
                Amenity amenity = amenityBusiness.Get(newAmenity);
                if (amenity != null)
                {
                    throw new ArgumentException("Amenity with this ID already exists.");
                }
                amenityBusiness.Add(newAmenity);
            }

            public void Delete(Amenity findAmenity)
            {
                Amenity amenity = amenityBusiness.Get(findAmenity);
                if (amenity != null)
                {
                    amenityBusiness.Delete(findAmenity);
                }
                else
                {
                    throw new ArgumentException("Amenity not found.");
                }
            }

            public Amenity Get(Amenity findAmenity)
            {
                Amenity amenity = amenityBusiness.Get(findAmenity);
                if (amenity != null)
                {
                    return amenity;
                }
                else
                {
                    throw new ArgumentException("Amenity not found.");
                }
            }

            public List<Amenity> ListAll()
            {
                var amenities = amenityBusiness.GetAll();
                if (amenities.Count > 0)
                {
                    return amenities;
                }
                else
                {
                    throw new ArgumentException("The amenities list is empty.");
                }
            }

            public void Update(Amenity findAmenity)
            {
                Amenity amenity = amenityBusiness.Get(findAmenity);
                if (amenity != null)
                {
                    amenityBusiness.Update(findAmenity);
                }
                else
                {
                    throw new ArgumentException("Amenity not found.");
                }
            }
        }
}
