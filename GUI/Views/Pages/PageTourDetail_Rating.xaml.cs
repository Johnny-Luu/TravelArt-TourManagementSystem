using System.Windows.Controls;
using GUI.Views.Components;

namespace GUI.Views.Pages
{
    public partial class PageTourDetail_Rating : Page
    {
        public PageTourDetail_Rating()
        {
            InitializeComponent();
            InitChartFrame(5,2,6,1,20);
            InitCommentPanel();
        }

        public void InitChartFrame(int r1, int r2, int r3, int r4, int r5)
        {
            FrChart.Content = new TourRating(r1,r2,r3,r4,r5);
        }

        public void InitCommentPanel()
        {
            Comment item = new Comment();
           // FrCmt.Content = new ListComment();
           WpListCmt.Children.Add(item);
           Comment item2 = new Comment();
           WpListCmt.Children.Add(item2);
        }
    }
}