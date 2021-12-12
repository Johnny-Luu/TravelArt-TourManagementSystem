using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;
using GUI.Views.Components;

namespace GUI.Views.MainWindow
{
    public partial class TourGroupDetailWindow : Window
    {
        private string _tourGroupId;

        public TourGroupDetailWindow(string tourGroupId)
        {
            InitializeComponent();
            _tourGroupId = tourGroupId;
            LoadData();
        }

        private async void LoadData()
        {
            var today = DateTime.Now.Date;
            var isTourOverOrOnTrip = false;
            var tourGroupBLL = new TourGroupBLL();
            var tourGroup = await tourGroupBLL.GetTourGroupById(_tourGroupId);
            
            // Load data to UI
            LbId.Content = "ID: " + tourGroup.Id;
            LbName.Content = "Name: " + tourGroup.Name;
            LbTour.Content = "Tour: " + tourGroup.TourName;
            LbCurrentSlot.Content = "Current slot: " + tourGroup.Slot;
            LbStartDay.Content = "Start day: " + tourGroup.StartDate?.ToString("dd/MM/yyyy");
            LbEndDay.Content = "End day: " + tourGroup.EndDate?.ToString("dd/MM/yyyy");
            LbTourLeaderId.Content = "ID: " + tourGroup.TourLeaderId;
            LbTourLeaderName.Content = "Name: " + tourGroup.TourLeaderName;
            LbTourDeputyId.Content = "ID: " + tourGroup.TourDeputyId;
            LbTourDeputyName.Content = "Name: " + tourGroup.TourDeputyName;
            
            // Check if tour is over or on trip
            if (tourGroup.EndDate <= today) isTourOverOrOnTrip = true;
            if (tourGroup.StartDate <= today && today <= tourGroup.EndDate) isTourOverOrOnTrip = true;
            
            // Load list of tourism
            if (!string.IsNullOrEmpty(tourGroup.CustomerList))
            {
                var customerBLL = new CustomerBLL();
                var tourismList = tourGroup.CustomerList.Split(',');
                foreach (var tourismId in tourismList)
                {
                    var tourism = await customerBLL.GetCustomerByID(tourismId);
                    var item = new TourismItem();
                    item.LbName.Content = tourism.Name;
                    item.LbId.Content = "CustomerID: " + tourism.Id;
                    item.LbTourGroupId.Content = tourGroup.Id;

                    if (isTourOverOrOnTrip) item.BtnDelete.Visibility = Visibility.Collapsed;
                
                    WpListOfTourism.Children.Add(item);
                }
            }
            else
            {
                // TODO: HANDLE EMPTY TOURISM LIST HERE
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void WpListOfTourism_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is TourismItem)
            {
                var tourismItem = (TourismItem)e.Source;
                WpListOfTourism.Children.Remove(tourismItem);
            }
        }
    }
}