using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BLL;
using GUI.Components;
using GUI.Views.Pages;
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

        public async void LoadTour(PageTour para)
        {
            PgTour = para;

            var tourBlL = new TourBLL();
            var tourList = await tourBlL.GetAllTour();
            foreach (var tour in tourList)
            {
                TourControl item = new TourControl();
                item.LbName.Content = tour.Name;
                item.TbDescription.Text = tour.Description;
                item.LbComment.Content = tour.CurrentComment + "comments";
                item.LbCurTour.Content = tour.CurrentTour + "current tours";
                item.LbRating.Content = tour.Rating;
                PgTour.WpTour.Children.Add(item);
            }

            // use for binding data
            // TourList.Add(tourModel);
            // TourList.Add(tourModel2);
        }
    }
}