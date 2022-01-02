using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
            var customerBLL = new CustomerBLL();
            var tourGroupBLL = new TourGroupBLL();
            var tourBLL = new TourBLL();

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
                
                // customer info
                var customer = await customerBLL.GetCustomerByID(request.CustomerId);
                item.LbCustomerName.Content = customer.Name;
                
                var bytes = Convert.FromBase64String(customer.Avatar);
                var ms = new MemoryStream();
                ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

                var image = new Bitmap(ms, false);
                ms.Dispose();

                var a = image.GetHbitmap();
                var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImageBrush ib = new ImageBrush(b);
                ib.Stretch = Stretch.UniformToFill;
                item.ImgAvatar.Fill = ib;
                
                // tour group info
                var tourGroup = await tourGroupBLL.GetTourGroupById(request.TourGroupId);
                item.LbTourGroupId.Content = tourGroup.Id;
                item.LbTourGroupName.Content = tourGroup.Name;
                item.LbTourGroupDate.Content = tourGroup.StartDate?.ToString("dd/MM/yyyy") + " to " + tourGroup.EndDate?.ToString("dd/MM/yyyy");
                
                // tour info
                var tour = await tourBLL.GetTourbyID(tourGroup.TourId);
                item.LbTourName.Content = tour.Name;
                item.LbTourId.Content = "ID: " + tour.Id;
                long money = 0;
                long.TryParse(tour.Price,out money);
                item.LbPrice.Content = String.Format("{0:0,0}", money) ;
             
                
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