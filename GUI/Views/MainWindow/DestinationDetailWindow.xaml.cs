using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using DTO;

namespace GUI.Views.MainWindow
{
    public partial class DestinationDetailWindow : Window
    {
        public DestinationDetailWindow(string id)
        {
            InitializeComponent();
            LoadData(id);
        }

        private async void LoadData(string id)
        {
            var destinationBLL = new DestinationBLL();
            var destination = await destinationBLL.GetDestinationbyID(id);
            
            //Lb set title
           
            // destination info
            LbDestinationName.Content = "Name: " + destination.Name;
            LbDestinationProvince.Content = "Province: " + destination.Province;
            TbDescription.Text = "Description: " + destination.Description;
            
            var bytes = Convert.FromBase64String(destination.Img);
            var ms = new MemoryStream();
            ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

            var image = new Bitmap(ms, false);
            ms.Dispose();

            var a = image.GetHbitmap();
            var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ImgDestination.Background = new ImageBrush(b);
            
            // hotel info
            var hotelBLL = new HotelBLL();
            var hotel = await hotelBLL.GetHotelById(destination.IdHotel);
            LbHotelName.Content = "Name: " + hotel.Name;
            LbHotelAddress.Content = "Address: " + hotel.Address;
            LbHotelPhone.Content = "Phone: " + hotel.PhoneNumber;
            LbHotelPrice.Content = "Price: " + hotel.Price;
          
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}