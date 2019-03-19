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
            DateTime = DateTime.Now;
        }

        //fields
        private SettingsViewModel _settingsViewModel = new SettingsViewModel();
        private BindableCollection<Jewelry> _jewelries = new BindableCollection<Jewelry>();
        private BindableCollection<LoanInfo> _loans = new BindableCollection<LoanInfo>();
        private string _fullName;
        private string _address;
        private string _contactNumber;
        private Customer _customer;
        private char _firstLetter;
        private DateTime _dateTime;
        private string _dateTimeString;
        private string _money;

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
        public string FullName
        {
            get
            {
                var fullname = SettingsViewModel.SelectedCustomer.Name;
                return fullname;
            }
            set => _fullName = value;
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

        public string Money
        {
            get
            {
                var mon = SettingsViewModel.SelectedCustomer.Money.ToString();
                var monwithp = "₱" + mon;
                return monwithp;
            }
            set
            {
                _money = value;
                NotifyOfPropertyChange(() => Money);

            }
        }

        public char FirstLetter
        {
            get => FullName[0];
            set => _firstLetter = value;
        }
        public string DateTimeString
        {
            get => _dateTimeString;
            set => _dateTimeString = value;
        }
        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                DateTimeString = value.ToString();
                NotifyOfPropertyChange(() => DateTimeString);
            }
        }

    }
}
