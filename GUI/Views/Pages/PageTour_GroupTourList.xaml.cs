using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI.Views.Pages
{
    public partial class PageTour_GroupTourList : Page
    {
        public PageTour_GroupTourList()
        {
            InitializeComponent();
            LbAll.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }

        private void LbOntrip_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbOntrip.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }
        
        private void LbPlanning_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbPlanning.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }

        private void LbOver_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbOver.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }
        
        private void LbAll_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbAll.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }
        
        private void ResetNavItemsToDefault()
        {
            LbAll.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbOntrip.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbPlanning.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbOver.Style = Application.Current.Resources["NavItemStyle"] as Style;
        }
    }
}