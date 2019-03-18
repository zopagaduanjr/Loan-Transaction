using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using Loan.Core.Models;

namespace Loan.Core.ViewModels
{
    public class TransactionViewModel : Screen
    {
        //ctor 
        public TransactionViewModel()
        {
            LoanTransactViewer();
        }

        //fields
        private CustomerViewModel _customerViewModel;
        private BindableCollection<Jewelry> _personJewelries = new BindableCollection<Jewelry>();
        private BindableCollection<LoanInfo> _personLoanInfo = new BindableCollection<LoanInfo>();
        private BindableCollection<Jewelry> _establishmentJewelries = new BindableCollection<Jewelry>();
        private BindableCollection<LoanInfo> _establishmentLoanInfo = new BindableCollection<LoanInfo>();
        private Jewelry _selectedJewelry;
        private string _name;
        private string _jewelryToGive;
        private string _amount;
        private string _dateTime;
        private bool _isLoanTransactionEnabled;
        private bool _isPaymentTransactionEnabled;
        private bool _loanTransactionCondition;
        private bool _paymentTransactionCondition;
        private LoanInfo _selectedLoan;
        public CustomerViewModel CustomerViewModel
        {
            get => _customerViewModel;
            set => _customerViewModel = value;
        }


        public BindableCollection<Jewelry> PersonJewelries
        {
            get
            {
                var jels = CustomerViewModel.Jewelries;
                return jels;
            }
            set => _personJewelries = value;
        }
        public BindableCollection<LoanInfo> PersonLoanInfo
        {
            get
            {
                var lons = CustomerViewModel.Loans;
                return lons;
            }
            set => _personLoanInfo = value;
        }
        public BindableCollection<Jewelry> EstablishmentJewelries
        {
            get => _establishmentJewelries;
            set => _establishmentJewelries = value;
        }
        public BindableCollection<LoanInfo> EstablishmentLoanInfo
        {
            get => _establishmentLoanInfo;
            set => _establishmentLoanInfo = value;
        }
        public Jewelry SelectedJewelry
        {
            get => _selectedJewelry;
            set
            {
                if (value != null)
                {
                    _selectedJewelry = value;
                    JewelryToGive = SelectedJewelry.Type.ToString();
                    Amount = SelectedJewelry.ActualValue.ToString();
                    DateTime = System.DateTime.Now.ToString();
                    LoanTransactionCondition = true;
                    NotifyOfPropertyChange(() => LoanTransactionCondition);
                    NotifyOfPropertyChange(() => SelectedJewelry);
                    NotifyOfPropertyChange(() => JewelryToGive);
                    NotifyOfPropertyChange(() => Amount);
                    NotifyOfPropertyChange(() => DateTime);

                }
                else
                {
                    _selectedJewelry = value;
                    JewelryToGive = null;
                    Amount = null;
                    DateTime = null;
                    LoanTransactionCondition = false;
                    NotifyOfPropertyChange(() => LoanTransactionCondition);
                    NotifyOfPropertyChange(() => SelectedJewelry);
                    NotifyOfPropertyChange(() => JewelryToGive);
                    NotifyOfPropertyChange(() => Amount);
                    NotifyOfPropertyChange(() => DateTime);

                    NotifyOfPropertyChange(() => SelectedJewelry);
                }
            }
        }
        public LoanInfo SelectedLoan
        {
            get => _selectedLoan;
            set
            {
                if (value != null)
                {
                    _selectedLoan = value;
                    PaymentTransactionCondition = true;
                    NotifyOfPropertyChange(() => SelectedLoan);
                    NotifyOfPropertyChange(() => PaymentTransactionCondition);

                }
                else
                {
                    _selectedLoan = value;
                    PaymentTransactionCondition = false;
                    NotifyOfPropertyChange(() => SelectedLoan);
                    NotifyOfPropertyChange(() => PaymentTransactionCondition);

                }
            }
        }
        public string Name
        {
            get
            {
                var nem = CustomerViewModel.FullName;
                return nem;
            }
            set => _name = value;
        }
        public string JewelryToGive
        {
            get => _jewelryToGive;

            set => _jewelryToGive = value;
        }
        public string Amount
        {
            get => _amount;

            set => _amount = value;
        }
        public string DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }

        //isclickables
        public bool IsLoanTransactionEnabled
        {
            get => _isLoanTransactionEnabled;
            set => _isLoanTransactionEnabled = value;
        }
        public bool IsPaymentTransactionEnabled
        {
            get => _isPaymentTransactionEnabled;
            set => _isPaymentTransactionEnabled = value;
        }
        public bool LoanTransactionCondition
        {
            get => _loanTransactionCondition;
            set => _loanTransactionCondition = value;
        }
        public bool PaymentTransactionCondition
        {
            get => _paymentTransactionCondition;
            set => _paymentTransactionCondition = value;
        }

        //methods
        public void LoanTransactViewer()
        {
            IsLoanTransactionEnabled = true;
            IsPaymentTransactionEnabled = false;
            NotifyOfPropertyChange(() => IsLoanTransactionEnabled);
            NotifyOfPropertyChange(() => IsPaymentTransactionEnabled);

        }
        public void PaymentTransactViewer()
        {
            IsLoanTransactionEnabled = false;
            IsPaymentTransactionEnabled = true;
            NotifyOfPropertyChange(() => IsLoanTransactionEnabled);
            NotifyOfPropertyChange(() => IsPaymentTransactionEnabled);

        }
        public void LoanTransactionCommand()
        {
            var personloaning = CustomerViewModel.SettingsViewModel.SelectedCustomer;
            var jewel = SelectedJewelry;
            jewel.UniqueId = RandomDigitGenerator();
            var loninfo = new LoanInfo();
            loninfo.Amount = jewel.ActualValue;
            loninfo.DateTime = System.DateTime.Now;
            loninfo.Jewelry = jewel;
            loninfo.Customer = personloaning;
            personloaning.Jewelries.Remove(jewel);
            NotifyOfPropertyChange(() => PersonJewelries);
            EstablishmentLoanInfo.Add(loninfo);
            personloaning.Loans.Add(loninfo);
        }
        public int RandomDigitGenerator()
        {
            var value = 0;
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                // Buffer storage.
                byte[] data = new byte[4];

                // Ten iterations.
                    rng.GetBytes(data);
                    // Convert to int 32.
                    int val = BitConverter.ToInt32(data,0);
                    value = Math.Abs(val);
                    var streng = value.ToString();
                    var lenth = streng.Length;
                    var x = lenth - 8;
                    streng = streng.Substring(0, streng.Length - x);
                    value = Int32.Parse(streng);
            }

            return value;
        }
    }
}
