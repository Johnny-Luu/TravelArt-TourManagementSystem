using System;
using System.Windows;
using System.Windows.Input;
using BLL;
using GUI.Views.Pages;
using Microsoft.Win32;
using Models;

namespace GUI.ViewModels
{
    public class AddingTourViewModel : BaseViewModel
    {
        public PageAddingTour PgAddingTour { get; set; }
        public ICommand PushTourCommand { get; set; }
        
        public AddingTourViewModel()
        {
            PushTourCommand = new RelayCommand<PageAddingTour>(para => true, para => PushTour(para));
        }

        public async void PushTour(PageAddingTour para)
        {
            PgAddingTour = para;
            
            var tourBLL = new TourBLL();

            var id = await tourBLL.InitID();
            var name = PgAddingTour.TbName.Text;
            var price = PgAddingTour.TbPrice.Text;
            var shortDescription = PgAddingTour.TbShortDescription.Text;
            
            var ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png";
            
            if (ofd.ShowDialog() == true)
            {
                var file = ofd.FileName;
                var bytes = System.IO.File.ReadAllBytes(file);
                var base64 = Convert.ToBase64String(bytes);
            
                var tour = new TourModel
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Description = shortDescription,
                    Img = base64,
                    CurrentComment = 0,
                    CurrentTour = 0,
                    Rating = 0,
                    Status = 1
                };
                
                tourBLL.PushTour(tour);
            }
        }
    }
}