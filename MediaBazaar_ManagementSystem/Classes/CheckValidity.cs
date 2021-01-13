using System.Text.RegularExpressions;

namespace MediaBazaar_ManagementSystem
{
    public static class CheckValidity
    {
        public static bool Name(string input)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$");
            return regex.IsMatch(input);
        }

        public static bool Email(string input)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            return regex.IsMatch(input);
        }

        public static bool PhoneNumber(string input)
        {
            Regex regex = new Regex(@"^((?=.{10}$)(\d{10}))|((?=.{12}$)([+316]{4}\d{8}))");
            return regex.IsMatch(input);
        }

        public static bool Username(string input)
        {
            Regex regex = new Regex(@"^(?=.{1,64}$)[a-zA-Z0-9._]+$");
            return regex.IsMatch(input);
        }

        public static bool Password(string input)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            return regex.IsMatch(input);
        }

        public static bool Address(string input)
        {
            Regex regex = new Regex(@"^[A-Za-z]+(?:\s[A-Za-z0-9'_-]+)+$");
            return regex.IsMatch(input);
        }

        public static bool PostalCode(string input)
        {
            Regex regex = new Regex(@"^[0-9]{4}[ ]?[a-zA-Z]{2}$");
            return regex.IsMatch(input);
        }

        public static bool BSN(string input)
        {
            Regex regex = new Regex(@"^[0-9]*\d{9}$");
            return regex.IsMatch(input);
        }

        public static bool NumbersOnly(string input)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(input);
        }

        public static bool StandardInput(string input)
        {
            Regex regex = new Regex(@"^[^\s].*");
            return regex.IsMatch(input);
        }

        public static bool Category(string input)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
            return regex.IsMatch(input);
        }

        public static bool ProductCode(string input)
        {
            Regex regex = new Regex(@"^[0-9]*\d{4,15}$");
            return regex.IsMatch(input);
        }
    }
}
