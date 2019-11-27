using App.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class TestCustomer
    {
        const int creditMultiplicator = 2;

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public bool HasCreditLimit { get; set; }

        public int CreditLimit { get; set; }

        public Company Company { get; set; }

        public TestCustomer(string firstname, string surname, string email, DateTime dateOfBirth, Company company, int creditLimit, bool hasCreditLimit)
        {
            Firstname = firstname;
            Surname = surname;
            EmailAddress = email;
            DateOfBirth = dateOfBirth;
            Company = company;

            CreditLimit = creditLimit;
            HasCreditLimit = hasCreditLimit;
        }
    }
}
