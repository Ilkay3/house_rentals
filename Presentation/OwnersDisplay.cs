using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    public class OwnerDisplay
    {/*
        private int closeOperationId = 6;
        private ManagerBusiness managerBusiness = new ManagerBusiness();
        public OwnerDisplay()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU MANAGERS" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all owners");
            Console.WriteLine("2. Add new owner");
            Console.WriteLine("3. Update owner");
            Console.WriteLine("4. Fetch owner by Id");
            Console.WriteLine("5. Delete owner by Id");
            Console.WriteLine("6. Menu");
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
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
            } while (operation != closeOperationId);
        }

        public void Add()
        {
            Console.WriteLine("Enter manager Id");
            Owner newOwner = new Owner();
            newOwner.Id = int.Parse(Console.ReadLine());
            Owner manager = managerBusiness.Get(newOwner);
            if (manager != null)
            {
                Console.WriteLine("Manager with this ID exists");
            }
            else
            {

                Console.WriteLine("Enter manager first name: ");
                newManager.FirstName = Console.ReadLine();
                Console.WriteLine("Enter manager last name: ");
                newManager.LastName = Console.ReadLine();
                Console.WriteLine("Enter school ID: ");
                newManager.SchoolId = int.Parse(Console.ReadLine());
                managerBusiness.Add(newManager);
                Console.WriteLine("Manager add to database");
            }
        }
        public void Delete()
        {
            Manager findManager = new Manager();
            Console.WriteLine("Enter manager ID: ");
            findManager.Id = int.Parse(Console.ReadLine());
            Manager manager = managerBusiness.Get(findManager);
            if (manager != null)
            {
                managerBusiness.Delete(findManager);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Manager not found.");
            }
        }






        private void Fetch()
        {
            Manager findManager = new Manager();
            Console.WriteLine("Enter manager ID: ");
            findManager.Id = int.Parse(Console.ReadLine());
            Manager manager = managerBusiness.Get(findManager);
            if (manager != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + manager.Id);
                Console.WriteLine("First Name: " + manager.FirstName);
                Console.WriteLine("Last Name: " + manager.LastName);
                Console.WriteLine("School ID " + manager.SchoolId);
                Console.WriteLine("School name " + manager.School.Name);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Manager not found");
            }

        }

        private void Update()
        {
            Manager findManager = new Manager();
            Console.WriteLine("Enter manager ID: ");
            findManager.Id = int.Parse(Console.ReadLine());
            Manager manager = managerBusiness.Get(findManager);
            if (manager != null)
            {
                Console.WriteLine("Enter manager first name: ");
                manager.FirstName = Console.ReadLine();
                Console.WriteLine("Enter manager last name: ");
                manager.LastName = Console.ReadLine();
                Console.WriteLine("Enter school ID: ");
                manager.SchoolId = int.Parse(Console.ReadLine());
                managerBusiness.Update(manager);
                Console.WriteLine("Manager update to database.");
            }
            else
            {
                Console.WriteLine("Manager not found.");
            }

        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "MANAGERS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var managers = managerBusiness.GetAll();
            foreach (var manager in managers)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + manager.Id);
                Console.WriteLine("First Name: " + manager.FirstName);
                Console.WriteLine("Last Name: " + manager.LastName);
                Console.WriteLine("School ID " + manager.SchoolId);
                Console.WriteLine("School name " + manager.School.Name);
            }

        }

     }*/
    }
}
