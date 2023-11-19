using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for QuestionView.xaml
    /// </summary>
    public partial class QuestionView : Window
    {
        public QuestionView(string question, EventArgs args)
        {
            InitializeComponent();
            DataContext = new QuestionViewModel(question);

            if (args is CancelEventArgs)
            {
                btnNo.Click += (sender, e) =>
                {
                    ((CancelEventArgs)args).Cancel=true;
                    Close();
                };

                btnYes.Click += (sender, e) =>
                {
                    Close();
                };

            } else if (args is RoutedEventArgs) 
            {
                btnNo.Click += (sender, e) =>
                {
                    Close();
                };

                btnYes.Click += (sender, e) =>
                {
                    Window view = WindowUtils.FindParentWindow((args as RoutedEventArgs).OriginalSource as Button);
                    (view as SettingsView).ApplySettings = true;
                    Close();
                };
            }
        }

   



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);

            if (e.Key == Key.Escape)
            {
                btnNo.RaiseEvent(args);
            } else if (e.Key == Key.Enter)
            {
                btnYes.RaiseEvent(args);
            }
        }
    }
}
