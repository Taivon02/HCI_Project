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

namespace HCIProject
{
    /// <summary>
    /// Interaction logic for AddTrackerPage.xaml
    /// </summary>
    public partial class AddTrackerPage : Page
    {
        Popup parent; //store a reference to the popup containing this window
        MainWindow window; //store a reference to the main window

        public AddTrackerPage(MainWindow w)
        {
            parent = w.popTrackerPop;
            window = w;
            InitializeComponent();
            //initialize which options will appear in the combobox. Already tracked items will not be available
            if (!window.waterTracked)
            {
                cmbTrackerSelect.Items.Add("Water");
            }
            if (!window.sleepTracked)
            {
                cmbTrackerSelect.Items.Add("Sleep");
            }
        }

        //handle when user presses the x button of the popup
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //re-enables the main for use
            window.frmMain.IsEnabled = true;
            //closes out the popup holding this page
            parent.IsOpen = false;
        }

        //event to handle if any of the tracker buttons are pressed
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //check the selected combobox item, and set the main window boolean value to reflect user choice
            if (cmbTrackerSelect.SelectedItem as string == "Water")
            {
                window.waterTracked = true;
            }
            else if (cmbTrackerSelect.SelectedItem as string == "Sleep")
            {
                window.sleepTracked = true;
            }
            //update main window tracker buttons to reflect changes
            window.UpdateTrackerButtons();

            //close out window
            btnClose_Click(null, null);

        }
    }
}
