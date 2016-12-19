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
            _viewModel.Failed += new EventHandler<String>(ViewModel_LoginFailed);
            _viewModel.StartGame += new EventHandler(ViewModel_StartGame);
        }

        private void ViewModel_LoginFailed(object sender, String e)
        {
            MessageBox.Show("Login failed!", e, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ViewModel_StartGame(object sender, EventArgs e)
        {
            _mainWindow = new MainWindow();
            _mainWindow.DataContext = _viewModel;
            _mainWindow.Show();
            _loginWindow.Close();
        }
    }
}
