using System.ComponentModel;
using App.ViewModels;
using Prism.Windows.Mvvm;
using Windows.UI.Xaml;


namespace App.Views {

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : SessionStateAwarePage, INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets Login Page View Model
        /// </summary>
        public LoginPageViewModel ConcreteDataContext {
            get {
                return DataContext as LoginPageViewModel;
            }
        }

        /// <summary>
        /// Initialize page
        /// </summary>
        public LoginPage() {
            InitializeComponent();
            DataContextChanged += LoginPage_DataContextChanged;
        }


        /// <summary>
        /// Fires when View Model changes
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        private void LoginPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
        }
    }
}
