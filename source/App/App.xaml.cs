﻿using System;
using System.Threading.Tasks;
using Prism.Unity.Windows;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Navigation;
using App.Services;
using Windows.System.Profile;
using Prism.Logging;
using Microsoft.Practices.Unity;
using Windows.Foundation.Metadata;

namespace App {

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication {

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App() {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args) {
            NavigationService.Navigate(PageTokens.Login.ToString(), null);
            ExtendAcrylicIntoTitleBar();
            return Task.FromResult(true);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args) {
            // Register web services
            Container.RegisterType<IPlaygroundService, PlaygroundService>(new ContainerControlledLifetimeManager());
            SetupLogging();
            return base.OnInitializeAsync(args);
        }

        /// <summary>
        /// Setup postsharp logging to EWT
        /// </summary>
        private void SetupLogging() {
            //var loggingBackend = new EventSourceLoggingBackend(new PostSharpEventSource());
            //if (loggingBackend.EventSource.ConstructionException != null)
            //   throw loggingBackend.EventSource.ConstructionException;
            //LoggingServices.DefaultBackend = loggingBackend;
            //logger.Write(LogLevel.Info, "Logging enabled");
           // Logger = new PostSharpLoggingFacade();
            Logger.Log("----------------Logging started", Category.Info, Priority.Low);
        }


        /// Extend acrylic into the title bar. 
        private void ExtendAcrylicIntoTitleBar() {
            if (string.Compare(AnalyticsInfo.VersionInfo.DeviceFamily, "Windows.Desktop", true) == 0) {
                CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
                ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            } else if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar")) {
                var statusbar = StatusBar.GetForCurrentView();
                statusbar.BackgroundColor = Colors.DarkBlue;
                statusbar.BackgroundOpacity = 1;
                statusbar.ForegroundColor = Colors.White;
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e) {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e) {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

    }
}
