using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Dixit_Client.Model;

namespace Dixit_Client.View
{
    /// <summary>
    /// Interaction logic for PlayerData.xaml
    /// </summary>
    public partial class PlayerData : UserControl
    {
        public PlayerData()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty PlayerProperty = DependencyProperty.Register("Player", typeof(ClientPlayer), typeof(PlayerData), new PropertyMetadata(null));

        public ClientPlayer Player
        {
            get { return (ClientPlayer)GetValue(PlayerProperty); }
            set { SetValue(PlayerProperty, value); }
        }
    }
}
