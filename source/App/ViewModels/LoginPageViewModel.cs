using System;
using System.Threading.Tasks;
using App.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using RestApiClient.Contracts;
using Windows.UI.Xaml;

namespace App.ViewModels {

    /// <summary>
    /// Login page View Model
    /// </summary>
    public class LoginPageViewModel : ViewModelBase {

        private string _username;
        private string _password;
        private string _message;
        private bool _isBusy = false;
        private Visibility _visibility = Visibility.Collapsed;

        /// <summary>
        /// User Name
        /// </summary>
        public string Username {
            get => _username;
            set {
                if (SetProperty(ref _username, value)) {
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// User Password
        /// </summary>
        public string Password {
            get => _password;
            set {
                if (SetProperty(ref _password, value)) {
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Error message to display
        /// </summary>
        public string Message {
            get => _message;
            set {
                SetProperty(ref _message, value);
                MessageVisibility = string.IsNullOrEmpty(_message) ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        /// <summary>
        /// Message Visibility
        /// </summary>
        public Visibility MessageVisibility {
            get => _visibility;
            set => SetProperty(ref _visibility, value);
        }

        /// <summary>
        /// Is page busy
        /// </summary>
        public bool IsBusy {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        /// <summary>
        /// Log In Command
        /// </summary>
        public DelegateCommand SignInCommand { get; private set; }

        /// <summary>
        /// Playground Service
        /// </summary>
        private readonly IPlaygroundService playground;

        /// <summary>
        /// Navigation service
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Injects services
        /// </summary>
        /// <param name="service">Playground API</param>
        /// <param name="navigation">Navigation service</param>
        public LoginPageViewModel(IPlaygroundService service, INavigationService navigation) {
            playground = service;
            _navigationService = navigation;
            SignInCommand = new DelegateCommand(async () => await SignInAsync(), CanSignIn);
        }

        /// <summary>
        /// True if user provided credentials
        /// </summary>
        /// <returns>true if user provided credentials</returns>
        private bool CanSignIn() {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        /// <summary>
        /// Executes Log In
        /// </summary>
        private async Task SignInAsync() {
            // already working
            if (IsBusy) return;

            IsBusy = true;
            Message = String.Empty;
            AuthorizationResult result;
            try {
                result = await playground.Authorize(Username, Password);
                if (result.IsValid) {
                    _navigationService.Navigate(PageTokens.Server.ToString(), null);
                } else {
                    Message = result.Message;
                }
            } catch (Exception ex) {
                Message = ex.Message;
            }
            IsBusy = false;
        }

    }
}
