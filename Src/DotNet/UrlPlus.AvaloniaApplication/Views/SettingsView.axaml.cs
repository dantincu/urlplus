using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UrlPlus.AvaloniaApplication.ViewModels;

namespace UrlPlus.AvaloniaApplication.Views
{
    public partial class SettingsView : ReactiveUserControl<SettingsViewModel>
    {
        public SettingsView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
