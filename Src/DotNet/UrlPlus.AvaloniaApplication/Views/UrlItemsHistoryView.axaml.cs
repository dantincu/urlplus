using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UrlPlus.AvaloniaApplication.ViewModels;

namespace UrlPlus.AvaloniaApplication.Views
{
    public partial class UrlItemsHistoryView : ReactiveUserControl<UrlItemsHistoryViewModel>
    {
        public UrlItemsHistoryView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
