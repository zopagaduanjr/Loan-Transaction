using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        //fields
        private CustomerViewModel _customerViewModel;
        private BindableCollection<Jewelry> _personJewelries = new BindableCollection<Jewelry>();
        private BindableCollection<LoanInfo> _personLoanInfo = new BindableCollection<LoanInfo>();
        private BindableCollection<Jewelry> _establishmentJewelries = new BindableCollection<Jewelry>();
        private Jewelry _selectedJewelry;
        private string _name;
        private string _jewelryToGive;
        private string _amount;
        private string _dateTime;

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

        public Jewelry SelectedJewelry
        {
            get => _selectedJewelry;
            set
            {
                _selectedJewelry = value;
                JewelryToGive = SelectedJewelry.Type.ToString();
                Amount = SelectedJewelry.ActualValue.ToString();
                DateTime = System.DateTime.Now.ToString();
                NotifyOfPropertyChange(() => SelectedJewelry);
                NotifyOfPropertyChange(() => JewelryToGive);
                NotifyOfPropertyChange(() => Amount);
                NotifyOfPropertyChange(() => DateTime);

            }
        }

        public string Name
        {
            get
            {
                var nem = CustomerViewModel.Name;
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
    }
}
