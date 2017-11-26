using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for HistogramPage.xaml
    /// </summary>
    public partial class HistogramPage : Page
    {
        Frame parent;
        Frame frm;
        MainWindow mw = new MainWindow();

        //   Random rand = new Random();
        enum DaysOfWeek
        {
            Mon = 1, Tue = 2, Wed, Thur, Fri, Sat, Sun
        }
        public HistogramPage(Frame frm)
        {
            parent = frm;

            InitializeComponent();
            createHistogram();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            parent.GoBack();
        }
        private void frmSwater_ContentRendered(object sender, EventArgs e)
        {
            //stops the navigation bar from appearing
            frmSwater.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void btnWater_Click(object sender, RoutedEventArgs e)
        {
            //WaterUpdate waterU = new WaterUpdate(new MainWindow());
            //frmSwater.Navigate(waterU);

            frm = p.Child as Frame;
            // hp = new HistogramPage();
            // frm = popTrackerPop.Child as Frame;
            Page page;
            page = new WaterUpdate(this);
            frm.Width = page.Width;
            frm.Height = page.Width;
            frm.Navigate(page);
            //disables histogram page
            frmSwater.IsEnabled = false;

            //opens popup
            p.IsOpen = true;

        }
        private void btnSleep_Click(object sender, RoutedEventArgs e)
        {
            frm = p.Child as Frame;

            Page page;
            page = new SleepUpdate(this);
            frm.Width = page.Width;
            frm.Height = page.Width;
            frm.Navigate(page);
            //Disables histogram page
            frmSwater.IsEnabled = false;

            //opens popup
            p.IsOpen = true;

        }
        private void createHistogram()
        {
            List<KeyValuePair<DaysOfWeek, int>> waterList = new List<KeyValuePair<DaysOfWeek, int>>();
            //Testing out a dummy solution 
            /*  for(int i = 1; i <= 7; i++)
              {
                  lineList.Add(new KeyValuePair<int, int>(i, rand.Next(1,11)));
              } */
            //Adding each pair to the waterList
            waterList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 2));
            waterList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 1));
            waterList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 5));
            waterList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 5));
            waterList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 2));
            waterList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 4));
            waterList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 4));
            //Adding data to the line graph
            Water.DataContext = waterList;

            List<KeyValuePair<DaysOfWeek, int>> wGoalList = new List<KeyValuePair<DaysOfWeek, int>>();
            wGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 3));
            wGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 3));
            wGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 4));
            wGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 3));
            wGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 3));
            wGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 4));
            wGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 4));

            WaterGoal.DataContext = wGoalList;

            List<KeyValuePair<DaysOfWeek, int>> sleepList = new List<KeyValuePair<DaysOfWeek, int>>();
            sleepList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 6));
            sleepList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 7));
            sleepList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 7));
            sleepList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 8));
            sleepList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 8));
            sleepList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 8));
            sleepList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 5));

            Sleep.DataContext = sleepList;

            List<KeyValuePair<DaysOfWeek, int>> sGoalList = new List<KeyValuePair<DaysOfWeek, int>>();
            sGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 8));
            sGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 8));
            sGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 8));
            sGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 8));
            sGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 8));
            sGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 8));
            sGoalList.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 8));

            SleepGoal.DataContext = sGoalList;
            //Gets the current date
            DateTime date = DateTime.Now.Date;

            //Use date1 variable in conditional instead of date variable
            //in case we want to show a particular day
            // DateTime date1 = new DateTime(2017, 11, 21);

            //Conditionals to check the current day and display that particuar
            //day's data
            if (date.ToString("ddd") == "Mon")
            {
                List<KeyValuePair<DaysOfWeek, int>> waterList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                waterList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 2));

                Water1.DataContext = waterList1;

                List<KeyValuePair<DaysOfWeek, int>> wGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                wGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 3));

                WaterGoal1.DataContext = wGoalList1;

                List<KeyValuePair<DaysOfWeek, int>> sleepList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sleepList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 6));

                Sleep1.DataContext = sleepList1;

                List<KeyValuePair<DaysOfWeek, int>> sGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)1, 8));

                SleepGoal1.DataContext = sGoalList1;


            }

            if (date.ToString("ddd") == "Tue")
            {
                List<KeyValuePair<DaysOfWeek, int>> waterList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                waterList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 1));

                Water1.DataContext = waterList1;

                List<KeyValuePair<DaysOfWeek, int>> wGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                wGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 3));

                WaterGoal1.DataContext = wGoalList1;

                List<KeyValuePair<DaysOfWeek, int>> sleepList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sleepList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 7));

                Sleep1.DataContext = sleepList1;

                List<KeyValuePair<DaysOfWeek, int>> sGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)2, 8));

                SleepGoal1.DataContext = sGoalList1;



            }

            if (date.ToString("ddd") == "Wed")
            {
                List<KeyValuePair<DaysOfWeek, int>> waterList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                waterList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 5));

                Water1.DataContext = waterList1;

                List<KeyValuePair<DaysOfWeek, int>> wGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                wGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 4));

                WaterGoal1.DataContext = wGoalList1;

                List<KeyValuePair<DaysOfWeek, int>> sleepList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sleepList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 7));

                Sleep1.DataContext = sleepList1;

                List<KeyValuePair<DaysOfWeek, int>> sGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)3, 8));

                SleepGoal1.DataContext = sGoalList1;


            }

            if (date.ToString("ddd") == "Thu")
            {
                List<KeyValuePair<DaysOfWeek, int>> waterList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                waterList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 5));

                Water1.DataContext = waterList1;

                List<KeyValuePair<DaysOfWeek, int>> wGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                wGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 3));

                WaterGoal1.DataContext = wGoalList1;

                List<KeyValuePair<DaysOfWeek, int>> sleepList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sleepList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 8));

                Sleep1.DataContext = sleepList1;

                List<KeyValuePair<DaysOfWeek, int>> sGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)4, 8));

                SleepGoal1.DataContext = sGoalList1;


            }

            if (date.ToString("ddd") == "Fri")
            {
                List<KeyValuePair<DaysOfWeek, int>> waterList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                waterList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 2));

                Water1.DataContext = waterList1;

                List<KeyValuePair<DaysOfWeek, int>> wGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                wGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 3));

                WaterGoal1.DataContext = wGoalList1;

                List<KeyValuePair<DaysOfWeek, int>> sleepList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sleepList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 8));

                Sleep1.DataContext = sleepList1;

                List<KeyValuePair<DaysOfWeek, int>> sGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)5, 8));

                SleepGoal1.DataContext = sGoalList1;


            }

            if (date.ToString("ddd") == "Sat")
            {
                List<KeyValuePair<DaysOfWeek, int>> waterList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                waterList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 4));

                Water1.DataContext = waterList1;

                List<KeyValuePair<DaysOfWeek, int>> wGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                wGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 4));

                WaterGoal1.DataContext = wGoalList1;

                List<KeyValuePair<DaysOfWeek, int>> sleepList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sleepList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 8));

                Sleep1.DataContext = sleepList1;

                List<KeyValuePair<DaysOfWeek, int>> sGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)6, 8));

                SleepGoal1.DataContext = sGoalList1;


            }

            if (date.ToString("ddd") == "Sun")
            {
                List<KeyValuePair<DaysOfWeek, int>> waterList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                waterList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 4));

                Water1.DataContext = waterList1;

                List<KeyValuePair<DaysOfWeek, int>> wGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                wGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 4));

                WaterGoal1.DataContext = wGoalList1;

                List<KeyValuePair<DaysOfWeek, int>> sleepList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sleepList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 5));

                Sleep1.DataContext = sleepList1;

                List<KeyValuePair<DaysOfWeek, int>> sGoalList1 = new List<KeyValuePair<DaysOfWeek, int>>();
                sGoalList1.Add(new KeyValuePair<DaysOfWeek, int>((DaysOfWeek)7, 8));

                SleepGoal1.DataContext = sGoalList1;
            }

        }

    }
}
