using System.Windows.Controls;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Plan : Page
    {
        public string TourID;
        public PageTourDetail_Plan(string tourId)
        {
            TourID = tourId;
            InitializeComponent();
        }
    }
}