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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the RotateTransform from the RenderTransform property
            RotateTransform rotateTransform = gridContent.RenderTransform as RotateTransform;

            // If RotateTransform doesn't exist, create and assign it
            if (rotateTransform == null)
            {
                rotateTransform = new RotateTransform();
                gridContent.RenderTransform = rotateTransform;
            }

            // Create a DoubleAnimation for the rotation
            DoubleAnimation rotateAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            // Apply the animation to the RotateTransform.Angle property
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
