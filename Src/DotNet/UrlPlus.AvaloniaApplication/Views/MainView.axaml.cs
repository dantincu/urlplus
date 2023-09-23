using Avalonia.Controls;
using Avalonia.Media;
using UrlPlus.AvaloniaApplication.ViewModels;

namespace UrlPlus.AvaloniaApplication.Views;

public partial class MainView : UserControl
{
    private MainViewModel viewModel;

    public MainView()
    {
        InitializeComponent();

        this.Loaded += MainView_Loaded;
    }

    #region UI Event Handlers

    private void MainView_Loaded(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (viewModel == null)
        {
            viewModel = DataContext as MainViewModel;
            viewModel.TopLevel = TopLevel.GetTopLevel(this);

            viewModel.DefaultOutputTextForeground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
            viewModel.SuccessOutputTextForeground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            viewModel.ErrorOutputTextForeground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }
    }

    #endregion UI Event Handlers
}
