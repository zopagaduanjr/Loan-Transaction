using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Loan.Core.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            LoadCustomerPage();
        }
        CustomerViewModel customerViewModel = new CustomerViewModel();

        public void LoadCustomerPage()
        {
            ActivateItem(customerViewModel);
        }

    }
}
