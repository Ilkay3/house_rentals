using house_rentals.Controllers;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    public class HouseDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<House> houseController = new HouseController();

        public HouseDisplay()
        {
            Input();
        }

        public HouseDisplay(IController<House> houseController)
        {
            Input();
            this.houseController = houseController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU HOUSES" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add House");
            Console.WriteLine("2. Delete House");
            Console.WriteLine("3. Update House");
            Console.WriteLine("4. Extract House");
            Console.WriteLine("5. List All Houses");
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
                        Console.WriteLine("Exiting House Menu...");
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
                House newHouse = new House();
                do
                {
                    Console.WriteLine("Enter house Id: ");
                    newHouse.HouseId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newHouse.HouseId));

                do
                {
                    Console.WriteLine("Enter house address: ");
                    newHouse.Address = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newHouse.Address));

                do
                {
                    Console.WriteLine("Enter description: ");
                    newHouse.Description = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newHouse.Description));

                do
                {
                    Console.WriteLine("Enter price: ");
                    newHouse.Price = double.Parse(Console.ReadLine());
                }
                while (Validators.IsDoubleNoValid(newHouse.Price));

                do
                {
                    Console.WriteLine("Enter city ID: ");
                    newHouse.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newHouse.CityId));

                do
                {
                    Console.WriteLine("Enter owner ID: ");
                    newHouse.OwnerId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newHouse.OwnerId));

                houseController.Add(newHouse);
                Console.WriteLine("House added to database.");
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
                House findHouse = new House();
                do
                {
                    Console.WriteLine("Enter house Id to delete: ");
                    findHouse.HouseId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findHouse.HouseId));

                houseController.Delete(findHouse);
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
                House findHouse = new House();
                do
                {
                    Console.WriteLine("Enter house Id to update: ");
                    findHouse.HouseId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findHouse.HouseId));
                
                do
                {
                    Console.WriteLine("Enter house name: ");
                    findHouse.Address = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findHouse.Address));

                do
                {
                    Console.WriteLine("Enter description: ");
                    findHouse.Description = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findHouse.Description));

                do
                {
                    Console.WriteLine("Enter price: ");
                    findHouse.Price = double.Parse(Console.ReadLine());
                }   
                while (Validators.IsDoubleNoValid(findHouse.Price));

                do
                {
                    Console.WriteLine("Enter city ID: ");
                    findHouse.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findHouse.CityId));

                do
                {
                    Console.WriteLine("Enter owner ID: ");
                    findHouse.OwnerId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findHouse.OwnerId));

                houseController.Update(findHouse);
                Console.WriteLine("House update to database.");
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
                House findHouse = new House();
                do
                {
                    Console.WriteLine("Enter house Id to extract: ");
                    findHouse.HouseId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findHouse.HouseId));

                do
                {
                    Console.WriteLine("Enter house name: ");
                    findHouse.Address = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findHouse.Address));

                do
                {
                    Console.WriteLine("Enter description: ");
                    findHouse.Description = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findHouse.Description));

                do
                {
                    Console.WriteLine("Enter price: ");
                    findHouse.Price = double.Parse(Console.ReadLine());
                }
                while (Validators.IsDoubleNoValid(findHouse.Price));

                do
                {
                    Console.WriteLine("Enter city ID: ");
                    findHouse.CityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findHouse.CityId));

                do
                {
                    Console.WriteLine("Enter owner ID: ");
                    findHouse.OwnerId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findHouse.OwnerId));

                House house = houseController.Get(findHouse);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("House ID: " + house.HouseId);
                Console.WriteLine("Address: " + house.Address);
                Console.WriteLine("Description: " + house.Description);
                Console.WriteLine("Price: " + house.Price);
                Console.WriteLine("City ID: " + house.CityId);
                Console.WriteLine("Owner ID: " + house.OwnerId);
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
                Console.WriteLine(new string(' ', 16) + "HOUSES" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var houses = houseController.ListAll();
                foreach (var house in houses)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("House ID: " + house.HouseId);
                    Console.WriteLine("Address: " + house.Address);
                    Console.WriteLine("Description: " + house.Description);
                    Console.WriteLine("Price: " + house.Price);
                    Console.WriteLine("City ID: " + house.CityId);
                    Console.WriteLine("Owner ID: " + house.OwnerId);
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
