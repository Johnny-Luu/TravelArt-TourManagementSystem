using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using GUI.Views.Pages;
using Microsoft.Win32;
using Models;

namespace GUI.ViewModels
{
    public class AddingTourViewModel : BaseViewModel
    {
        private string _base64img = null;

        public PageAddingTour PgAddingTour { get; set; }
        public ICommand ChooseImageCommand { get; set; }
        public ICommand PushTourCommand { get; set; }

        public AddingTourViewModel()
        {
            ChooseImageCommand = new RelayCommand<PageAddingTour>(para => true, para => ChooseImage(para));
            PushTourCommand = new RelayCommand<PageAddingTour>(para => true, para => PushTour(para));
        }

        public void ChooseImage(PageAddingTour para)
        {
            PgAddingTour = para;

            var ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png";

            if (ofd.ShowDialog() == true)
            {
                // preview img
                PgAddingTour.ImgPicture.Stretch = Stretch.UniformToFill;
                PgAddingTour.ImgPicture.Source = new BitmapImage(new Uri(ofd.FileName));

                var file = ofd.FileName;
                var bytes = System.IO.File.ReadAllBytes(file);
                _base64img = Convert.ToBase64String(bytes);
            }
        }

        public async void PushTour(PageAddingTour para)
        {
            PgAddingTour = para;

            if (_base64img == null)
            {
                MessageBox.Show("Please choose a picture");
                return;
            }
            
            var tourBLL = new TourBLL();

            var id = await tourBLL.InitID();
            var name = PgAddingTour.TbName.Text;
            var price = PgAddingTour.TbPrice.Text;
            var shortDescription = PgAddingTour.TbShortDescription.Text;
            
            var tour = new TourModel
            {
                Id = id,
                Name = name,
                Price = price,
                Description = shortDescription,
                Img = _base64img,
                CurrentComment = 0,
                CurrentTour = 0,
                Rating = 0,
                Status = 1
            };
                
            tourBLL.PushTour(tour);
            MessageBox.Show("Successfully added");
        }

    }
}