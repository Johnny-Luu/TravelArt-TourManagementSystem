using System.Windows.Controls;
using GUI.Views.Components;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Rating : Page
    {
        private string TourID;
        public PageTourDetail_Rating(string _tourId)
        {
            TourID = _tourId;
            InitializeComponent();
        }
        public string GetTourID()
        {
            return TourID;
        }
        public void InitChartFrame(int r1,int r2,int r3,int r4,int r5)
        {
            var chart = new TourRating();
            chart.RatingChartInit(r1,r2,r3,r4,r5);
            FrChart.Content = chart;
        }

        public void InitCommentPanel(CommentComponent cmt)
        {
            WpListCmt.Children.Add(cmt);
           
        }
    }
}