using System.Windows.Controls;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Plan : Page
    {
        private string TourID;
        public PageTourDetail_Plan(string _tourId)
        {
            TourID = _tourId;
            InitializeComponent();
        }
        public string GetTourID()
        {
            return TourID;
        }
    }
}