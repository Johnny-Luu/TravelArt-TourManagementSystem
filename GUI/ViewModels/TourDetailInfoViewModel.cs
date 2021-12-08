using System.Windows.Input;
using BLL;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class TourDetailInfoViewModel
    {
        public PageTourDetail_Info PgTourDetailInfo { get; set; }
        public ICommand LoadTourDetailInfoCommand { get; set; }

        public TourDetailInfoViewModel()
        {
            LoadTourDetailInfoCommand =
                new RelayCommand<PageTourDetail_Info>(para => true, para => LoadTourDetailInfo(para));
        }

        public async void LoadTourDetailInfo(PageTourDetail_Info para)
        {
            PgTourDetailInfo = para;
            var tourBlL = new TourBLL();
            var tour = await tourBlL.GetTourbyID(PgTourDetailInfo.GetTourID());
            PgTourDetailInfo.LbTourName.Text = tour.Name;
            PgTourDetailInfo.TbDescription.Text = tour.Description;
            PgTourDetailInfo.Set_LbPrice(2000000); //(tour.Price);
            PgTourDetailInfo.Set_LbVisit(tour.DestinationIds.Split(',').Length.ToString());
            PgTourDetailInfo.Set_LbDuration(tour.DestinationIds.Split(',').Length,(tour.DestinationIds.Split(',').Length-1));
            //Chua co Tour Group
            //PgTourDetailInfo.Set_LbAvailable();
        }
    }
}
