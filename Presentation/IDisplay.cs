using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    public interface IDisplay
        {
            void ShowMenu();
            void Input();
            void Add();
            void Delete();
            void Fetch();
            void Update();
            void ListAll();
        }
}
