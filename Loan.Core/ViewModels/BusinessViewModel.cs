using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Loan.Core.Models;

namespace Loan.Core.ViewModels
{
    public class BusinessViewModel : Screen
    {
        private BindableCollection<Customer> _customers;
        private BindableCollection<LoanInfo> _presentLoanInfos;
        private BindableCollection<LoanInfo> _finishedLoanInfos;
        private BindableCollection<Jewelry> _jewelries;
        private SettingsViewModel _settingsViewModel;

        //ctor
        public BusinessViewModel()
        {
            
        }

        //fields
        public BindableCollection<Customer> Customers
        {
            get => _customers;
            set => _customers = value;
        }
        public BindableCollection<LoanInfo> PresentLoanInfos
        {
            get => _presentLoanInfos;
            set => _presentLoanInfos = value;
        }
        public BindableCollection<LoanInfo> FinishedLoanInfos
        {
            get => _finishedLoanInfos;
            set => _finishedLoanInfos = value;
        }
        public BindableCollection<Jewelry> Jewelries
        {
            get => _jewelries;
            set => _jewelries = value;
        }

        public SettingsViewModel SettingsViewModel
        {
            get => _settingsViewModel;
            set => _settingsViewModel = value;
        }

        public TransactionViewModel TransactionViewModel { get; set; }
    }
}
