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
    /// Interaction logic for CardData.xaml
    /// </summary>
    public partial class CardData : Button
    {
        public CardData()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CardProperty = DependencyProperty.Register("Card", typeof(ClientCard), typeof(CardData), new PropertyMetadata(null));

        public ClientCard Card
        {
            get { return (ClientCard)GetValue(CardProperty); }
            set { SetValue(CardProperty, value); }
        }
    }
}
