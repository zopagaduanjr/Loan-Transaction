using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caliburn.Micro;
using Loan.Core.Models;
using Screen = Caliburn.Micro.Screen;

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
        private AddJewelDialogViewModel _addJewelDialogViewModel = new AddJewelDialogViewModel();
        private static Random rand = new Random(DateTime.Now.Second);



        WindowManager windowManager = new WindowManager();
        private bool _devMode;

        public AddJewelDialogViewModel AddJewelDialogViewModel
        {
            get => _addJewelDialogViewModel;
            set => _addJewelDialogViewModel = value;
        }
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
            set
            {
                _jewelries = value;
                NotifyOfPropertyChange(() => Jewelries);

            }
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


        //isclickable
        public bool DevMode
        {
            get
            {
                var dem = SettingsViewModel.DeveloperMode;
                return dem;
            }
            set
            {
                _devMode = value;
                NotifyOfPropertyChange(() => DevMode);

            }
        }

        //commands
        public void OpenAddJewel()
        {
            AddJewelDialogViewModel.SettingsViewModel = SettingsViewModel;
            AddJewelDialogViewModel.CustomerViewModel = this;
            AddJewelDialogViewModel.Weight = null;
            AddJewelDialogViewModel.Discount = null;
            AddJewelDialogViewModel.OtherDetail = null;
            AddJewelDialogViewModel.ActualValue = null;
            var result = windowManager.ShowDialog(AddJewelDialogViewModel);
            if (AddJewelDialogViewModel.MyDialogResult == DialogResult.OK)
            {
                NotifyOfPropertyChange(() => SettingsViewModel.Customers);
                NotifyOfPropertyChange(() => Jewelries);
                return;
            }

        }

        public void AddRandomJewelry()
        {
            var jewel = new Jewelry();
            var rqual = Enum.GetValues(typeof(Quality));
            var rtype = Enum.GetValues(typeof(Models.Type));
            var randomqual = (Quality)rqual.GetValue(rand.Next(rqual.Length));
            var randomtyp = (Models.Type)rtype.GetValue(rand.Next(rtype.Length));
            jewel.Type = randomtyp;
            jewel.Quality = randomqual;
            jewel.Weight = rand.Next(5, 1500);
            jewel.Discount = rand.NextDouble();
            jewel.ActualValue = NumberGenerator(4);
            SettingsViewModel.SelectedCustomer.Jewelries.Add(jewel);
            NotifyOfPropertyChange(() => SettingsViewModel.SelectedCustomer);
            NotifyOfPropertyChange(() => Jewelries);

        }

        //dirtyworks
        public int NumberGenerator(int totlength)
        {
            var value = 0;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // Buffer storage.
                byte[] data = new byte[4];

                // Ten iterations.
                rng.GetBytes(data);
                // Convert to int 32.
                int val = BitConverter.ToInt32(data, 0);
                value = Math.Abs(val);
                var streng = value.ToString();
                var lenth = streng.Length;
                var x = lenth - totlength;
                if (x < 0)
                {
                    streng = streng + "55";
                }

                streng = streng.Substring(0, streng.Length - x);
                value = Int32.Parse(streng);
            }

            return value;
        }

    }
}
