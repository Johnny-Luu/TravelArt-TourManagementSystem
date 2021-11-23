using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTour : Page
    {
        public PageTour()
        {
            InitializeComponent();
        }

        private void LbTour_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            LbTour.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }

        private void LbDestination_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            LbDestination.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }
    }
}