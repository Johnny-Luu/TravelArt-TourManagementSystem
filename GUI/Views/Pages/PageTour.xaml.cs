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
         
       
            ResetNavItemsToDefault();
            LbTour.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }

        private void LbTour_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbTour.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }

        private void LbDestination_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbDestination.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }
        private void ResetNavItemsToDefault()
        {
            LbTour.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbDestination.Style = Application.Current.Resources["NavItemStyle"] as Style;
            
        }
    }
}