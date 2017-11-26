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
using System.Windows.Controls.Primitives;
using System.Windows.Resources;

namespace HCIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //array to store tracker buttons
        Button[] TrackerButtons;

        //bool values to track if certain things are being tracked
        public bool waterTracked;
        public bool sleepTracked;

        public MainWindow()
        {
            InitializeComponent();
            //initializes the tracker buttons into an array for easy updating
            TrackerButtons = new Button[8];
            TrackerButtons[0] = btnTracker0;
            TrackerButtons[1] = btnTracker1;
            TrackerButtons[2] = btnTracker2;
            TrackerButtons[3] = btnTracker3;
            TrackerButtons[4] = btnTracker4;
            TrackerButtons[5] = btnTracker5;
            TrackerButtons[6] = btnTracker6;
            TrackerButtons[7] = btnTracker7;
        }

        private void btnPreferences_Click(object sender, RoutedEventArgs e)
        {
            //creates a new preferences page
            PreferencesPage preferences = new PreferencesPage(frmMain);
            //opens that page in the main window frame
            frmMain.Navigate(preferences);
        }

        private void frmMain_ContentRendered(object sender, EventArgs e)
        {
            //stops the ugle navigation bar from appearing when the navigate method is called
            frmMain.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void btnTracker_Click(object sender, RoutedEventArgs e)
        {
            //pull button and grid from form
            Button button = sender as Button;
            Frame frm = popTrackerPop.Child as Frame;

            Page page;

            //switch case to determine which popup opens
            switch (button.Tag.ToString())
            {
                case "empty":
                    page = new AddTrackerPage(this);
                    frm.Width = page.Width; frm.Height = page.Width;
                    frm.Navigate(page);
                    break;
                case "Water":
                    page = new WaterUpdate(this);
                    frm.Width = page.Width; frm.Height = page.Width;
                    frm.Navigate(page);
                    break;
                case "Sleep":
                    page = new SleepUpdate(this);
                    frm.Width = page.Width; frm.Height = page.Width;
                    frm.Navigate(page);
                    break;
                default:
                    return;

            }
            //stops user from interacting with the rest of the app while the dialog is visible
            frmMain.IsEnabled = false;

            //opens popup
            popTrackerPop.IsOpen = true;

        }

        //used to update type and visibility of tracker buttons when a new button is added
        public void UpdateTrackerButtons()
        {
            int i = 0;

            Button button;

            //check if user wants water tracked. add button if so
            if (waterTracked)
            {
                button = TrackerButtons[i];
                i++;
                //Set the correct image to button
                Uri r = new Uri("images/water.png", UriKind.Relative);
                StreamResourceInfo s = Application.GetResourceStream(r);
                BitmapFrame b = BitmapFrame.Create(s.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = b;
                button.Background = brush;
                button.Content = "";
                button.Tag = "Water";
                button.Visibility = Visibility.Visible;
            }
            //check if user wants sleep tracked. add button if so
            if (sleepTracked)
            {
                button = TrackerButtons[i];
                i++;
                //Set the correct image to button
                Uri r = new Uri("images/sleep.png", UriKind.Relative);
                StreamResourceInfo s = Application.GetResourceStream(r);
                BitmapFrame b = BitmapFrame.Create(s.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = b;
                button.Background = brush;
                button.Tag = "Sleep";
                button.Content = "";
                button.Visibility = Visibility.Visible;
            }
            //other trackables would be added here

            //add the "Add new trackable button at the end
            button = TrackerButtons[i];
            i++;

            button.Content = "+";
            button.Tag = "empty";
            button.Visibility = Visibility.Visible;

            //hide the rest of the buttons
            while (i < 7)
            {
                button = TrackerButtons[i];
                i++;
                button.Visibility = Visibility.Hidden;
            }

        }

        private void btnHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new HistogramPage(this));
        }


    }
}
