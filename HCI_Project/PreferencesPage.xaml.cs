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

namespace HCIProject
{
    /// <summary>
    /// Interaction logic for PreferencesPage.xaml
    /// </summary>
    public partial class PreferencesPage : Page
    {
        Frame main; //store a reference to the frame containing this page upon creation

        public PreferencesPage(Frame mainFrame)
        {
            main = mainFrame;
            InitializeComponent();
        }

        private void btnBack_Button_Click(object sender, RoutedEventArgs e) => main.GoBack();

        private void btnNotifications_Click(object sender, RoutedEventArgs e)
        {
            //we aren't doing any actual notifications cause this isn't a real app. so this doesnt need to actually do anything more
            if (btnNotifications.Content.ToString() == "ON")
            {
                btnNotifications.Content = "OFF";
            }
            else
            {
                btnNotifications.Content = "ON";
            }
        }
    }
}
