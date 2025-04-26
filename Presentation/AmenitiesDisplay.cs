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
 /*   public class AmenityDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private AmenityController controller = new AmenityController();

        public AmenityDisplay(IController<Amenity> amenityController)
        {
            Input();
            this.AmenityController = amenityController;
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
            Console.Write("Enter your choice: ");
            int operation = operation = int.Parse(Console.ReadLine());
            do
            {
                ShowMenu();
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
                    case 0:
                        Console.WriteLine("Exiting Amenity Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (operation != 0);
        }

        public void Add()
        {
            try
            {
                Amenity amenity = new Amenity();
                do 
                {
                    Console.WriteLine("Enter amanity Id: ");
                    new Amenity.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Amenity added successfully!");
                }
                while (Validators.IsIntNoValid(newAmenity.Id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete()
        {
            Console.Write("Enter Amenity ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                controller.Delete(new Amenity { AmenityId = id });
                Console.WriteLine("Amenity deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update()
        {
            Console.Write("Enter Amenity ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Amenity Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Amenity amenity = new Amenity { AmenityId = id, Name = name };
            try
            {
                controller.Update(amenity);
                Console.WriteLine("Amenity updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Extract()
        {
            Console.Write("Enter Amenity ID to extract: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                var amenity = controller.Get(new Amenity { AmenityId = id });
                Console.WriteLine($"Amenity: ID = {amenity.AmenityId}, Name = {amenity.Name}");
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
                var amenities = controller.ListAll();
                Console.WriteLine("\nList of Amenities:");
                foreach (var a in amenities)
                {
                    Console.WriteLine($"ID: {a.AmenityId}, Name: {a.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
 */
}
