using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
namespace GUI.Views.Pages
{
    public partial class PageStatistic : Page
    {
        private PageStatistic_Tour _frameTour = null;
        private PageStatistic_Staff _frameStaff = null;
        public PageStatistic()
        {
            InitializeComponent();
             _frameTour = new PageStatistic_Tour();
             _frameStaff = new PageStatistic_Staff();
             LbTour.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
             FrameContainer.Content = _frameTour;
        }

        private void MouseDown_Tour(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbTour.Style =Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrameContainer.Content = _frameTour;
            
        }

        private void MouseDown_Staff(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbStaff.Style =Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrameContainer.Content = _frameStaff;
        }
        private void ResetNavItemsToDefault()
        {
            LbTour.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbStaff.Style = Application.Current.Resources["NavItemStyle"] as Style;
            
        }
    }
}