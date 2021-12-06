using System.Windows;
using System.Windows.Input;
using GUI.Views.Components;
using GUI.Views.MainWindow;
using GUI.Views.Pages;
using static System.Windows.WindowState;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (LbStatistic != null) LbStatistic.Style = Resources["NavItemClickedStyle"] as Style;
            FrContainer.Content = new PageTour_GroupTourList();
        }

        private void BtnMinimize_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void LbStatistic_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbStatistic.Style = Resources["NavItemClickedStyle"] as Style;
           FrContainer.Content = new PageStatistic();
            
        
            
        }

        private void LbConfirm_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbConfirm.Style = Resources["NavItemClickedStyle"] as Style;
            FrContainer.Content = new PageConfirm();
        }

        private void LbTour_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbTour.Style = Resources["NavItemClickedStyle"] as Style;
            FrContainer.Content = new PageTour();
        }

        private void LbAdding_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbAdding.Style = Resources["NavItemClickedStyle"] as Style;
            FrContainer.Content = new PageAdding();
        }

        private void ResetNavItemsToDefault()
        {
            LbStatistic.Style = Resources["NavItemStyle"] as Style;
            LbConfirm.Style = Resources["NavItemStyle"] as Style;
            LbTour.Style = Resources["NavItemStyle"] as Style;
            LbAdding.Style = Resources["NavItemStyle"] as Style;
        }
    }
}