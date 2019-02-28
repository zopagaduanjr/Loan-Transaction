using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Loan.Core.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> Clear { get; }
        [ObservableAsProperty] public string Greeting { get; }
        [Reactive] public string Name { get; set; } = string.Empty;

        public MainViewModel()
        {
            Clear = ReactiveCommand.Create(() => { Name = string.Empty; });
            this.WhenAnyValue(x => x.Name)
                .Select(name => $"Hello, {name}!")
                .ToPropertyEx(this, x => x.Greeting);
        }
    }

}