using App.Enumerations;
using System;

namespace App
{
    public class Customer
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

        public Customer(string firstname, string surname, string email, DateTime dateOfBirth, Company company)
        {
            Firstname = firstname;
            Surname = surname;
            EmailAddress = email;
            DateOfBirth = dateOfBirth;
            Company = company;

            SetUpCredit(Company.Name);
           
        }

        private void SetUpCredit(string companyName)
        {
            if (companyName == CompanyName.VeryImportantClient.GetDescription())
            {
                // Skip credit check
                HasCreditLimit = false;
            }
            else
            {
                HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(Firstname, Surname, DateOfBirth);
                    CreditLimit = creditLimit;
                }
            }

            if (companyName == CompanyName.ImportantClient.GetDescription())
            {
                CreditLimit = CreditLimit * creditMultiplicator;
            }
        }
    }
}