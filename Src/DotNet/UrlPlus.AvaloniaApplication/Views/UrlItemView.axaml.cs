using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UrlPlus.AvaloniaApplication.ViewModels;

namespace UrlPlus.AvaloniaApplication.Views
{
    public partial class UrlItemView : ReactiveUserControl<UrlItemViewModel>
    {
        // private MainViewModel viewModel;

        public UrlItemView()
        {
            /* InitializeComponent();

            this.Loaded += MainView_Loaded; */

            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }

        /* private void MainView_Loaded(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (viewModel == null)
            {
                viewModel = DataContext as MainViewModel;
                viewModel.TopLevel = TopLevel.GetTopLevel(this);

                viewModel.DefaultOutputTextForeground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                viewModel.SuccessOutputTextForeground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                viewModel.ErrorOutputTextForeground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            }
        } */
    }
}
