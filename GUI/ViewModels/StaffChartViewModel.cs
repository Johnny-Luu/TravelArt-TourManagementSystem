using System.Windows.Input;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class StaffChartViewModel : BaseViewModel
    {
        public PageStatistic_Staff PgStatisticStaff { get; set; }
        public ICommand LoadChartCommand { get; set; }
        public StaffChartViewModel()
        {
            
            LoadChartCommand = new RelayCommand<PageStatistic_Staff>(para => true, para => LoadStaffChart(para));
        }
        public async void LoadStaffChart(PageStatistic_Staff para)
        {
            PgStatisticStaff = para;

        
           
                

            PgStatisticStaff.LbTotal.Content="loaded";
        }
        }
    }
