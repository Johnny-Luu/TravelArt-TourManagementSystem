using GUI.Views.Components;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Plan : Page
    {
        private string TourID;
        public int TourLenght=5;
        private int currentDay;
        public PageTourDetail_Plan(string _tourId)
        {
            TourID = _tourId;
            currentDay = 1;
            InitializeComponent();
            UpdateLbDay();
           
            
        }
        public string GetTourID()
        {
            return TourID;
        }


        private void nextDay(object sender, MouseButtonEventArgs e)
        {
            currentDay++;
            if (currentDay > TourLenght) currentDay = 1;
            UpdateLbDay();
        }
        private void prevDay(object sender, MouseButtonEventArgs e)
        {
            currentDay--;
            if (currentDay < 1) currentDay = TourLenght;
            UpdateLbDay();
        }

        private void UpdateLbDay()
        {
            LbTourDay.Text = "Day " + currentDay.ToString();
        }
    }
}