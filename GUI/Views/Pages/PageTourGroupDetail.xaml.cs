using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;
using GUI.Views.Components;

namespace GUI.Views.Pages
{
    public partial class PageTourGroupDetail : Window
    {
        private string _tourGroupId;

        public PageTourGroupDetail(string tourGroupId)
        {
            InitializeComponent();
            _tourGroupId = tourGroupId;
            LoadData();
        }

        private async void LoadData()
        {
            var tourGroupBLL = new TourGroupBLL();
            var tourGroup = await tourGroupBLL.GetTourGroupByID(_tourGroupId);
            
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
            
            // Load list of tourism
            var customerBLL = new CustomerBLL();
            var tourismList = tourGroup.CustomerList.Split(',');
            foreach (var tourismId in tourismList)
            {
                var tourism = await customerBLL.GetCustomerByID(tourismId);
                var item = new TourismItem();
                item.LbName.Content = tourism.Name;
                WpListOfTourism.Children.Add(item);
            }
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}