using house_rentals.Controllers;
using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    public class TenantDisplay : IDisplay
    {
        private int closeOperationId = 6;
        private IController<Tenant> tenantController = new TenantController();

        public TenantDisplay()
        {
            Input();
        }

        public TenantDisplay(IController<Tenant> tenantController)
        {
            Input();
            this.tenantController = tenantController;
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "MENU TENATS" + new string(' ', 8));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add Tenant");
            Console.WriteLine("2. Delete Tenant");
            Console.WriteLine("3. Update Tenant");
            Console.WriteLine("4. Extract Tenant");
            Console.WriteLine("5. List All Tenants");
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
                        Console.WriteLine("Exiting Tenant Menu...");
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
                Tenant newTenant = new Tenant();
                do
                {
                    Console.WriteLine("Enter tenant Id: ");
                    newTenant.TenantId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(newTenant.TenantId));

                do
                {
                    Console.WriteLine("Enter tenant first name: ");
                    newTenant.First_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newTenant.First_Name));

                do
                {
                    Console.WriteLine("Enter tenant last name: ");
                    newTenant.Last_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newTenant.Last_Name));

                do
                {
                    Console.WriteLine("Enter tenant phone number: ");
                    newTenant.PhoneNumber = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newTenant.PhoneNumber));

                do
                {
                    Console.WriteLine("Enter tenant e-mail: ");
                    newTenant.Email = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newTenant.Email));

                do
                {
                    Console.WriteLine("Enter tenant EGN: ");
                    newTenant.EGN = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(newTenant.EGN));

                tenantController.Add(newTenant);
                Console.WriteLine("Tenant added to database.");
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
                Tenant findTenant = new Tenant();
                do
                {
                    Console.WriteLine("Enter tenant Id to delete: ");
                    findTenant.TenantId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findTenant.TenantId));

                tenantController.Delete(findTenant);
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
                Tenant findTenant = new Tenant();
                do
                {
                    Console.WriteLine("Enter tenant Id to update: ");
                    findTenant.TenantId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findTenant.TenantId));

                do
                {
                    Console.WriteLine("Enter tenant first name: ");
                    findTenant.First_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findTenant.First_Name));

                do
                {
                    Console.WriteLine("Enter tenant last name: ");
                    findTenant.Last_Name = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findTenant.Last_Name));

                do
                {
                    Console.WriteLine("Enter tenant phone number: ");
                    findTenant.PhoneNumber = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findTenant.PhoneNumber));

                do
                {
                    Console.WriteLine("Enter tenant e-mail: ");
                    findTenant.Email = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findTenant.Email));

                do
                {
                    Console.WriteLine("Enter tenant EGN: ");
                    findTenant.EGN = Console.ReadLine();
                }
                while (Validators.IsStringNoValid(findTenant.EGN));

                tenantController.Update(findTenant);
                Console.WriteLine("Tenant update to database.");
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
                Tenant findTenant = new Tenant();
                do
                {
                    Console.WriteLine("Enter tenant Id to extract: ");
                    findTenant.TenantId = int.Parse(Console.ReadLine());
                }
                while (Validators.IsIntNoValid(findTenant.TenantId));

                Tenant tenant = tenantController.Get(findTenant);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Tenant ID: " + tenant.TenantId);
                Console.WriteLine("First Name: " + tenant.First_Name);
                Console.WriteLine("Last Name: " + tenant.Last_Name);
                Console.WriteLine("PhoneNumber: " + tenant.PhoneNumber);
                Console.WriteLine("Email: " + tenant.Email);
                Console.WriteLine("EGN: " + tenant.EGN);
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
                var tenants = tenantController.ListAll();
                foreach (var tenant in tenants)
                {
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("Tenant ID: " + tenant.TenantId);
                    Console.WriteLine("First Name: " + tenant.First_Name);
                    Console.WriteLine("Last Name: " + tenant.Last_Name);
                    Console.WriteLine("PhoneNumber: " + tenant.PhoneNumber);
                    Console.WriteLine("Email: " + tenant.Email);
                    Console.WriteLine("EGN: " + tenant.EGN);
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
