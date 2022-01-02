using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using DTO;
using GUI.Views.Components;

namespace GUI.Views.MainWindow
{
    public partial class ProfileWindow : Window
    {
        // private CustomerBLL customerBLL = new CustomerBLL();
        // private TourGroupBLL tourGroupBLL = new TourGroupBLL();
        // private TourBLL tourBLL = new TourBLL();
        // private CustomerModel customer = new CustomerModel();
        // private List<TourGroupModel> tourGroupList = new TourGroupModel();
        
        private int totalRevenue = 0;
        private DateTime today = DateTime.Now.Date;
        
        public ProfileWindow(string id)
        {
            InitializeComponent();
            LoadData(id);
        }

        private async void LoadData(string id)
        {
            // customer info
            var customerBLL = new CustomerBLL();
            var customer = await customerBLL.GetCustomerByID(id);
            if(customer != null)
            {
                LbId.Content = "ID: " + customer.Name;
                LbName.Text = "Name: " + customer.Name;
                TbEmail.Text = "Email: " + customer.Email;
                LbPhone.Content = "Phone: " + customer.Phone;
                
                if (!string.IsNullOrEmpty(customer.Avatar))
                {
                    // convert img from base64 to bitmap
                    // and add to item's image
                    var bytes = Convert.FromBase64String(customer.Avatar);
                    var ms = new MemoryStream();
                    ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

                    var image = new Bitmap(ms, false);
                    ms.Dispose();

                    var a = image.GetHbitmap();
                    var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    ImageBrush ib = new ImageBrush(b);
                    ib.Stretch = Stretch.UniformToFill;
                    ImgAvatarCustomer.Fill = ib;
                }
            }
            
            // tour group info
            var tourBLL = new TourBLL();
            var tourGroupBLL = new TourGroupBLL();
            var tourGroupList = await tourGroupBLL.GetTourGroupByCustomerId(id);
            foreach (var tourGroup in tourGroupList)
            {
                var tour = await tourBLL.GetTourbyID(tourGroup.TourId);
                totalRevenue += int.Parse(tour.Price);
                
                var item = new ProfileListItem();
                item.LbTourGroupId.Content = tourGroup.Id;
                item.LbNameTour.Content = tour.Name;
                item.LbNameTourGroup.Content = tourGroup.Name;
                item.LbDateStartEnd.Content = tourGroup.StartDate?.ToString("dd/MM/yyyy") + " to " + tourGroup.EndDate?.ToString("dd/MM/yyyy");
               
                long money = 0;
                long.TryParse(tour.Price,out money);
                item.LbPrice.Content = String.Format("{0:0,0}", money) ;
                // tour img
                var bytes = Convert.FromBase64String(tour.Img);
                var ms = new MemoryStream();
                ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

                var image = new Bitmap(ms, false);
                ms.Dispose();

                var a = image.GetHbitmap();
                var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImageBrush ib = new ImageBrush(b);
                ib.Stretch = Stretch.UniformToFill;
                item.ImageTour.Fill =  ib;
                
                // status
                if (tourGroup.EndDate < today)
                {
                    item.LbStatus.Content = "• over";
                    item.LbStatus.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                }
                else if (tourGroup.StartDate <= today && tourGroup.EndDate >= today)
                {
                    item.LbStatus.Content = "• on trip";
                    item.LbStatus.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
                }
                else
                {
                    item.LbStatus.Content = "• planning";
                    item.LbStatus.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 255));
                }
                
                WpTourJoined.Children.Add(item);
            }
            
            LbTotalTourGroup.Content = tourGroupList.Count;
            string moneyString = String.Format("{0:0,0}", totalRevenue);
            LbTotalRevenue.Content = moneyString;
        }

        private void BtnBack_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}