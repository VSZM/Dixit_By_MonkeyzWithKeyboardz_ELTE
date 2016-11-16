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
        private DixitClientViewModel _gameViewModel;
        // viewmodel instance to handle gamestart
        private LoginViewModel _loginViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //_loginWindow = new LoginWindow();
            //_loginWindow.DataContext = _loginViewModel;
            //_loginWindow.Show();

            _mainWindow = new MainWindow();
            _gameViewModel = new DixitClientViewModel();
            _mainWindow.DataContext = _gameViewModel;
            _mainWindow.Show();
        }

        public App()
        {
            _loginViewModel = new LoginViewModel();
            _loginViewModel.Failed += new EventHandler(ViewModel_LoginFailed);
            _loginViewModel.Success += new EventHandler(ViewModel_LoginSuccess);
        }

        private void ViewModel_LoginFailed(object sender, EventArgs e)
        {
            // TODO: add proper reason why it failed through EventArgs.
            MessageBox.Show("Login failed!.", "Worksheet Manager", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ViewModel_LoginSuccess(object sender, EventArgs e)
        {
            //TODO: get initial gamestate from eventargs and initialise viewmodel
            _mainWindow = new MainWindow();
            _gameViewModel = new DixitClientViewModel();
            _mainWindow.DataContext = _gameViewModel;
            _mainWindow.Show();
            _loginWindow.Close();
        }
    }
}
