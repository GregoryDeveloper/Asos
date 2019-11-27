using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Validation
{
    public static class Validation
    {
        const char atCharacter = '@';
        const char dotCharacter = '.';
        const int ageLimit = 21;
        const int creditLimit = 500;


        public static bool Validate(string firname, string surname, string email, DateTime dateOfBirth)
        {
            return ValidateName(firname) && ValidateName(surname) && ValidateMailAddress(email) && ValidateAge(dateOfBirth)
                ? true
                : false;
        }

        public static bool ValidateCustomer(Customer customer)
        {
            return customer.HasCreditLimit && customer.CreditLimit < creditLimit ? false : true;
        }

        // Should use a mocking framework to achieve this
        public static bool ValidateCustomer(TestCustomer customer)
        {
            return customer.HasCreditLimit && customer.CreditLimit < creditLimit ? false : true;
        }

        private static bool ValidateName(string name)
        {
            return string.IsNullOrEmpty(name) ? false : true;
        }

        private static bool ValidateMailAddress(string address)
        {
            return address.Contains(atCharacter) && address.Contains(dotCharacter) ? true : false;
        }

        private static bool ValidateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            if (!HasGotBirthday(dateOfBirth))
            {
                age--;
            }

            return age < ageLimit ? false : true;

        }

        private static bool HasGotBirthday(DateTime dateOfBirth)
        {
            int currentDay = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;

            if (currentMonth < dateOfBirth.Month || (currentMonth == dateOfBirth.Month && currentMonth < dateOfBirth.Day))
            {
                return false;
            }

            return true;

        }
    }
}
