using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using DTO;
using GUI.Components;
using GUI.Views.Components;
using GUI.Views.Pages;
using Models;
using Image = System.Drawing.Image;

namespace GUI.ViewModels
{
    public class TourViewModel : BaseViewModel
    {
        private List<DestinationModel> destinationlist;

        private List<TourModel> tourList;
        // use for binding data
        // public List<TourModel> TourList { get; set; }
        public PageTour PgTour { get; set; }
        public ICommand LoadTourCommand { get; set; }
        public ICommand LoadDestinationCommand { get; set; }
        public ICommand SetTourCommand { get; set; }
        public ICommand SetDestinationCommand { get; set; }

        public TourViewModel()
        {
            // TourList = new List<TourModel>();
            LoadTourCommand = new RelayCommand<PageTour>(para => true, para => LoadTour(para));
            LoadDestinationCommand = new RelayCommand<PageTour>(para => true, para => LoadDesination(para));
            SetTourCommand = new RelayCommand<PageTour>(para => true, para => SetTour(para));
            SetDestinationCommand = new RelayCommand<PageTour>(para => true, para => SetDestination(para));
        }

        public async void LoadTour(PageTour para)
        {
            PgTour = para;
       
            PgTour.WpTour.Children.Clear();
            var tourBlL = new TourBLL();
            tourList = await tourBlL.GetAllTour();

            SetTour(para);
        }
        
        public async void LoadDesination(PageTour para)
        {
            
            PgTour = para;
            PgTour.WpTour.Children.Clear();
            var destinationBlL = new DestinationBLL();
             destinationlist = await destinationBlL.GetAllDestination();
             
            SetDestination(para);
            
        }

        public async void SetTour(PageTour para)
        {
            PgTour.WpTour.Children.Clear();
            foreach (var tour in tourList)
            {
                TourControl item = new TourControl();
                item.tourID = tour.Id;
                item.LbName.Content = tour.Name;
                item.TbDescription.Text = tour.Description;
                item.LbPrice.Content = tour.Price + " vnd";
                item.LbVisit.Content = "Visit: " + (tour.DestinationIds.Length /2 + 1) + " locations";
                
                ////////////////////
                //Cai nay phai tinh lai
                // chu ko luu trong db
                ///////////////
                
                // item.LbRating.Content = tour.Rating;
                // item.StarInit(tour.Rating);
                
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
        
        public async void SetDestination(PageTour para)
        {
            PgTour.WpTour.Children.Clear();
            foreach (var destination in destinationlist)
            {
                DestinationControl item = new DestinationControl();
                item.LbName.Content = destination.Name;
                item.TbDescription.Text = destination.Description;
                item.Margin = new Thickness(20);
              
                // convert img from base64 to bitmap
                // and add to item's image
                var bytes = Convert.FromBase64String(destination.Img);
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