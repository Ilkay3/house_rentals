﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Rentals.Controllers
{
    public interface IController<T>
    {
        void Add(T item);
        void Delete(T item);
        T Get(T item);
        void Update(T item);
        List<T> ListAll();
    }
}
