using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace house_rentals.Presentation
{
    public class Display
    {
         private int closeOperationId = 9;
         public Display()
         {
             Input();
         }
        
         public void ShowMenu()
         {
             Console.WriteLine(new string('-', 40));
             Console.WriteLine(new string(' ', 8) + "MENU" + new string(' ', 8));
             Console.WriteLine(new string('-', 40));
             Console.WriteLine("1. Amenities");
             Console.WriteLine("2. Bookings");
             Console.WriteLine("3. Cities");
             Console.WriteLine("4. Houses");
             Console.WriteLine("5. House_amenities");
             Console.WriteLine("6. Owners");
             Console.WriteLine("7. Payments");
             Console.WriteLine("8. Tenants");
             Console.WriteLine("9. Exit");
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
                         AmenityDisplay amenity = new AmenityDisplay();
                         break;
                     case 2:
                         BookingDisplay booking = new BookingDisplay();
                         break;
                     case 3:
                         CityDisplay city = new CityDisplay();
                         break;
                     case 4:
                         HouseDisplay house = new HouseDisplay();
                         break;
                     case 5:
                         House_amenityDisplay house_amenity = new House_amenityDisplay();
                         break;
                     case 6:
                         OwnerDisplay owner = new OwnerDisplay();
                         break;
                     case 7:
                         PaymentDisplay payment = new PaymentDisplay();
                         break;
                     case 8:
                         TenantDisplay tenat = new TenantDisplay();
                         break;
                     default:
                         Console.WriteLine("Invalid operation");
                         break;
                 }
             } while (operation != closeOperationId);
         }
    }
}
