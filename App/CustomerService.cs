using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class CustomerService
    {
        // They migth be a connection made at the instanciation of the repository => better to do it only once in the service
        CompanyRepository companyRepository = new CompanyRepository();

        public bool AddCustomer(string firstname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            if (!Validation.Validation.Validate(firstname,surname,email, dateOfBirth))
            {
                return false;
            }
            
            var company = companyRepository.GetById(companyId);
            var customer = new Customer(firstname, surname, email, dateOfBirth, company);

            if (!Validation.Validation.ValidateCustomer(customer))
            {
                return false;
            }

            CustomerDataAccess.AddCustomer(customer);

            return true;
        }

        
    }
}
