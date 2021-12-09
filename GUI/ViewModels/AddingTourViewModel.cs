using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using DTO;
using GUI.GlobalData;
using GUI.Views.Components;
using GUI.Views.Pages;
using Microsoft.Win32;
using Models;

namespace GUI.ViewModels
{
    public class AddingTourViewModel : BaseViewModel
    {
        private string _base64Img;
        private List<DestinationModel> _destinationList;
        private List<DestinationModel> _destinationChosenList;

        public PageAddingTour PgAddingTour { get; set; }
        public ICommand ChooseImageCommand { get; set; }
        public ICommand PushTourCommand { get; set; }
        public ICommand LoadProvinceCommand { get; set; }
        public ICommand LoadDestinationCommand { get; set; }
        public ICommand DestinationChooseCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public AddingTourViewModel()
        {
            _destinationList = new List<DestinationModel>();
            _destinationChosenList = new List<DestinationModel>();
            
            ChooseImageCommand = new RelayCommand<PageAddingTour>(para => true, para => ChooseImage(para));
            PushTourCommand = new RelayCommand<PageAddingTour>(para => true, para => PushTour(para));
            LoadProvinceCommand = new RelayCommand<PageAddingTour>(para => true, para => LoadProvince(para));
            LoadDestinationCommand = new RelayCommand<PageAddingTour>(para => true, para => LoadDestinationList(para));
            DestinationChooseCommand = new RelayCommand<PageAddingTour>(para => true, para => DestinationChosen(para));
            ClearCommand = new RelayCommand<PageAddingTour>(para => true, para => ClearDestinationChosenList(para));
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
                _base64Img = Convert.ToBase64String(bytes);
            }
        }

        public async void PushTour(PageAddingTour para)
        {
            PgAddingTour = para;

            var tourBLL = new TourBLL();

            var id = await tourBLL.InitID();
            var name = PgAddingTour.TbName.Text;
            var price = PgAddingTour.TbPrice.Text;
            var shortDescription = PgAddingTour.TbShortDescription.Text;
            
            // check tour info has filled or not
            if(name == "" || price == "" || shortDescription == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            
            // check destination chosen list has item or not
            if(_destinationChosenList.Count == 0)
            {
                MessageBox.Show("Please choose destination");
                return;
            }
            
            // check tour img has chosen or not
            if (_base64Img == null)
            {
                MessageBox.Show("Please choose a picture");
                return;
            }

            var destinationIds = GetDestinationChosenListId();
            
            var tour = new TourModel
            {
                Id = id,
                Name = name,
                Price = price,
                Description = shortDescription,
                Img = _base64Img,
                Status = 1,
                DestinationIds = destinationIds
            };
                
            tourBLL.PushTour(tour);
            MessageBox.Show("Successfully added");
        }
        
        public void DestinationChosen(PageAddingTour para)
        {
            PgAddingTour = para;

            // get id of chosen destination
            var idDestination = "";
            if (PgAddingTour.CbDestinationPlanning.SelectedValue != null)
            {
                var destinationChosen = PgAddingTour.CbDestinationPlanning.SelectedValue.ToString();
                idDestination = destinationChosen.Split('-')[0];
            }

            // find destination in destinationList by id
            foreach (var destination in _destinationList)
            {
                if(destination.Id == idDestination)
                {
                    _destinationChosenList.Add(destination);
                    LoadDestinationChooseIntoContainer();
                    break;
                }
            }
        }

        public void ClearDestinationChosenList(PageAddingTour para)
        {
            PgAddingTour = para;
            
            _destinationChosenList.Clear();
            PgAddingTour.WpDestinationChoose.Children.Clear();
        }
        
        public void LoadProvince(PageAddingTour para)
        {
            PgAddingTour = para;
            
            foreach (var province in ProvinceData.ProvinceList)
            {
                PgAddingTour.CbProvince.Items.Add(province);
            }
        }

        private async void LoadDestinationList(PageAddingTour para)
        {
            PgAddingTour = para;
            
            PgAddingTour.CbDestinationPlanning.Items.Clear();
            var provinceChosen = PgAddingTour.CbProvince.SelectedValue.ToString();

            var destinationBLL = new DestinationBLL();
            _destinationList = await destinationBLL.GetDestinationByProvince(provinceChosen);
            
            // Load destination list to combobox
            foreach (var destination in _destinationList)
            {
                PgAddingTour.CbDestinationPlanning.Items.Add(destination.Id + "-" + destination.Name);
            }
        }

        private void LoadDestinationChooseIntoContainer()
        {
            PgAddingTour.WpDestinationChoose.Children.Clear();
            
            for (var i = 0; i < _destinationChosenList.Count; i++)
            {
                var item = new DestinationChooseItem();
                item.TbDestinationName.Text = _destinationChosenList[i].Name;
                item.LbDay.Content = "Day " + (i + 1);
                
                // convert img from base64 to bitmap
                // and add to item's image
                var bytes = Convert.FromBase64String(_destinationChosenList[i].Img);
                var ms = new MemoryStream();
                ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

                var image = new Bitmap(ms, false);
                ms.Dispose();

                var a = image.GetHbitmap();
                var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                item.BorderImg.Background = new ImageBrush(b);
                
                PgAddingTour.WpDestinationChoose.Children.Add(item);
            }
        }
        
        // Store all id of destination into database
        // with a string format: "id1,id2,id3,..."
        private string GetDestinationChosenListId()
        {
            var id = "";
            foreach (var destination in _destinationChosenList)
            {
                id += destination.Id + ",";
            }

            // remove last ","
            id = id.TrimEnd(',');
            return id;
        }
        
    }
}