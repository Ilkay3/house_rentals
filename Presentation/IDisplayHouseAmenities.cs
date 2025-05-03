using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Rentals.Presentation
{
    public interface IDisplayHouseAmenities
    {
        void ShowMenu();
        void Input();
        void AddHouseAmenity();
        void Delete();
        void Extract();
        void Update();
        void ListAll();
    }
}
