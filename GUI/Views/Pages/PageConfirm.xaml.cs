using System;
using System.Windows.Controls;
using System.Windows.Input;
using BLL;
using GUI.Views.Components;

namespace GUI.Views.Pages
{
    public partial class PageConfirm : Page
    {
        private DateTime _today = DateTime.Now.Date;
        private int _countToday = 0;
        private int _countTotal = 0;
        
        public PageConfirm()
        {
            InitializeComponent();
            LoadAllRequest();
        }

        private async void LoadAllRequest()
        {
            var requestBLL = new RequestBLL();
            var listRequest = await requestBLL.GetAllRequest();

            foreach (var request in listRequest)
            {
                // request info
                var item = new ConfirmControl();
                item.LbRequestId.Content = request.Id;
                item.LbCustomerId.Content = "ID: " + request.CustomerId;
                item.LbRequestTime.Content = request.Time;
                if (request.Date == _today)
                {
                    item.LbRequestDate.Content = "Today";
                    _countToday++;
                }
                else
                {
                    item.LbRequestDate.Content = request.Date.ToString("dd/MM/yyyy");
                }
                
                // tour group info
                var tourGroupBLL = new TourGroupBLL();
                var tourGroup = await tourGroupBLL.GetTourGroupByID(request.TourGroupId);
                item.LbTourGroupId.Content = tourGroup.Id;
                item.LbTourGroupName.Content = tourGroup.Name;
                item.LbTourGroupDate.Content = tourGroup.StartDate?.ToString("dd/MM/yyyy") + " to " + tourGroup.EndDate?.ToString("dd/MM/yyyy");
                
                // tour info
                var tourBLL = new TourBLL();
                var tour = await tourBLL.GetTourbyID(tourGroup.TourId);
                item.LbTourName.Content = tour.Name;
                item.LbTourId.Content = "ID: " + tour.Id;
                item.LbPrice.Content = tour.Price;
                
                WpListConfirm.Children.Add(item);
            }
            
            _countTotal = listRequest.Count;
            LbTotalQuantity.Content = _countTotal;
            LbTodayQuantity.Content = _countToday;
        }

        private void WpListConfirm_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is ConfirmControl)
            {
                var item = e.Source as ConfirmControl;
                
                if(item == null) return;
                
                if (item.LbRequestDate.Content.ToString() == "Today")
                {
                    _countToday--;
                    LbTodayQuantity.Content = _countToday;
                }
                
                _countTotal--;
                LbTotalQuantity.Content = _countTotal;
                
                WpListConfirm.Children.Remove(item);
            }
        }
    }
}