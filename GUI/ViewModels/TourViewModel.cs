using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
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
using Brushes = System.Windows.Media.Brushes;
using Image = System.Drawing.Image;

namespace GUI.ViewModels
{
    public class TourViewModel : BaseViewModel
    {
        private int currentTab = 0;
        private List<TourModel> tourList;
        private List<DestinationModel> destinationlist;
        private List<CustomerModel> customerlist;

        // use for binding data
        // public List<TourModel> TourList { get; set; }
        public PageTour PgTour { get; set; }
        public ICommand LoadTourCommand { get; set; }
        public ICommand LoadDestinationCommand { get; set; }
        public ICommand LoadCustomerCommand { get; set; }
        public ICommand SetTourCommand { get; set; }
        public ICommand SetDestinationCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public TourViewModel()
        {
            // TourList = new List<TourModel>();
            LoadTourCommand = new RelayCommand<PageTour>(para => true, para => LoadTour(para));
            LoadDestinationCommand = new RelayCommand<PageTour>(para => true, para => LoadDesination(para));
            LoadCustomerCommand = new RelayCommand<PageTour>(para => true, para => LoadCustomer(para));
            SearchCommand = new RelayCommand<PageTour>(para => true, para => Search(para));
        }

    
        private void Search(PageTour para)
        {
            PgTour = para;
            
            var keyword = PgTour.TbSearch.Text;
            switch (currentTab)
            {
                case 0:
                    SearchTour(keyword);
                    break;
                case 1:
                    SearchDestination(keyword);
                    break;
                case 2:
                    SearchCustomer(keyword);
                    break;
            }
        }

        private void SearchTour(string keyword)
        {
            var searchList = tourList.Where(tour => tour.Id.Contains(keyword) || tour.Name.Contains(keyword)).ToList();
            if(searchList.Count == 0)
            {
                MessageBox.Show("Not found!");
            }
            else
            {
                PgTour.WpTour.Children.Clear();
                SetTour(searchList);
            }
        }
        
        private void SearchDestination(string keyword)
        {
            var searchList = destinationlist.Where(destination => destination.Id.Contains(keyword) || destination.Name.Contains(keyword)).ToList();
            if(searchList.Count == 0)
            {
                MessageBox.Show("Not found!");
            }
            else
            {
                PgTour.WpTour.Children.Clear();
                SetDestination(searchList);
            }
        }
        
        private void SearchCustomer(string keyword)
        {
            var searchList = customerlist.Where(customer => customer.Id.Contains(keyword) || customer.Name.Contains(keyword)).ToList();
            if(searchList.Count == 0)
            {
                MessageBox.Show("Not found!");
            }
            else
            {
                PgTour.WpTour.Children.Clear();
                SetCustomer(searchList);
            }
        }

        public async void LoadTour(PageTour para)
        {
            PgTour = para;            
            currentTab = 0;
            
            var converter = new ImageSourceConverter();
            PgTour.WpTour.Background =new ImageBrush(((ImageSource)converter.ConvertFromString( "pack://application:,,,/Assets/images/loading2.png")));
            PgTour.WpTour.Children.Clear();
            var tourBlL = new TourBLL();
            tourList = await tourBlL.GetAllTour();

            SetTour(tourList);
        }
        
        public async void LoadDesination(PageTour para)
        {
            PgTour = para;
            currentTab = 1;
            
            var converter = new ImageSourceConverter();
            PgTour.WpTour.Background =new ImageBrush(((ImageSource)converter.ConvertFromString( "pack://application:,,,/Assets/images/loading2.png")));
            PgTour.WpTour.Children.Clear();
            var destinationBlL = new DestinationBLL();
             destinationlist = await destinationBlL.GetAllDestination();
             
            SetDestination(destinationlist);
            
        }
        
        private async void LoadCustomer(PageTour para)
        {
            PgTour = para;
            currentTab = 2;
            
            var converter = new ImageSourceConverter();
            PgTour.WpTour.Background =new ImageBrush(((ImageSource)converter.ConvertFromString( "pack://application:,,,/Assets/images/loading2.png")));
            PgTour.WpTour.Children.Clear();
          
            var customerBlL = new CustomerBLL();
            customerlist = await customerBlL.GetAllCustomer();
            SetCustomer(customerlist);
        }

        private void SetCustomer(List<CustomerModel> list)
        {
            PgTour.WpTour.Children.Clear();
            foreach (var customer in list)
            {
                var item = new CustomerItem();
                item.LbId.Content = "Id: " + customer.Id;
                item.TbCustomerName.Text = customer.Name;
                item.TbCustomerEmail.Text = customer.Email;
                item.Margin = new Thickness(25);
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
                    item.ImgAvt.Background = ib;
                }
                
                PgTour.WpTour.Children.Add(item);
            }
            PgTour.WpTour.Background = Brushes.Transparent;
        }

        public  void SetTour(List<TourModel> list)
        {
            currentTab = 0;
            PgTour.WpTour.Children.Clear();
            foreach (var tour in list)
            {
                TourControl item = new TourControl();
                item.tourID = tour.Id;
                item.LbName.Content = tour.Name;
                item.TbDescription.Text = tour.Description;
                item.LbPrice.Content = tour.Price + " vnd";
                item.LbVisit.Content = "Visit: " + (tour.DestinationIds.Length /2 + 1) + " locations";
                
                // calculate rating point
                double ratingPoint = 0;
                if (tour.RatingList.Count > 0) 
                foreach (var rating in tour.RatingList)
                {
                    ratingPoint += rating.Rating;
                }

                if (tour.RatingList.Count > 0)
                {
                    ratingPoint = ratingPoint * 1.0 / tour.RatingList.Count;
                }

                item.LbRating.Content = ratingPoint.ToString("0.0");
                item.StarInit(ratingPoint);
                
                // convert img from base64 to bitmap
                // and add to item's image
                var bytes = Convert.FromBase64String(tour.Img);
                var ms = new MemoryStream();
                ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

                var image = new Bitmap(ms, false);
                ms.Dispose();

                var a = image.GetHbitmap();
                var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImageBrush ib = new ImageBrush(b);
                ib.Stretch = Stretch.UniformToFill;
                item.BorderImg.Background = ib;

                PgTour.WpTour.Children.Add(item);
            }

            PgTour.WpTour.Background = Brushes.Transparent;
        }
        
        public  void SetDestination(List<DestinationModel> list)
        {
            currentTab = 1;
            PgTour.WpTour.Children.Clear();
            foreach (var destination in list)
            {
                DestinationControl item = new DestinationControl();
                item.LbId.Content = destination.Id;
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
                ImageBrush ib = new ImageBrush(b);
                ib.Stretch = Stretch.UniformToFill;
                item.BorderImg.Background = ib;

                PgTour.WpTour.Children.Add(item);
               
            }
            PgTour.WpTour.Background = Brushes.Transparent;
        }
    }
}