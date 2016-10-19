using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Dixit_Client.View;
using Dixit_Client.ViewModel;

namespace Dixit_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Game window
        private MainWindow _mainWindow;
        // window to login the game
        private LoginWindow _loginWindow;
        // viewmodel instance that maintains the interaction between view and game logic
        private DixitClientViewModel _viewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _loginWindow = new LoginWindow();
            _loginWindow.DataContext = _viewModel;
            _loginWindow.Show();
        }

        public App()
        {
            _viewModel = new DixitClientViewModel();
            _viewModel.LoginFailed += new EventHandler(ViewModel_LoginFailed);
            _viewModel.LoginSuccess += new EventHandler(ViewModel_LoginSuccess);
        }

        private void ViewModel_LoginFailed(object sender, EventArgs e)
        {
            // TODO: add proper reason why it failed through EventArgs.
            MessageBox.Show("Login failed!.", "Worksheet Manager", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ViewModel_LoginSuccess(object sender, EventArgs e)
        {
            _mainWindow = new MainWindow();
            _mainWindow.DataContext = _viewModel;
            _mainWindow.Show();
            _loginWindow.Close();
        }
    }
}
