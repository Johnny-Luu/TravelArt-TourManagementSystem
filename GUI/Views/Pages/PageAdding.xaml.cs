using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GUI.Views.Pages;

namespace GUI.Views.Pages
{
    public partial class PageAdding : Page
    {
        public PageAdding()
        {
            InitializeComponent();
            LbTour.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrAddingContainer.Content = new PageAddingTourGroup();
        }

        private void LbTour_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbTour.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrAddingContainer.Content = new PageAddingTour();
        }

        private void LbDestination_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbDestination.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrAddingContainer.Content = new PageAddingDestination();
        }

        private void LbHotel_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbHotel.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrAddingContainer.Content = new PageAddingHotel();
        }
        
        private void ResetNavItemsToDefault()
        {
            LbTour.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbDestination.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbHotel.Style = Application.Current.Resources["NavItemStyle"] as Style;
        }
    }
}