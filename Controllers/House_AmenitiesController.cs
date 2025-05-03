using house_rentals.Bussines;
using house_rentals.Date;
using house_rentals.Date.Models;
using House_Rentals.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Controllers
{
    public class House_AmenitiesController : IController<House_Amenity>
    {
        private ICRUD<House_Amenity> house_AmenitiesBusiness = new House_AmenitiesBusiness();

        public House_AmenitiesController() { }

        public House_AmenitiesController(ICRUD<House_Amenity> house_AmenitiesBusiness)
        {
            this.house_AmenitiesBusiness = house_AmenitiesBusiness;
        }

        //public void Add(House_Amenity newHouse_Amenities)
        //{
        //    House_Amenity house_Amenity = house_AmenitiesBusiness.Get(newHouse_Amenities);
        //    if (house_Amenity != null)
        //    {
        //        house_AmenitiesBusiness.Add(newHouse_Amenities);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("House amenity with this ID already exists.");
        //    }
        //}

        public void Add(House_Amenity houseAmenity)
        {
            using var db = new HouseRentalsDBContext();

            bool alreadyExists = db.House_Amenities.Any(h => h.HouseId == houseAmenity.HouseId && h.AmenityId == houseAmenity.AmenityId);

            if (alreadyExists)
            {
                throw new Exception("This house is already connected to this amenity.");
            }

            db.House_Amenities.Add(houseAmenity);
            db.SaveChanges();
        }

        public void Delete(House_Amenity findHouse_Amenity)
        {
            House_Amenity house_Amenity = house_AmenitiesBusiness.Get(findHouse_Amenity);
            if (house_Amenity == null)
            {
                house_AmenitiesBusiness.Delete(findHouse_Amenity);
            }
            else
            {
                throw new ArgumentException("House amenity not found.");
            }
        }

        public House_Amenity Get(House_Amenity findHouse_Amenity)
        {
            return house_AmenitiesBusiness.GetAll().FirstOrDefault(x =>x.HouseId == findHouse_Amenity.HouseId && x.AmenityId == findHouse_Amenity.AmenityId);
        }

        public List<House_Amenity> ListAll()
        {
            var house_Amenities = house_AmenitiesBusiness.GetAll();
            if (house_Amenities.Count > 0)
            {
                return house_Amenities;
            }
            else
            {
                throw new ArgumentException("The house amenities list is empty.");
            }
        }

        public void Update(House_Amenity findHouse_Amenity)
        {
            House_Amenity house_Amenity = house_AmenitiesBusiness.Get(findHouse_Amenity);
            if (house_Amenity != null)
            {
                house_AmenitiesBusiness.Update(findHouse_Amenity);
            }
            else
            {
                throw new ArgumentException("House amenity not found.");
            }
        }
    }
}
