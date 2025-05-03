//using house_rentals.Controllers;
//using house_rentals.Date;
//using house_rentals.Date.Models;
//using House_Rentals.Controllers;
//using House_Rentals.Presentation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace house_rentals.Presentation
//{
//    public class House_AmenitiesDisplay : IDisplay
//    {
//        private int closeOperationId = 6;
//        private IController<House_Amenity> house_AmenitiesController = new House_AmenitiesController();

//        public House_AmenitiesDisplay()
//        {
//            Input();
//        }

//        public House_AmenitiesDisplay(IController<House_Amenity> house_AmenitiesController)
//        {
//            Input();
//            this.house_AmenitiesController = house_AmenitiesController;
//        }

//        public void ShowMenu()
//        {
//            Console.WriteLine(new string('-', 40));
//            Console.WriteLine(new string(' ', 8) + "MENU HOUSE AMENITIES" + new string(' ', 8));
//            Console.WriteLine(new string('-', 40));
//            Console.WriteLine("1. Add House Amenities");
//            Console.WriteLine("2. Delete House Amenities");
//            Console.WriteLine("3. Update House Amenities");
//            Console.WriteLine("4. Extract House Amenities");
//            Console.WriteLine("5. List All House Amenities");
//            Console.WriteLine("6. Exit");
//        }

//        public void Input()
//        {
//            var operation = -1;
//            do
//            {
//                ShowMenu();
//                operation = int.Parse(Console.ReadLine());
//                switch (operation)
//                {
//                    case 1:
//                        Add();
//                        break;
//                    case 2:
//                        Delete();
//                        break;
//                    case 3:
//                        Update();
//                        break;
//                    case 4:
//                        Extract();
//                        break;
//                    case 5:
//                        ListAll();
//                        break;
//                    case 6:
//                        Console.WriteLine("Exiting House Amenities Menu...");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice.");
//                        break;
//                }
//            } while (operation != closeOperationId);
//        }

//        //public void Add()
//        //{
//        //    try
//        //    {
//        //        House_Amenity newHouse_Amenity = new House_Amenity();
//        //        do
//        //        {
//        //            Console.WriteLine("Enter house amenity Id: ");
//        //            newHouse_Amenity.HouseId = int.Parse(Console.ReadLine());
//        //        }
//        //        while (Validators.IsIntNoValid(newHouse_Amenity.HouseId));

//        //        do
//        //        {
//        //            Console.WriteLine("Enter house Id: ");
//        //            newHouse_Amenity.AmenityId = int.Parse(Console.ReadLine());
//        //        }
//        //        while (Validators.IsIntNoValid(newHouse_Amenity.AmenityId));

//        //        house_AmenitiesController.Add(newHouse_Amenity);
//        //        Console.WriteLine("House amenity added to database.");
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        Console.WriteLine(ex.Message);
//        //    }
//        //}

//        public void Add()
//        {
//            try
//            {
//                using var db = new HouseRentalsDBContext();
//                House_Amenity newHouse_Amenity = new House_Amenity();

//                // Get and validate HouseId
//                int houseId;
//                do
//                {
//                    Console.Write("Enter House ID: ");
//                } while (!int.TryParse(Console.ReadLine(), out houseId) || Validators.IsIntNoValid(houseId));

//                // Confirm House exists
//                var house = db.Houses.Find(houseId);
//                if (house == null)
//                {
//                    Console.WriteLine("House not found.");
//                    return;
//                }

//                // Get and validate AmenityId
//                int amenityId;
//                do
//                {
//                    Console.Write("Enter Amenity ID: ");
//                } while (!int.TryParse(Console.ReadLine(), out amenityId) || Validators.IsIntNoValid(amenityId));

//                // Confirm Amenity exists
//                var amenity = db.Amenities.Find(amenityId);
//                if (amenity == null)
//                {
//                    Console.WriteLine("Amenity not found.");
//                    return;
//                }

//                // Check if relationship already exists
//                bool exists = db.House_Amenities.Any(x => x.HouseId == houseId && x.AmenityId == amenityId);
//                if (exists)
//                {
//                    Console.WriteLine("This house already has this amenity.");
//                    return;
//                }

//                // Create and add relation
//                newHouse_Amenity.HouseId = houseId;
//                newHouse_Amenity.AmenityId = amenityId;

//                house_AmenitiesController.Add(newHouse_Amenity);
//                Console.WriteLine($"Amenity '{amenity.Name}' successfully linked to House '{house.Address}'!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }


//        public void Delete()
//        {
//            try
//            {
//                House_Amenity findHouse_Amenity = new House_Amenity();
//                do
//                {
//                    Console.WriteLine("Enter house Id: ");
//                    findHouse_Amenity.HouseId = int.Parse(Console.ReadLine());
//                }
//                while (Validators.IsIntNoValid(findHouse_Amenity.HouseId));

//                do
//                {
//                    Console.WriteLine("Enter amenity Id: ");
//                    findHouse_Amenity.AmenityId = int.Parse(Console.ReadLine());
//                }
//                while (Validators.IsIntNoValid(findHouse_Amenity.AmenityId));

//                house_AmenitiesController.Delete(findHouse_Amenity);
//                Console.WriteLine("Done.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        public void Update()
//        {
//            try
//            {
//                House_Amenity findHouse_Amenity = new House_Amenity();
//                do
//                {
//                    Console.WriteLine("Enter house Id: ");
//                    findHouse_Amenity.HouseId = int.Parse(Console.ReadLine());
//                }
//                while (Validators.IsIntNoValid(findHouse_Amenity.HouseId));

//                do
//                {
//                    Console.WriteLine("Enter amenity Id: ");
//                    findHouse_Amenity.AmenityId = int.Parse(Console.ReadLine());
//                }
//                while (Validators.IsIntNoValid(findHouse_Amenity.AmenityId));

//                house_AmenitiesController.Update(findHouse_Amenity);
//                Console.WriteLine("House amenity updated to database.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        public void Extract()
//        {
//            try
//            {
//                House_Amenity findHouse_Amenity = new House_Amenity();
//                do
//                {
//                    Console.WriteLine("Enter house Id: ");
//                    findHouse_Amenity.HouseId = int.Parse(Console.ReadLine());
//                }
//                while (Validators.IsIntNoValid(findHouse_Amenity.HouseId));

//                do
//                {
//                    Console.WriteLine("Enter amenity Id: ");
//                    findHouse_Amenity.AmenityId = int.Parse(Console.ReadLine());
//                }
//                while (Validators.IsIntNoValid(findHouse_Amenity.AmenityId));

//                House_Amenity house_Amenity = house_AmenitiesController.Get(findHouse_Amenity);
//                if (house_Amenity != null)
//                {
//                    var house = house_Amenity.House;
//                    var city = house.City;
//                    var amenity = house_Amenity.Amenity;

//                    Console.WriteLine(new string('-', 40));
//                    Console.WriteLine($"Amenity: {amenity.Name}");
//                    Console.WriteLine($"House Address: {house.Address}");
//                    Console.WriteLine(new string('-', 40));
//                }
//                else
//                {
//                    Console.WriteLine("House Amenity not found.");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        public void ListAll()
//        {
//            try
//            {
//                Console.WriteLine(new string('-', 40));
//                Console.WriteLine(new string(' ', 16) + "HOUSE_AMENITIES" + new string(' ', 16));
//                Console.WriteLine(new string('-', 40));
//                var house_Amenities = house_AmenitiesController.ListAll();
//                foreach (var house_Amenity in house_Amenities)
//                {
//                    if (house_Amenity != null)
//                    {
//                        var house = house_Amenity.House;
//                        var city = house.City;
//                        var amenity = house_Amenity.Amenity;

//                        Console.WriteLine(new string('-', 40));
//                        Console.WriteLine($"Amenity: {amenity.Name}");
//                        Console.WriteLine($"House Address: {house.Address}");
//                        Console.WriteLine(new string('-', 40));
//                    }
//                    else
//                    {
//                        Console.WriteLine("House Amenity not found.");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }
//    }
//}
