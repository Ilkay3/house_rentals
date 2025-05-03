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
    public class CityController : IController<City>
    {
        private ICRUD<City> cityBusiness = new CityBusiness();

        public CityController() { }

        public CityController(ICRUD<City> cityBusiness)
        {
            this.cityBusiness = cityBusiness;
        }

        public void Add(City newCity)
        {
            City city = cityBusiness.Get(newCity);
            if (city != null)
            {
                throw new ArgumentException("City with this ID already exists.");
            }
            cityBusiness.Add(newCity);
        }

        public void Delete(City findCity)
        {
            City city = cityBusiness.Get(findCity);
            if (city != null)
            {
                cityBusiness.Delete(findCity);
            }
            else
            {
                throw new ArgumentException("City not found.");
            }
        }

        public City Get(City findCity)
        {
            City city = cityBusiness.Get(findCity);
            if (city != null)
            {
                return city;
            }
            else
            {
                throw new ArgumentException("City not found.");
            }
        }

        public List<City> ListAll()
        {
            var cities = cityBusiness.GetAll();
            if (cities.Count > 0)
            {
                return cities;
            }
            else
            {
                throw new ArgumentException("The cities list is empty.");
            }
        }

        public void Update(City findCity)
        {
            City city = cityBusiness.Get(findCity);
            if (city != null)
            {
                cityBusiness.Update(findCity);
            }
            else
            {
                throw new ArgumentException("City not found.");
            }
        }
    }
}
