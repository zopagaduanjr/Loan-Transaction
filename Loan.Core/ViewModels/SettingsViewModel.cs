using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
            DeveloperMode = true;
            AddRandomCustomerCommand();
            AddRandomCustomerCommand();
            AddRandomCustomerCommand();
            SelectedCustomer = Customers.FirstOrDefault();
        }

        //properties
        private static Random rand = new Random(DateTime.Now.Second);
        private BindableCollection<Customer> _customers = new BindableCollection<Customer>();
        private Customer _selectedCustomer;
        private bool _developerMode;
        private BindableCollection<Jewelry> _pawnedJewelry = new BindableCollection<Jewelry>();


        public BindableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                NotifyOfPropertyChange(() => Customers);

            }
        }
        public BindableCollection<Jewelry> PawnedJewelry
        {
            get => _pawnedJewelry;
            set
            {
                _pawnedJewelry = value;
                NotifyOfPropertyChange(() => PawnedJewelry);

            }
        }
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                NotifyOfPropertyChange(() => SelectedCustomer);           
            }
        }

        public bool DeveloperMode
        {
            get => _developerMode;
            set
            {
                _developerMode = value;
                NotifyOfPropertyChange(() => DeveloperMode);
            }
        }


        //methods
        public void AddRandomCustomerCommand()
        {
            var b = Customers;
            var customer = new Customer();
            customer.Name = FirstNameGenerator();
            customer.Address = AddressGenerator();
            customer.ContactNumber = NumberGenerator(7).ToString();
            customer.Money = NumberGenerator(5);
            Customers.Add(customer);

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
            jewel.Weight = rand.Next(5,1500);
            jewel.Discount = rand.NextDouble();
            jewel.ActualValue = NumberGenerator(4);
            SelectedCustomer.Jewelries.Add(jewel);
            NotifyOfPropertyChange(() => SelectedCustomer);

        }
        public void DeveloperModeCommand()
        {
            DeveloperMode = true;
            NotifyOfPropertyChange(() => DeveloperMode);

        }

        //dirty works
        public string FirstNameGenerator()
        {
            string[] FirstNames = {
                "Adam",
                "Chase",
                "Jace",
                "Ian",
                "Cooper",
                "Easton",
                "Kevin",
                "Jose",
                "Tyler",
                "Brandon",
                "Asher",
                "Jaxson",
                "Mateo",
                "Jason",
                "Ayden",
                "Zachary",
                "Carson",
                "Xavier",
                "Leo",
                "Ezra",
                "Bentley",
                "Sawyer",
                "Kayden",
                "Blake",
                "Nathaniel",
                "Ryder",
                "Theodore",
                "Elias",
                "Tristan",
                "Roman",
                "Leonardo",
                "Emma",
                "Olivia",
                "Sophia",
                "Ava",
                "Isabella",
                "Mia",
                "Abigail",
                "Emily",
                "Charlotte",
                "Harper",
                "Madison",
                "Amelia",
                "Elizabeth",
                "Sofia",
                "Evelyn",
                "Avery",
                "Chloe",
                "Ella",
                "Grace",
                "Victoria",
                "Aubrey",
                "Scarlett",
                "Zoey",
                "Addison",
                "Lily",
                "Lillian",
                "Natalie",
                "Hannah",
                "Aria",
                "Layla",
                "Brooklyn",
            };
            var random = rand.Next(0, 60);
            return FirstNames[random];
        }
        public string AddressGenerator()
        {
            string[] Address =
            {
                "Alaminos City",
                "Angeles City",
                "Antipolo City",
                "Bacolod City",
                "Bacoor City",
                "Bago City",
                "Baguio City",
                "Bais City",
                "Balanga City",
                "Batac City",
                "Batangas City",
                "Bayawan City",
                "Baybay City",
                "Baybay City",
                "Bayugan City",
                "Binan City",
                "Bogo City",
                "Borongan City",
                "Butuan City",
            };
            var random = rand.Next(0, 18);
            return Address[random];
        }
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
                streng = streng.Substring(0, streng.Length - x);
                value = Int32.Parse(streng);
            }

            return value;
        }

    }

}


