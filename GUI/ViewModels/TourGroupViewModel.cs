using System.Windows.Input;
using BLL;
using GUI.Views.Components;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class TourGroupViewModel : BaseViewModel
    {
        public PageTour_GroupTourList PageTourGroup { get; set; }
        
        public ICommand LoadTourGroupCommand { get; set; }
        
        public TourGroupViewModel()
        {
            LoadTourGroupCommand = new RelayCommand<PageTour_GroupTourList>(para => true, para => LoadTourGroup(para));
        }

        public async void LoadTourGroup(PageTour_GroupTourList para)
        {
            PageTourGroup = para;
            
            var tourGroupBLL = new TourGroupBLL();
            var tourGroupList = await tourGroupBLL.GetAllTourGroup();
            foreach (var tourGroup in tourGroupList)
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
                item.LbPassenger.Content = (tourGroup.CustomerList.Length/2 + 1) + "/" + tourGroup.Slot;
                PageTourGroup.WpTourGroupList.Children.Add(item);
            }
        }
    }
}