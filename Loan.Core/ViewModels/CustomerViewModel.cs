using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Loan.Core.Models;

namespace Loan.Core.ViewModels
{
    public class CustomerViewModel : Screen
    {
        private Customer _customer;
        private string _fullName;

        public CustomerViewModel()
        {
            Customer = new Customer();
            Customer.Name = "Zaldy";
            Customer.Address = "Davao City";
            Customer.ContactNumber = "09228121435";
        }

        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public string FullName
        {
            get
            {
                var fullname = Customer.Name;
                return fullname;
            }
            set => _fullName = value;
        }
    }
}
