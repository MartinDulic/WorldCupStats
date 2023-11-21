using DAL.Model;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        MatchData matchData;
        Player playa;
        public PlayerControl(Player player, MatchData match)
        {
            InitializeComponent();
            DataContext = new PlayerControlViewModel(player);
            playa = player;
            matchData = match;
        }

        private void btnControlButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PlayerInfoView(playa, matchData);
            dialog.ShowDialog();
        }

        private void usc_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
