using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Caliburn.Micro;
using Loan.Core.Models;
using Loan.Core.Views;

namespace Loan.Core.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            LoadCustomerPage();
        }

        public CustomerViewModel customerViewModel
        {
            get => _customerViewModel;
            set => _customerViewModel = value;
        }

        TransactionViewModel transactionViewModel = new TransactionViewModel();
        private CustomerViewModel _customerViewModel = new CustomerViewModel();

        public void LoadCustomerPage()
        {
            ActivateItem(customerViewModel);
        }
        public void LoadSettingsPage()
        {
            ActivateItem(customerViewModel.SettingsViewModel);
        }
        public void LoadTransactionPage()
        {
            transactionViewModel.SettingsViewModel = customerViewModel.SettingsViewModel;
            transactionViewModel.CustomerViewModel = customerViewModel;
            transactionViewModel.SelectedJewelry = null;
            transactionViewModel.LoanTransactViewer();
            ActivateItem(transactionViewModel);
        }


    }
}
