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
using GUI.Components;
using GUI.Views.Pages;
using Models;
using Image = System.Drawing.Image;

namespace GUI.ViewModels
{
    public class TourViewModel : BaseViewModel
    {
        // use for binding data
        // public List<TourModel> TourList { get; set; }
        public PageTour PgTour { get; set; }
        public ICommand LoadTourCommand { get; set; }

        public TourViewModel()
        {
            // TourList = new List<TourModel>();
            LoadTourCommand = new RelayCommand<PageTour>(para => true, para => LoadTour(para));
        }

        public async void LoadTour(PageTour para)
        {
            PgTour = para;

            var tourBlL = new TourBLL();
            var tourList = await tourBlL.GetAllTour();
            foreach (var tour in tourList)
            {
                TourControl item = new TourControl();
                item.tourID = tour.Id;
                item.LbName.Content = tour.Name;
                item.TbDescription.Text = tour.Description;
                item.LbPrice.Content = tour.Price + " vnd";
                item.LbVisit.Content = "Visit: " + (tour.DestinationIds.Length /2 + 1) + " locations";
                item.LbRating.Content = tour.Rating;

                // convert img from base64 to bitmap
                // and add to item's image
                var bytes = Convert.FromBase64String(tour.Img);
                var ms = new MemoryStream();
                ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

                var image = new Bitmap(ms, false);
                ms.Dispose();

                var a = image.GetHbitmap();
                var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                item.BorderImg.Background = new ImageBrush(b);

                PgTour.WpTour.Children.Add(item);
            }
        }
    }
}