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
        //ctor
        public CustomerViewModel()
        {
        }

        //fields
        private SettingsViewModel _settingsViewModel = new SettingsViewModel();
        private BindableCollection<Jewelry> _jewelries = new BindableCollection<Jewelry>();
        private BindableCollection<LoanInfo> _loans = new BindableCollection<LoanInfo>();

        private Customer _customer;
        private string _name;
        private string _address;
        private string _contactNumber;

        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public SettingsViewModel SettingsViewModel
        {
            get => _settingsViewModel;
            set => _settingsViewModel = value;
        }

        public BindableCollection<Jewelry> Jewelries
        {
            get
            {
                var jewelries = SettingsViewModel.SelectedCustomer.Jewelries;
                return new BindableCollection<Jewelry>(jewelries);
            }
            set => _jewelries = value;
        }

        public BindableCollection<LoanInfo> Loans
        {
            get
            {
                var lons = SettingsViewModel.SelectedCustomer.Loans;
                return new BindableCollection<LoanInfo>(lons);
            }
            set => _loans = value;
        }

        public string Name
        {
            get
            {
                var fullname = SettingsViewModel.SelectedCustomer.Name;
                return fullname;
            }
            set => _name = value;
        }

        public string Address
        {
            get
            {
                var home = SettingsViewModel.SelectedCustomer.Address;
                return home;
            }
            set => _address = value;
        }

        public string ContactNumber
        {
            get
            {
                var num = SettingsViewModel.SelectedCustomer.ContactNumber;
                return num;
            }
            set => _contactNumber = value;
        }
    }
}
