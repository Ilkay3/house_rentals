using house_rentals.Controllers;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
   public class AmenityDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Amenity> amenityController = new AmenityController();

        public AmenityDisplay()
        {
            Input();
        }

        public AmenityDisplay(IController<Amenity> amenityController)
        {
            Input();
            this.amenityController = amenityController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU AMENITIES" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add Amenity");
            Console.WriteLine("2. Delete Amenity");
            Console.WriteLine("3. Update Amenity");
            Console.WriteLine("4. Extract Amenity");
            Console.WriteLine("5. List All Amenities");
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
                        Console.WriteLine("Exiting Amenity Menu...");
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
                Amenity newAmenity = new Amenity();
                do
                {
                    Console.WriteLine("Enter amenity Id: ");
                    newAmenity.AmenityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newAmenity.AmenityId));
                
                do
                {
                    Console.WriteLine("Enter amenity name: ");
                    newAmenity.Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newAmenity.Name));
                
                amenityController.Add(newAmenity);
                Console.WriteLine("Amenity added to database.");
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
                Amenity findAmenity = new Amenity();
                do
                {
                    Console.WriteLine("Enter amenity Id to delete: ");
                    findAmenity.AmenityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAmenity.AmenityId));

                amenityController.Delete(findAmenity);
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
                Amenity findAmenity = new Amenity();
                do
                {
                    Console.WriteLine("Enter amenity Id to update: ");
                    findAmenity.AmenityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAmenity.AmenityId));
                do
                {
                    Console.WriteLine("Enter amenity name: ");
                    findAmenity.Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findAmenity.Name));

                amenityController.Update(findAmenity);
                Console.WriteLine("Amenity update to database.");
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
                Amenity findAmenity = new Amenity();
                do
                {
                    Console.WriteLine("Enter amenity Id to extract: ");
                    findAmenity.AmenityId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findAmenity.AmenityId));

                Amenity amenity = amenityController.Get(findAmenity);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Amenity ID: " + amenity.AmenityId);
                Console.WriteLine("Name: " + amenity.Name);
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
                Console.WriteLine(new string(' ', 16) + "AMENITIES" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var amenities = amenityController.ListAll();
                foreach (var amenity in amenities)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Amenity ID: " + amenity.AmenityId);
                    Console.WriteLine("Name: " + amenity.Name);
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
