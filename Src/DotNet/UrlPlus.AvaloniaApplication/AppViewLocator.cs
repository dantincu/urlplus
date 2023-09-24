using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlPlus.AvaloniaApplication.ViewModels;
using UrlPlus.AvaloniaApplication.Views;

namespace UrlPlus.AvaloniaApplication
{
    public class AppViewLocator : ReactiveUI.IViewLocator
    {
        public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
        {
            UrlItemViewModel context => new UrlItemView { DataContext = context },
            _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
        };
    }
}
