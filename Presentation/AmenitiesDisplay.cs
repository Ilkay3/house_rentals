using house_rentals.Date.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    internal class AmenitiesDisplay : IDisplay
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
                this.schoolController = schoolController;
            }

            public void ShowMenu()
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine(new string(' ', 8) + "MENU SCHOOLS" + new string(' ', 8));
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("1. List all amenities");
                Console.WriteLine("2. Add new amenity");
                Console.WriteLine("3. Update amenity");
                Console.WriteLine("4. Fetch amenity by Id");
                Console.WriteLine("5. Delete amenity by Id");
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
                        default:
                            Console.WriteLine("Invalid operation");
                            break;
                    }
                } while (operation != closeOperationId);
            }

            public void Add()
            {
                try
                {
                    School school = new School();
                    do
                    {
                        Console.WriteLine("Enter ID: ");
                        school.Id = int.Parse(Console.ReadLine());
                    }
                    while (Validators.IsIntNoValid(school.Id));

                    do
                    {
                        Console.WriteLine("Enter name: ");
                        school.Name = Console.ReadLine();
                    }
                    while (Validators.IsStringNoValid(school.Name));
                    //TODO manager

                    schoolController.Add(school);
                    Console.WriteLine("School add to database.");
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
                    School findSchool = new School();
                    do
                    {
                        Console.WriteLine("Enter school ID: ");
                        findSchool.Id = int.Parse(Console.ReadLine());
                    }
                    while (Validators.IsIntNoValid(findSchool.Id));

                    schoolController.Delete(findSchool);
                    Console.WriteLine("Done.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public void Fetch()
            {
                try
                {
                    School findSchool = new School();
                    do
                    {
                        Console.WriteLine("Enter school ID: ");
                        findSchool.Id = int.Parse(Console.ReadLine());
                    }
                    while (Validators.IsIntNoValid(findSchool.Id));

                    School school = schoolController.Get(findSchool);

                    Console.WriteLine(new string('-', 40));
                    Console.WriteLine("ID: " + school.Id);
                    Console.WriteLine("Name: " + school.Name);
                    //  Console.WriteLine("Students:");
                    foreach (Student student in school.Students)
                    {
                        Console.WriteLine("Student: " + student.Id);
                        Console.WriteLine("First name: " + student.FirstName);
                        Console.WriteLine("Last name: " + student.LastName);
                        Console.WriteLine("Age: " + student.Age);
                    }
                    if (school.Manager != null) Console.WriteLine("Manager: " + school.Manager.FirstName + " " + school.Manager.LastName);
                    Console.WriteLine(new string('-', 40));
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
                    School findSchool = new School();
                    do
                    {
                        Console.WriteLine("Enter school ID: ");
                        findSchool.Id = int.Parse(Console.ReadLine());
                    }
                    while (Validators.IsIntNoValid(findSchool.Id));

                    do
                    {
                        Console.WriteLine("Enter name: ");
                        findSchool.Name = Console.ReadLine();
                    }
                    while (Validators.IsStringNoValid(findSchool.Name));

                    schoolController.Update(findSchool);
                    Console.WriteLine("School update to database.");
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
                    Console.WriteLine(new string(' ', 16) + "SCHOOLS" + new string(' ', 16));
                    Console.WriteLine(new string('-', 40));
                    var schools = schoolController.ListAll();
                    foreach (var school in schools)
                    {
                        Console.WriteLine(new string('-', 40));
                        Console.WriteLine("ID: " + school.Id);
                        Console.WriteLine("Name: " + school.Name);
                        //  Console.WriteLine("Students:");
                        foreach (Student student in school.Students)
                        {
                            Console.WriteLine("Student: " + student.Id);
                            Console.WriteLine("First name: " + student.FirstName);
                            Console.WriteLine("Last name: " + student.LastName);
                            Console.WriteLine("Age: " + student.Age);
                        }
                        if (school.Manager != null) Console.WriteLine("Manager: " + school.Manager.FirstName + " " + school.Manager.LastName);
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
}
