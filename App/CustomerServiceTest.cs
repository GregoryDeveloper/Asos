using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class CustomerServiceTest
    {
        public bool AddCustomer(string firstname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            if (!Validation.Validation.Validate(firstname, surname, email, dateOfBirth))
            {
                return false;
            }

            var company = new Company { Id = companyId, Name = "default", Classification = Enumerations.Classification.Gold };
            var customer = new TestCustomer(firstname, surname, email, dateOfBirth, company,600,false);

            if (!Validation.Validation.ValidateCustomer(customer))
            {
                return false;
            }

            //CustomerDataAccess.AddCustomer(customer);

            return true;
        }
    }
}
