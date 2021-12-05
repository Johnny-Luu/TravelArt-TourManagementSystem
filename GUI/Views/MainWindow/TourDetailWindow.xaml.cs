﻿using System.Windows;
using System.Windows.Input;
using GUI.Views.Pages;

namespace GUI.Views.MainWindow

{
    public partial class TourDetailWindow : Window
    {
        public TourDetailWindow()
        {
            InitializeComponent();
            ResetNavItemsToDefault();
            LbInfo.Style =Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrContainer.Content = new PageTourDetail_Info();
        }
        private void BtnBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


        private void LbInfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrContainer.Content = new PageTourDetail_Info();
            ResetNavItemsToDefault();
            LbInfo.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
        }

        private void LbRating_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbRating.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrContainer.Content = new PageTourDetail_Rating();
        }
        
        private void LbPlan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ResetNavItemsToDefault();
            LbPlan.Style = Application.Current.Resources["NavItemClickedStyle"] as Style;
            FrContainer.Content = new PageTourDetail_Plan();
        }
        private void ResetNavItemsToDefault()
        {
            LbInfo.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbPlan.Style = Application.Current.Resources["NavItemStyle"] as Style;
            LbRating.Style = Application.Current.Resources["NavItemStyle"] as Style;
            
        }
    }
}