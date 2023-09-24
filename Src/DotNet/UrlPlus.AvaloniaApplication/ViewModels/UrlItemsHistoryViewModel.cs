using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlPlus.AvaloniaApplication.ViewModels
{
    public class UrlItemsHistoryViewModel : ViewModelBase, IRoutableViewModel
    {
        public UrlItemsHistoryViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }

        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

        public IScreen HostScreen { get; }
    }
}
