using System.Drawing;
using System.Windows;
using GUI.Views.Components;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Plan : Page
    {
        private string TourID;
        public int TourLenght=5;
        public PageTourDetail_Plan(string _tourId)
        {
            TourID = _tourId;
            InitializeComponent();
        }
        public string GetTourID()
        {
            return TourID;
        }

        public void InitDes(DestinationControl desCtrl, int day)
        {
            Label lb = new Label
            {
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Content = "Day " + day.ToString()
            };

            WpContaner.Children.Add(lb);
            WpContaner.Children.Add(desCtrl);
        }


    }
}