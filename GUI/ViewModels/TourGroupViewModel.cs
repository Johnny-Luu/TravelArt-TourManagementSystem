using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using DTO;
using GUI.Views.Components;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class TourGroupViewModel : BaseViewModel
    {
        private List<TourGroupModel> _tourGroupList = new List<TourGroupModel>();
        private readonly DateTime _today = DateTime.Now.Date;

        public PageTour_GroupTourList PageTourGroup { get; set; }
        
        public ICommand LoadTourGroupCommand { get; set; }
        public ICommand LoadAllTourGroupCommand { get; set; }
        public ICommand OnTripFilterCommand { get; set; }
        public ICommand PlanningFilterCommand { get; set; }
        public ICommand OverFilterCommand { get; set; }
        
        public TourGroupViewModel()
        {
            LoadTourGroupCommand = new RelayCommand<PageTour_GroupTourList>(para => true, para => LoadTourGroup(para));
            LoadAllTourGroupCommand = new RelayCommand<PageTour_GroupTourList>(para => true, para => LoadAllTourGroup(para));
            OnTripFilterCommand = new RelayCommand<PageTour_GroupTourList>(para => true, para => FilterOnTrip(para));
            PlanningFilterCommand = new RelayCommand<PageTour_GroupTourList>(para => true, para => FilterPlanning(para));
            OverFilterCommand = new RelayCommand<PageTour_GroupTourList>(para => true, para => FilterOver(para));
        }

        public async void LoadTourGroup(PageTour_GroupTourList para)
        {
            PageTourGroup = para;
            
            var tourGroupBLL = new TourGroupBLL();
            _tourGroupList = await tourGroupBLL.GetAllTourGroup();
            LoadAllTourGroup(para);
        }
        
        private void LoadAllTourGroup(PageTour_GroupTourList para)
        {
            PageTourGroup = para;
            
            PageTourGroup.WpTourGroupList.Children.Clear();
            foreach (var tourGroup in _tourGroupList)
            {
                LoadTourGroupItemToList(tourGroup);
            }
        }
        
        private void FilterOnTrip(PageTour_GroupTourList para)
        {
            PageTourGroup = para;
            
            PageTourGroup.WpTourGroupList.Children.Clear();
            foreach (var tourGroup in _tourGroupList)
            {
                if (tourGroup.StartDate <= _today && tourGroup.EndDate >= _today)
                    LoadTourGroupItemToList(tourGroup);
            }
        }
        
        private void FilterPlanning(PageTour_GroupTourList para)
        {
            PageTourGroup = para;
            
            PageTourGroup.WpTourGroupList.Children.Clear();
            foreach (var tourGroup in _tourGroupList)
            {
                if (tourGroup.StartDate > _today)
                    LoadTourGroupItemToList(tourGroup);
            }
        }
        
        private void FilterOver(PageTour_GroupTourList para)
        {
            PageTourGroup = para;
            
            PageTourGroup.WpTourGroupList.Children.Clear();
            foreach (var tourGroup in _tourGroupList)
            {
                if (tourGroup.EndDate < _today)
                    LoadTourGroupItemToList(tourGroup);
            }
        }

        private async void LoadTourGroupItemToList(TourGroupModel tourGroup)
        {
            var item = new TourGuildItem();
                item.LbTourGroupID.Content = "id: " + tourGroup.Id;
                item.LbTourGroupName.Content = tourGroup.Name;
                item.LbTourID.Content = "id: " + tourGroup.TourId;
                item.LbTourName.Content = tourGroup.TourName;
                item.LbGuideID.Content = "id: " + tourGroup.TourLeaderId;
                item.LbGuideName.Content = tourGroup.TourLeaderName;
                item.LbDeputyID.Content = "id: " + tourGroup.TourDeputyId;
                item.LbDeputyName.Content = tourGroup.TourDeputyName;
                item.LbTimesStart.Content = tourGroup.StartDate?.ToString("dd/MM/yyyy");
                item.LbTimeEnd.Content = tourGroup.EndDate?.ToString("dd/MM/yyyy");
                
                // load tour img
                var tourBLL = new TourBLL();
                var tour = await tourBLL.GetTourbyID(tourGroup.TourId);
                
                var bytes = Convert.FromBase64String(tour.Img);
                var ms = new MemoryStream();
                ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

                var image = new Bitmap(ms, false);
                ms.Dispose();

                var a = image.GetHbitmap();
                var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                ImageBrush ib = new ImageBrush(b);
                ib.Stretch = Stretch.UniformToFill;

                item.ImgTour.Fill = ib;

                // display status
                if (tourGroup.EndDate < _today)
                {
                    item.LbStatus.Content = "• over";
                    item.LbStatus.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                }
                else if (tourGroup.StartDate <= _today && tourGroup.EndDate >= _today)
                {
                    item.LbStatus.Content = "• on trip";
                    item.LbStatus.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 255, 0));
                }
                else
                {
                    item.LbStatus.Content = "• planning";
                    item.LbStatus.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 255));
                }
                
                // display current quantity of tourism
                if (!string.IsNullOrEmpty(tourGroup.CustomerList))
                {
                    item.LbPassenger.Content = (tourGroup.CustomerList.Length/2 + 1) + "/" + tourGroup.Slot;
                }
                else
                {
                    item.LbPassenger.Content = "0/" + tourGroup.Slot;
                }
                
                PageTourGroup.WpTourGroupList.Children.Add(item);
        }
    }
}