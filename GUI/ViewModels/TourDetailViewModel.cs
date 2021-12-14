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
using GUI.Views.Components;
using GUI.Views.Pages;
using Models;

namespace GUI.ViewModels
{
    public class TourDetailViewModel : BaseViewModel
    {
        public TourModel tour;
        public TourDetailWindow WdTourDetail { get; set; }
        public PageTourDetail_Info PgTourDetailInfo { get; set; }
        public PageTourDetail_Rating PgTourDetailRating { get; set; }
        public PageTourDetail_Plan PgTourDetailPlan { get; set; }
        public ICommand LoadTourDetailCommand { get; set; }
        public ICommand LoadTourDetailInfoCommand { get; set; }
        public ICommand LoadRatingCommand { get; set; }
        
        public ICommand LoadPlanCommand { get; set; }
        
        public TourDetailViewModel()
        {
            LoadTourDetailCommand = new RelayCommand<TourDetailWindow>(para => true, para => LoadTourDetail(para));
            LoadTourDetailInfoCommand=new RelayCommand<PageTourDetail_Info>(para => true, para => LoadInfo(para));
            LoadRatingCommand = new RelayCommand<PageTourDetail_Rating>(para => true, para => LoadRating(para));
            LoadPlanCommand = new RelayCommand<PageTourDetail_Plan>(para => true, para => LoadPlan(para));
        }
        public async void LoadTourDetail(TourDetailWindow para)
        {
            WdTourDetail = para;
            //Hide khi load
            WdTourDetail.LbInfo.Visibility = Visibility.Hidden;
            WdTourDetail.LbRating.Visibility = Visibility.Hidden;
            WdTourDetail.LbPlan.Visibility = Visibility.Hidden;
            //WdTourDetail.GridDestination.Background.;
            var tourBlL = new TourBLL();
            tour = await tourBlL.GetTourbyID(WdTourDetail.GetTourID());
            //img
           var bytes = Convert.FromBase64String(tour.Img);
           var ms = new MemoryStream();
           ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

           var image = new Bitmap(ms, false);
           ms.Dispose();

           var a = image.GetHbitmap();
           var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
           WdTourDetail.BorderImg.Background = new ImageBrush(b);
          //show khi load xong
          WdTourDetail.LbInfo.Visibility = Visibility.Visible;
          WdTourDetail.LbRating.Visibility = Visibility.Visible;
          WdTourDetail.LbPlan.Visibility = Visibility.Visible;
          WdTourDetail.FrContainer.Content = new PageTourDetail_Info();
        }
        public  void LoadInfo(PageTourDetail_Info para)
        {
            PgTourDetailInfo = para;
            
            PgTourDetailInfo.LbTourName.Text = tour.Name;
            PgTourDetailInfo.TbDescription.Text = tour.Description;
            PgTourDetailInfo.Set_LbPrice(2000000); //(tour.Price);
            PgTourDetailInfo.Set_LbVisit(tour.DestinationIds.Split(',').Length.ToString());
            PgTourDetailInfo.Set_LbDuration(tour.DestinationIds.Split(',').Length,(tour.DestinationIds.Split(',').Length-1));
            //Chua co Tour Group
            //PgTourDetailInfo.Set_LbAvailable();
        }
        public  void LoadRating(PageTourDetail_Rating para)
        {
            int[] rate = new int[6];
            PgTourDetailRating = para;
          
            
            //Init Comment
            foreach (var rating in tour.RatingList)
            {
                CommentComponent cmt = new CommentComponent();
                
                // haven't init user yet, so display id instead
                // will be replaced by user name later
                cmt.LbName.Content = rating.CustomerId;
                cmt.LbDate.Content = rating.Time;
                cmt.score = rating.Rating;
                cmt.TbComment.Text = rating.Comment;
                cmt.InitStar();
                
                PgTourDetailRating.InitCommentPanel(cmt);
                if (cmt.score <= 5 && cmt.score >= 1) rate[cmt.score]++;
            }

            //InitChart
            PgTourDetailRating.InitChartFrame(rate[1],rate[2],rate[3],rate[4],rate[5]);
        }
        public async void LoadPlan(PageTourDetail_Plan para)
        {

            
            PgTourDetailPlan = para;
            //des
            PgTourDetailPlan.LbTourName.Text = tour.Name;
            PgTourDetailPlan.WpContaner.Children.Clear();
            int daycount = 0;
            var destinationBlL = new DestinationBLL();

            string ListDesID = tour.DestinationIds;
            String[] arrayListDesId = ListDesID.Split(',');
            for(int i=0;i<arrayListDesId.Length;i++)
            {
                
                string desID = arrayListDesId[i];
                DestinationControl desCtrl = new DestinationControl();
                var des = await destinationBlL.GetDestinationbyID(desID);
                daycount++;
                desCtrl.LbId.Content = des.Id;
                desCtrl.TbDescription.Text = des.Description;
                desCtrl.LbName.Content = des.Name;
                var bytes = Convert.FromBase64String(des.Img);
                var ms = new MemoryStream();
                ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));
                var image = new Bitmap(ms, false);
                ms.Dispose();
                var a = image.GetHbitmap();
                var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                desCtrl.BorderImg.Background = new ImageBrush(b);
                PgTourDetailPlan.InitDes(desCtrl, daycount);
            }

        }

    
    }
}