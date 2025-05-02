using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house_rentals.Presentation
{
    public static class Validators
    {

        public static bool IsStringNoValid(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }

        public static bool IsIntNoValid(int number)
        {
            return int.IsNegative(number) || number == 0;
        }

        public static bool IsDateNoValid(DateTime date)
        {
            return date == default(DateTime) || date == DateTime.MinValue;
        }

        public static bool IsDoubleNoValid(double dNumber)
        {
            return double.IsNegative(dNumber) || dNumber == 0;
        }
    }
}
