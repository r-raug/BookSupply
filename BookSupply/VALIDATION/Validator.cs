using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSupply.VALIDATION
{
    public static class Validator
    {


        //this method check if the user input a valid name, that contains only letters.
        public static bool IsValidName(string name)
        {
            if (name.Length == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if ((!Char.IsLetter(name[i])) && (!Char.IsWhiteSpace(name[i])))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool isValidEmail(string id)
        {
            if (!Regex.IsMatch(id, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {

            if (!Regex.IsMatch(phoneNumber, @"^\d{10}$"))
            {
                return false;
            }
            return true;
        }

        public static bool isValidISBN(string isbn)
        {
            if (!Regex.IsMatch(isbn, @"^\d{10}$"))
            {
                return false;
            }
            return true;
        }


    }
}
