using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loan.Core.Models;
using Screen = Caliburn.Micro.Screen;
using Type = Loan.Core.Models.Type;

namespace Loan.Core.ViewModels
{
    public class AddJewelDialogViewModel : Screen
    {
        private string _weight;
        private string _discount;
        private string _otherDetail;
        private string _actualValue;
        private bool _devMode;
        private SettingsViewModel _settingsViewModel;
        private Type _selectedType;
        private Quality _selectedQuality;
        private static Random rand = new Random(DateTime.Now.Hour);

        //ctor
        public AddJewelDialogViewModel()
        {
            JType = Enum.GetValues(typeof(Type)).Cast<Type>().ToList();
            JQuality = Enum.GetValues(typeof(Quality)).Cast<Quality>().ToList();
        }

        //fields
        public DialogResult MyDialogResult { get; set; }
        public SettingsViewModel SettingsViewModel
        {
            get => _settingsViewModel;
            set => _settingsViewModel = value;
        }

        public CustomerViewModel CustomerViewModel { get; set; }
        public string Weight
        {
            get => _weight;
            set => _weight = value;
        }
        public string Discount
        {
            get => _discount;
            set => _discount = value;
        }
        public string OtherDetail
        {
            get => _otherDetail;
            set => _otherDetail = value;
        }
        public string ActualValue
        {
            get => _actualValue;
            set => _actualValue = value;
        }
        public enum Type
        {
            Ring,
            Necklace,
            Bracelet,
            Earring
        }
        public IReadOnlyList<Type> JType { get; }
        public IReadOnlyList<Quality> JQuality { get; }
        public enum Quality
        {
            _10k,
            _18k,
            _21k
        }

        public Type SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                NotifyOfPropertyChange(() => SelectedType);

            }
        }

        public Quality SelectedQuality
        {
            get => _selectedQuality;
            set
            {
                _selectedQuality = value;
                NotifyOfPropertyChange(() => SelectedQuality);
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
        public void AddRandomFields()
        {
            var rqual = Enum.GetValues(typeof(Quality));
            var rtype = Enum.GetValues(typeof(Models.Type));
            var randomqual = (Quality)rqual.GetValue(rand.Next(rqual.Length));
            var randomtyp = (Models.Type)rtype.GetValue(rand.Next(rtype.Length));
            SelectedQuality = randomqual;
            SelectedType = (Type) randomtyp;
            Weight = rand.Next(5, 1500).ToString();
            Discount = rand.NextDouble().ToString();
            ActualValue = NumberGenerator(4).ToString();
            OtherDetail = LoremIpsum(2, 8, 3, 4, 1);
            NotifyOfPropertyChange(() => SelectedQuality);
            NotifyOfPropertyChange(() => SelectedType);
            NotifyOfPropertyChange(() => Weight);
            NotifyOfPropertyChange(() => Discount);
            NotifyOfPropertyChange(() => ActualValue);
            NotifyOfPropertyChange(() => OtherDetail);


        }
        public void Ok()
        {
            //Do stuff
            var jewl = new Jewelry();
            jewl.Quality = (Models.Quality) SelectedQuality;
            jewl.Type = (Models.Type) SelectedType;
            jewl.Weight = double.Parse(Weight);
            jewl.Discount = double.Parse(Discount);
            jewl.ActualValue = double.Parse(ActualValue);
            jewl.OtherDetail = OtherDetail;
            SettingsViewModel.SelectedCustomer.Jewelries.Add(jewl);
            NotifyOfPropertyChange(() => SettingsViewModel);
            NotifyOfPropertyChange(() => SettingsViewModel.SelectedCustomer.Jewelries);
            NotifyOfPropertyChange(() => CustomerViewModel.Jewelries);
            MyDialogResult = DialogResult.OK;
            TryClose();
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



        static string LoremIpsum(int minWords, int maxWords,
            int minSentences, int maxSentences,
            int numParagraphs)
        {

            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                               + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
            }

            return result.ToString();
        }



    }
}
