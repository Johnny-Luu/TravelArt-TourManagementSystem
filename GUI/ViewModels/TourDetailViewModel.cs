using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GUI.Views.MainWindow;
using BLL;
namespace GUI.ViewModels
{
    public class TourDetailViewModel : BaseViewModel
    {
        public TourDetailWindow WdTourDetail { get; set; }
        public ICommand LoadTourDetailCommand { get; set; }
        public TourDetailViewModel()
        {
            LoadTourDetailCommand = new RelayCommand<TourDetailWindow>(para => true, para => LoadTourDetail(para));
        }
        public async void LoadTourDetail(TourDetailWindow para)
        {
            WdTourDetail = para;
            //WdTourDetail.GridDestination.Background.;
            var tourBlL = new TourBLL();
           var tour = await tourBlL.GetTourbyID(WdTourDetail.GetTourID());
           //img
           var bytes = Convert.FromBase64String(tour.Img);
           var ms = new MemoryStream();
           ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

           var image = new Bitmap(ms, false);
           ms.Dispose();

           var a = image.GetHbitmap();
           var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
           WdTourDetail.GridDestination.Background = new ImageBrush(b);
          
        }
      
    
    }
}