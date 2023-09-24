using Avalonia.Media;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace UrlPlus.AvaloniaApplication.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        private readonly IServiceProvider svcProv;

        private IAppGlobalsData appGlobals;

        private IBrush buttonNewUrlItemForeground;
        private IBrush buttonSaveUrlItemForeground;
        private IBrush buttonUrlItemsHistoryForeground;
        private IBrush buttonSyncUrlItemsForeground;
        private IBrush buttonSettingsForeground;

        public MainWindowViewModel()
        {
            svcProv = ServiceProviderContainer.Instance.Value.SvcProv;
            // Manage the routing state. Use the Router.Navigate.Execute
            // command to navigate to different view models. 
            //
            // Note, that the Navigate.Execute method accepts an instance 
            // of a view model, this allows you to pass parameters to 
            // your view models, or to reuse existing view models.
            //
            NewItem = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new UrlItemViewModel(this))
            );
        }

        // The Router associated with this Screen.
        // Required by the IScreen interface.
        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> NewItem { get; }

        public IBrush ButtonNewUrlItemForeground
        {
            get => buttonNewUrlItemForeground;

            set => this.RaiseAndSetIfChanged(
                ref buttonNewUrlItemForeground,
                value);
        }

        public IBrush ButtonSaveUrlItemForeground
        {
            get => buttonSaveUrlItemForeground;

            set => this.RaiseAndSetIfChanged(
                ref buttonSaveUrlItemForeground,
                value);
        }

        public IBrush ButtonUrlItemsHistoryForeground
        {
            get => buttonUrlItemsHistoryForeground;

            set => this.RaiseAndSetIfChanged(
                ref buttonUrlItemsHistoryForeground,
                value);
        }

        public IBrush ButtonSyncUrlItemsForeground
        {
            get => buttonSyncUrlItemsForeground;

            set => this.RaiseAndSetIfChanged(
                ref buttonSyncUrlItemsForeground,
                value);
        }

        public IBrush ButtonSettingsForeground
        {
            get => buttonSettingsForeground;

            set => this.RaiseAndSetIfChanged(
                ref buttonSettingsForeground,
                value);
        }

        public void Initialize()
        {
            appGlobals = svcProv.GetRequiredService<AppGlobals>().Data;

            ButtonNewUrlItemForeground = appGlobals.DefaultMaterialIconsForeground;
            ButtonSaveUrlItemForeground = appGlobals.DefaultMaterialIconsForeground;
            ButtonUrlItemsHistoryForeground = appGlobals.DefaultMaterialIconsForeground;
            ButtonSyncUrlItemsForeground = appGlobals.DefaultMaterialIconsForeground;
            ButtonSettingsForeground = appGlobals.DefaultMaterialIconsForeground;

            Router.Navigate.Execute(new UrlItemViewModel(this));
        }
    }
}
