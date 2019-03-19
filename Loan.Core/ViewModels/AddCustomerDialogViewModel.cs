using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loan.Core.Models;
using Screen = Caliburn.Micro.Screen;

namespace Loan.Core.ViewModels
{
    public class AddCustomerDialogViewModel : Screen
    {
        private string _name;
        private string _address;
        private string _contactNumber;
        private string _money;
        private SettingsViewModel _settingsViewModel;
        private bool _devMode;
        private static Random rand = new Random(DateTime.Now.Second);

        //ctor
        public AddCustomerDialogViewModel()
        {
            
        }

        public DialogResult MyDialogResult { get; set; }

        public SettingsViewModel SettingsViewModel
        {
            get => _settingsViewModel;
            set => _settingsViewModel = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Address
        {
            get => _address;
            set => _address = value;
        }
        public string ContactNumber
        {
            get => _contactNumber;
            set => _contactNumber = value;
        }
        public string Money
        {
            get => _money;
            set => _money = value;
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

        //command
        public void AddRandomFields()
        {
            Name = FirstNameGenerator();
            Address = AddressGenerator();
            ContactNumber = NumberGenerator(7).ToString();
            Money = NumberGenerator(5).ToString();
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Address);
            NotifyOfPropertyChange(() => ContactNumber);
            NotifyOfPropertyChange(() => Money);

        }
        public void Ok()
        {
            //Do stuff
            var cust = new Customer();
            cust.Name = Name;
            cust.Address = Address;
            cust.ContactNumber = ContactNumber;
            cust.Money = double.Parse(Money);
            SettingsViewModel.Customers.Add(cust);
            NotifyOfPropertyChange(() => SettingsViewModel);
            NotifyOfPropertyChange(() => SettingsViewModel.Customers);
            MyDialogResult = DialogResult.OK;
            TryClose();
        }
        public void Cancel()
        {
            MyDialogResult = DialogResult.Cancel;
            TryClose();
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
                "Cabadbaran City",
                "Cabanatuan City",
                "Cabuyao City",
                "Cadiz City",
                "Cagayan de Oro City",
                "Calamba City",
                "Calapan City",
                "Calbayog City",
                "Caloocan City",
                "Candon City",
                "Canlaon City",
                "Carcar City",
                "Catbalogan City",
                "Cauayan City",
                "Cavite City",
                "Cebu City",
                "Cotabato City",
            };
            var random = rand.Next(0, 34);
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
