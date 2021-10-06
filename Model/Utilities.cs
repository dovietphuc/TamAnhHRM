using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace TamAnhHRM
{
    class Utilities
    {
        public static bool isValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public static bool isValidPassword(string password) {
            return hasNumber(password)
                && hasUpperChar(password)
                && hasMinimum8Chars(password);
        }

        public static bool hasNumber(string s)
        {
            var hasNumber = new Regex(@"[0-9]+");
            return hasNumber.IsMatch(s);
        }

        public static bool hasUpperChar(string s)
        {
            var hasUpperChar = new Regex(@"[A-Z]+");
            return hasUpperChar.IsMatch(s);
        }

        public static bool hasMinimum8Chars(string s)
        {
            var hasMinimum8Chars = new Regex(@".{8,}");
            return hasMinimum8Chars.IsMatch(s);
        }
    }
}
