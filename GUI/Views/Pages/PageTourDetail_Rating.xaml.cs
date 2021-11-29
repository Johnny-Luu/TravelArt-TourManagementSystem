using System.Windows.Controls;
using GUI.Views.Components;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Rating : Page
    {
        public PageTourDetail_Rating()
        {
            InitializeComponent();
            InitChartFrame();
            InitCommentPanel();
        }

        public void InitChartFrame()
        {
            TourRating chart = new TourRating();
            FrChart.Content = chart;
            
            chart.RatingChartInit(2,1,2,1,2);
        }

        public void InitCommentPanel()
        { 
            var item = new Comment(); 
            WpListCmt.Children.Add(item);
            
            var item2 = new Comment();
            WpListCmt.Children.Add(item2);
            
            var item3 = new Comment();
            WpListCmt.Children.Add(item3);
            
            var item4 = new Comment();
            WpListCmt.Children.Add(item4);
            
            var item5 = new Comment();
            WpListCmt.Children.Add(item5);
        }
    }
}