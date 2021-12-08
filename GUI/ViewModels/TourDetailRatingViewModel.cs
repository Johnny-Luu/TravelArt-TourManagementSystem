using System.Windows.Input;
using GUI.Views.Components;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class TourDetailRatingViewModel : BaseViewModel
    {
        public PageTourDetail_Rating PgTourDetailRating { get; set; }
        public ICommand LoadRatingCommand { get; set; }

        public TourDetailRatingViewModel()
        {
            LoadRatingCommand = new RelayCommand<PageTourDetail_Rating>(para => true, para => LoadRating(para));
        }

        public async void LoadRating(PageTourDetail_Rating para)
        {
            int[] rate = new int[6];
            PgTourDetailRating = para;
            //id cua tour de tim trong db
            string tourId = PgTourDetailRating.GetTourID();
            
            //Init Comment
            //foreach (var comment in tour)
            {
                
                CommentComponent cmt = new CommentComponent();
                //cmt.ImgAvatar=
                
                cmt.LbName.Content = "Ten";
                cmt.LbDate.Content = "18/08/2001";
                cmt.score = 5;
                cmt.TbComment.Text ="Luu Ngoc Sang Luu Ngoc Sang Ton Nu Ngoc Sang Luu Ngoc Sang Luu Ngoc Sang Ton Nu Ngoc Sang Luu Ngoc Sang Luu Ngoc Sang Ton Nu Ngoc Sang Luu Ngoc Sang Luu Ngoc Sang Ton Nu Ngoc Sang Luu Ngoc Sang Luu Ngoc Sang Ton Nu Ngoc Sang Luu Ngoc Sang Luu Ngoc Sang Ton Nu Ngoc Sang Luu Ngoc Sang Luu Ngoc Sang Ton Nu Ngoc Sang";
                //
                PgTourDetailRating.InitCommentPanel(cmt);
                if (cmt.score is <= 5 and >= 1) rate[cmt.score]++;
            }

            //InitChart
            PgTourDetailRating.InitChartFrame(rate[1],rate[2],rate[3],rate[4],rate[5]);
        }
      
    }
}