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
    /// Interaction logic for WaterUpdate.xaml
    /// </summary>
    public partial class WaterUpdate : Page
    {
        MainWindow window = new MainWindow();
        HistogramPage hp;
        Popup parent;
        Popup hparent;
        int min = 0;
        int max = 100;
        int start = 0;
        int value = 0;
        string unit = "cup";

        public WaterUpdate(MainWindow mw)
        {
            window = mw;
            parent = mw.popTrackerPop;
            InitializeComponent();
            txtEntry.Text = start.ToString();
        }
        public WaterUpdate(HistogramPage histo)
        {
            hp = histo;
            hparent = histo.p;
            InitializeComponent();
            txtEntry.Text = start.ToString();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            parent = window.popTrackerPop;
            if (unit != "" && value != 0)
            {
                if (parent.IsOpen == true)
                {
                    //re-enables the main for use
                    window.frmMain.IsEnabled = true;
                    //closes out the popup holding this page
                    parent.IsOpen = false;
                }
                else if(hparent.IsOpen == true)
                {
                    hp.frmSwater.IsEnabled = true;
                    hparent.IsOpen = false;
                }
            }
            else
            {
                unit = "";
                value = 0;
                txtEntry.Text = start.ToString();
            }
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            parent = window.popTrackerPop;
            if (unit != "" && value != 0)
            {
                if (parent.IsOpen == true)
                {
                    //re-enables the main for use
                    window.frmMain.IsEnabled = true;
                    //closes out the popup holding this page
                    parent.IsOpen = false;
                }
                else if (hparent.IsOpen == true)
                {
                    hp.frmSwater.IsEnabled = true;
                    hparent.IsOpen = false;
                }
            }
            else
            {
                unit = "";
                value = 0;
                txtEntry.Text = start.ToString();
            }
        }
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (txtEntry.Text != "")
                n = Convert.ToInt32(txtEntry.Text);
            else n = 0;
            if (n < max)
                txtEntry.Text = Convert.ToString(n + 1);
            value = Convert.ToInt32(txtEntry.Text);
        }
        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (txtEntry.Text != "")
                n = Convert.ToInt32(txtEntry.Text);
            else n = 0;
            if (n > min)
                txtEntry.Text = Convert.ToString(n - 1);
            value = Convert.ToInt32(txtEntry.Text);
        }

        private void btnLiter_Click(object sender, RoutedEventArgs e)
        {
            unit = "liter";
            btnLiter.IsEnabled = false;
            btnOz.IsEnabled = true;
            btnCup.IsEnabled = true;
        }
        private void btnCup_Click(object sender, RoutedEventArgs e)
        {
            unit = "cup";
            btnLiter.IsEnabled = true;
            btnOz.IsEnabled = true;
            btnCup.IsEnabled = false;
        }
        private void btnOz_Click(object sender, RoutedEventArgs e)
        {
            unit = "oz";
            btnLiter.IsEnabled = true;
            btnOz.IsEnabled = false;
            btnCup.IsEnabled = true;
        }
    }
}
