using System.Windows.Input;
using GUI.Views.MainWindow;

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
            WdTourDetail.tourID="0";
            WdTourDetail.TxtDecription.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        }
      
    
    }
}