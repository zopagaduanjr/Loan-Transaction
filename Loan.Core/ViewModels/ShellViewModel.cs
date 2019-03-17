using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        CustomerViewModel customerViewModel = new CustomerViewModel();
        TransactionViewModel transactionViewModel = new TransactionViewModel();

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
            transactionViewModel.CustomerViewModel = customerViewModel;
            ActivateItem(transactionViewModel);
        }


    }
}
