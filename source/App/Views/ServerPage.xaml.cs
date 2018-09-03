using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prism.Windows.Mvvm;
using System.ComponentModel;
using App.ViewModels;


namespace App.Views {

    /// <summary>
    /// Server Page
    /// </summary>
    public sealed partial class ServerPage : SessionStateAwarePage, INotifyPropertyChanged {

        /// <summary>
        /// INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Server Page View Model
        /// </summary>
        public ServerPageViewModel ConcreteDataContext {
            get {
                return DataContext as ServerPageViewModel;
            }
        }

        /// <summary>
        /// Initialize page
        /// </summary>
        public ServerPage() {
            this.InitializeComponent();
            DataContextChanged += ServerPage_DataContextChanged;
        }

        /// <summary>
        /// Fires when data context changes
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event args</param>
        private void ServerPage_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConcreteDataContext)));
        }
    }
}
