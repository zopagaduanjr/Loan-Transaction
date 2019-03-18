using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Loan.Core.Models;
using Type = System.Type;

namespace Loan.Core.ViewModels
{
    public class SettingsViewModel : Screen
    {

        //ctor
        public SettingsViewModel()
        {
            var jewelry1 = new Jewelry(){Type = Models.Type.Bracelet, Quality = Quality._10k, ActualValue = 234 , OtherDetail = "nice ka"};
            var jewelry2 = new Jewelry(){Type = Models.Type.Ring, Quality = Quality._18k, ActualValue = 1500};
            var jewelry3 = new Jewelry(){Type = Models.Type.Necklace, Quality = Quality._21k, ActualValue = 12000};
            var jewelry4 = new Jewelry(){Type = Models.Type.Necklace, Quality = Quality._21k, ActualValue = 555};
            var jewelries = new List<Jewelry>();
            jewelries.Add(jewelry1);
            jewelries.Add(jewelry2);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            jewelries.Add(jewelry3);
            var jeweee = new List<Jewelry>();
            jeweee.Add(jewelry4);
            var customer1 = new Customer(){Name = "Greed", Address = "Davao",ContactNumber = "0999", Jewelries = jeweee, Loans = new List<LoanInfo>()};
            var customer2 = new Customer(){Name = "Envy", Address = "Cebu", ContactNumber = "0944", Jewelries = jewelries, Loans = new List<LoanInfo>() };
            var customer3 = new Customer(){Name = "Joy", Address = "Bohol", ContactNumber = "0933", Jewelries = jewelries, Loans = new List<LoanInfo>() };
            var customer4 = new Customer(){Name = "Sloth", Address = "Tagbilaran", ContactNumber = "0911", Jewelries = jewelries, Loans = new List<LoanInfo>() };
            var customer5 = new Customer(){Name = "Pride", Address = "Bulad", ContactNumber = "0922", Jewelries = jewelries, Loans = new List<LoanInfo>() };
            Customers.Add(customer1);
            Customers.Add(customer2);
            Customers.Add(customer3);
            Customers.Add(customer4);
            Customers.Add(customer5);
            SelectedCustomer = Customers.FirstOrDefault();
        }

        //properties
        private BindableCollection<Customer> _customers = new BindableCollection<Customer>();
        private Customer _selectedCustomer;

        public BindableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set => _selectedCustomer = value;
        }

        //methods
        public void AddRandomCustomerCommand()
        {
            var b = Customers;
            var customer = new Customer();
            customer.Name = "Zaldy";
            Customers.Add(customer);

        }

    }
}
