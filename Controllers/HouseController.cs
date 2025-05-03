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
    public class HouseController : IController<House>
    {
        private ICRUD<House> houseBusiness = new HouseBusiness();

        public HouseController() { }

        public HouseController(ICRUD<House> houseBusiness)
        {
            this.houseBusiness = houseBusiness;
        }

        public void Add(House newHouse)
        {
            House house = houseBusiness.Get(newHouse);
            if (house != null)
            {
                throw new ArgumentException("House with this ID already exists.");
            }
            houseBusiness.Add(newHouse);
        }

        public void Delete(House findHouse)
        {
            House house = houseBusiness.Get(findHouse);
            if (house != null)
            {
                houseBusiness.Delete(findHouse);
            }
            else
            {
                throw new ArgumentException("House not found.");
            }
        }

        public House Get(House findHouse)
        {
            House house = houseBusiness.Get(findHouse);
            if (house != null)
            {
                return house;
            }
            else
            {
                throw new ArgumentException("House not found.");
            }
        }

        public List<House> ListAll()
        {
            var houses = houseBusiness.GetAll();
            if (houses.Count > 0)
            {
                return houses;
            }
            else
            {
                throw new ArgumentException("The houses list is empty.");
            }
        }

        public void Update(House findHouse)
        {
            House house = houseBusiness.Get(findHouse);
            if (house != null)
            {
                houseBusiness.Update(findHouse);
            }
            else
            {
                throw new ArgumentException("House not found.");
            }
        }
    }
}
