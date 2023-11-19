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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ViewModel;
using WPFApp;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for PlayerInfoView.xaml
    /// </summary>
    public partial class PlayerInfoView : Window
    {
        public PlayerInfoView(Player player, MatchData match)
        {
            InitializeComponent();
            DataContext = new PlayerInfoViewModel(player, match);
            WindowUtils.SetDesiredResolution(this);
        }


    }
}
