using System.Collections.Generic;
using System.Windows.Input;
using GUI.Components;
using GUI.Pages;
using Models;

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

        public void LoadTour(PageTour para)
        {
            PgTour = para;

            //Fake data (temporary)
            var tourModel = new TourModel("Vietnam", "this is a description");

            TourControl item1 = new TourControl();
            item1.LbName.Content = tourModel.Name;
            item1.LbDescription.Content = tourModel.Description;
            
            TourControl item2 = new TourControl();
            item2.LbName.Content = tourModel.Name;
            item2.LbDescription.Content = tourModel.Description;
            
            TourControl item3 = new TourControl();
            item3.LbName.Content = tourModel.Name;
            item3.LbDescription.Content = tourModel.Description;
            
            PgTour.WpTour.Children.Add(item1);
            PgTour.WpTour.Children.Add(item2);
            PgTour.WpTour.Children.Add(item3);

            // use for binding data
            // TourList.Add(tourModel);
            // TourList.Add(tourModel2);
        }
    }
}