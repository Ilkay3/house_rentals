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
    public class OwnerDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Owner> ownerController = new OwnerController();

        public OwnerDisplay()
        {
            Input();
        }

        public OwnerDisplay(IController<Owner> ownerController)
        {
            Input();
            this.ownerController = ownerController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU OWNERS" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add Owner");
            Console.WriteLine("2. Delete Owner");
            Console.WriteLine("3. Update Owner");
            Console.WriteLine("4. Extract Owner");
            Console.WriteLine("5. List All Owners");
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
                        Console.WriteLine("Exiting Owner Menu...");
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
                Owner newOwner = new Owner();
                do
                {
                    Console.WriteLine("Enter owner Id: ");
                    newOwner.OwnerId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newOwner.OwnerId));

                do
                {
                    Console.WriteLine("Enter owner first name: ");
                    newOwner.First_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newOwner.First_Name));

                do
                {
                    Console.WriteLine("Enter owner last name: ");
                    newOwner.Last_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newOwner.Last_Name));

                do
                {
                    Console.WriteLine("Enter owner phone number: ");
                    newOwner.PhoneNumber = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newOwner.PhoneNumber));

                do
                {
                    Console.WriteLine("Enter owner e-mail: ");
                    newOwner.Email = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newOwner.Email));

                do
                {
                    Console.WriteLine("Enter owner EGN: ");
                    newOwner.EGN = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newOwner.EGN));

                ownerController.Add(newOwner);
                Console.WriteLine("Owner added to database.");
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
                Owner findOwner = new Owner();
                do
                {
                    Console.WriteLine("Enter owner Id to delete: ");
                    findOwner.OwnerId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findOwner.OwnerId));

                ownerController.Delete(findOwner);
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
                Owner findOwner = new Owner();
                do
                {
                    Console.WriteLine("Enter owner Id to update: ");
                    findOwner.OwnerId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findOwner.OwnerId));
                
                do
                {
                    Console.WriteLine("Enter owner first name: ");
                    findOwner.First_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findOwner.First_Name));

                do
                {
                    Console.WriteLine("Enter owner last name: ");
                    findOwner.Last_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findOwner.Last_Name));

                do
                {
                    Console.WriteLine("Enter owner phone number: ");
                    findOwner.PhoneNumber = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findOwner.PhoneNumber));

                do
                {
                    Console.WriteLine("Enter owner e-mail: ");
                    findOwner.Email = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findOwner.Email));

                do
                {
                    Console.WriteLine("Enter owner EGN: ");
                    findOwner.EGN = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findOwner.EGN));

                ownerController.Update(findOwner);
                Console.WriteLine("Owner update to database.");
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
                Owner findOwner = new Owner();
                do
                {
                    Console.WriteLine("Enter owner Id to extract: ");
                    findOwner.OwnerId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findOwner.OwnerId));

                Owner owner = ownerController.Get(findOwner);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Owner ID: " + owner.OwnerId);
                Console.WriteLine("First Name: " + owner.First_Name);
                Console.WriteLine("Last Name: " + owner.Last_Name);
                Console.WriteLine("PhoneNumber: " + owner.PhoneNumber);
                Console.WriteLine("Email: " + owner.Email);
                Console.WriteLine("EGN: " + owner.EGN);
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
                Console.WriteLine(new string(' ', 16) + "OWENRS" + new string(' ', 16));
                Console.WriteLine(new string('-', 40));
                var owners = ownerController.ListAll();
                foreach (var owner in owners)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Owner ID: " + owner.OwnerId);
                    Console.WriteLine("First Name: " + owner.First_Name);
                    Console.WriteLine("Last Name: " + owner.Last_Name);
                    Console.WriteLine("PhoneNumber: " + owner.PhoneNumber);
                    Console.WriteLine("Email: " + owner.Email);
                    Console.WriteLine("EGN: " + owner.EGN);
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
