using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Model;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using RestApiClient.Contracts;

namespace App.ViewModels {

    public class ServerPageViewModel : ViewModelBase {

        private bool _isBusy = false;
        private IEnumerable<Server> _serverList;

        /// <summary>
        /// Playground Service
        /// </summary>
        private readonly IPlaygroundService playground;

        /// <summary>
        /// Navigation service
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Log Out Command
        /// </summary>
        public DelegateCommand SignOutCommand { get; private set; }

        /// <summary>
        /// Is page busy
        /// </summary>
        public bool IsBusy {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        /// <summary>
        /// List of servers
        /// </summary>
        public IEnumerable<Server> ServerList {
            get => _serverList;
            set => SetProperty(ref _serverList, value);
        }

        /// <summary>
        /// Injects services
        /// </summary>
        /// <param name="service">Playground API</param>
        /// <param name="navigation">Navigation service</param>
        public ServerPageViewModel(IPlaygroundService service, INavigationService navigation) {
            playground = service;
            _navigationService = navigation;
            SignOutCommand = new DelegateCommand(() => SignOut());
        }

        /// <summary>
        /// Gets server list after navigating to this page
        /// </summary>
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState) {
            base.OnNavigatedTo(e, viewModelState);
            IsBusy = true;
            Task<ServerResult> task = Task.Run(async () => await playground.GetServers());
            var result = task.Result;
            if (!string.IsNullOrEmpty(result.Message)) {
                // TODO: display error message
                _navigationService.GoBack();
            } else {
                ServerList = result.ServerList.OrderBy(s => s.Name);
            }
            IsBusy = false;
        }

        /// <summary>
        /// Executes Log Out
        /// </summary>
        private void SignOut() {
            playground.LogOut();
            ServerList = null;
            _navigationService.GoBack();
        }

    }
}
