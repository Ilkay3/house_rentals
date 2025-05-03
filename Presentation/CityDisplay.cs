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
    public class CityDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<City> cityController = new CityController();

        public CityDisplay()
        {
            Input();
        }

        public CityDisplay(IController<City> cityController)
        {
            Input();
            this.cityController = cityController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU CITIES" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add City");
            Console.WriteLine("2. Delete City");
            Console.WriteLine("3. Update City");
            Console.WriteLine("4. Extract City");
            Console.WriteLine("5. List All Cities");
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
                        Console.WriteLine("Exiting City Menu...");
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
                City newCity = new City();
                do
                {
                    Console.WriteLine("Enter city Id: ");
                    newCity.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newCity.CityId));

                do
                {
                    Console.WriteLine("Enter city name: ");
                    newCity.Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newCity.Name));

                cityController.Add(newCity);
                Console.WriteLine("City added to database.");
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
                City findCity = new City();
                do
                {
                    Console.WriteLine("Enter city Id to delete: ");
                    findCity.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findCity.CityId));

                cityController.Delete(findCity);
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
                City findCity = new City();
                do
                {
                    Console.WriteLine("Enter city Id to update: ");
                    findCity.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findCity.CityId));
                do
                {
                    Console.WriteLine("Enter city name: ");
                    findCity.Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findCity.Name));

                cityController.Update(findCity);
                Console.WriteLine("City update to database.");
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
                City findCity = new City();
                do
                {
                    Console.WriteLine("Enter city Id to extract: ");
                    findCity.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findCity.CityId));

                City city = cityController.Get(findCity);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("City ID: " + city.CityId);
                Console.WriteLine("Name: " + city.Name);
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
                Console.WriteLine(new string(' ', 16) + "CITIES" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var cities = cityController.ListAll();
                foreach (var city in cities)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("City ID: " + city.CityId);
                    Console.WriteLine("Name: " + city.Name);
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
