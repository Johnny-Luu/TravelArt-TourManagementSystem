using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Info : Page
    { 
        private string TourID;
        public PageTourDetail_Info(string _tourId)
        {
            TourID = _tourId;
            InitializeComponent();
        }

        public string GetTourID()
        {
            return TourID;
        }
    public void Set_LbPrice(string s)
    {
        LbPrice.Content = "Price: " + s + " VND";
    }
    public void Set_LbDuration(string s)
    {
        LbDuration.Content = "Duration: " + s + " Days";
    }
    public void Set_LbAvailable(string s)
    {
        LbAvailabe.Content = "Available: " + s + " Current Tours";
    }
    public void Set_LbVisit(string s)
    {
        LbVisit.Content = "Visit: " + s + " Locations";
    }

    private void EditTour(object sender, MouseButtonEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    }
}