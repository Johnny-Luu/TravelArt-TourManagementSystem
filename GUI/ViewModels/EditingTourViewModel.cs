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
using FunctionLibrary;
using GUI.GlobalData;
using GUI.Views.Components;
using GUI.Views.MainWindow;
using GUI.Views.Pages;
using Microsoft.Win32;
using Models;

namespace GUI.ViewModels
{
    public class EditingTourViewModel : BaseViewModel
    {
        public TourModel tour;
        private string _base64Img;
        private List<DestinationModel> _destinationList;
        private List<DestinationModel> _destinationChosenList;

        public EditingTourWindow EditingTourWd { get; set; }
        public ICommand ChooseImageCommand { get; set; }
        public ICommand PushTourCommand { get; set; }
        public ICommand LoadProvinceCommand { get; set; }
        public ICommand LoadDestinationCommand { get; set; }
        public ICommand DestinationChooseCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand LoadTourCommand { get; set; }
        
        public EditingTourViewModel()
        {
            _destinationList = new List<DestinationModel>();
            _destinationChosenList = new List<DestinationModel>();
            
            ChooseImageCommand = new RelayCommand<EditingTourWindow>(para => true, para => ChooseImage(para));
            PushTourCommand = new RelayCommand<EditingTourWindow>(para => true, para => PushTour(para));
            LoadProvinceCommand = new RelayCommand<EditingTourWindow>(para => true, para => LoadProvince(para));
            LoadDestinationCommand = new RelayCommand<EditingTourWindow>(para => true, para => LoadDestinationList(para));
            DestinationChooseCommand = new RelayCommand<EditingTourWindow>(para => true, para => DestinationChosen(para));
            ClearCommand = new RelayCommand<EditingTourWindow>(para => true, para => ClearDestinationChosenList(para));
            LoadTourCommand =new RelayCommand<EditingTourWindow>(para => true, para => LoadTourDetail(para));
        }
        public async void LoadTourDetail(EditingTourWindow para)
        {
            _destinationChosenList.Clear();
            EditingTourWd = para;
        
            //WdTourDetail.GridDestination.Background.;
            var tourBlL = new TourBLL();
           
            tour = await tourBlL.GetTourbyID(para.GetTourID());
            //img
            var bytes = Convert.FromBase64String(tour.Img);
            var ms = new MemoryStream();
            ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

            var image = new Bitmap(ms, false);
            ms.Dispose();
            var a = image.GetHbitmap();
            var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ImageBrush ib = new ImageBrush(b);
            ib.Stretch = Stretch.UniformToFill;
            EditingTourWd.ImgPicture.Source = ib.ImageSource;

            _base64Img = tour.Img;
            //info
            EditingTourWd.TbName.Text = tour.Name;
            EditingTourWd.TbPrice.Text = tour.Price;
            EditingTourWd.TbProfit.Text = tour.Profit;
            EditingTourWd.TbShortDescription.Text = tour.Description;
            //destination
            String[] arrayListDesId = tour.DestinationIds.Split(',');
            var destinationBLL = new DestinationBLL();
            for (int i = 0; i < arrayListDesId.Length; i++)
            {
                DestinationModel dm = await destinationBLL.GetDestinationbyID(arrayListDesId[i]);
                _destinationChosenList.Add(dm);
            }

            LoadDestinationChooseIntoContainer();


        }
        public void ChooseImage(EditingTourWindow para)
        {
            EditingTourWd = para;

            var ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png";

            if (ofd.ShowDialog() == true)
            {
                // preview img
                EditingTourWd.ImgPicture.Stretch = Stretch.UniformToFill;
                EditingTourWd.ImgPicture.Source = new BitmapImage(new Uri(ofd.FileName));

                var file = ofd.FileName;
                var bytes = System.IO.File.ReadAllBytes(file);
                _base64Img = Convert.ToBase64String(bytes);
            }
        }

        public async void PushTour(EditingTourWindow para)
        {
           
            EditingTourWd = para;

            var tourBLL = new TourBLL();

            var id = this.tour.Id;
            var name = EditingTourWd.TbName.Text;
            var price = EditingTourWd.TbPrice.Text;
            var profit = EditingTourWd.TbProfit.Text;
            var shortDescription = EditingTourWd.TbShortDescription.Text;
            
            string destinationIds="";
            // check destination chosen list has item or not
            if(_destinationChosenList.Count != 0)
            {
                destinationIds = GetDestinationChosenListId();
            }
            // check tour img has chosen or not
            bool img = _base64Img != null;
            
            if (!AddingTour.isAddAble(name, price, profit, shortDescription, destinationIds, img)) return;

            var tour = new TourModel
            {
                Id = id,
                Name = name,
                Price = price,
                Profit = profit,
                Description = shortDescription,
                Img = _base64Img,
                Status = 1,
                DestinationIds = destinationIds
            };
                
            tourBLL.EditTour(tour);
            MessageBox.Show("Edit Successfully");
        }
        
        public void DestinationChosen(EditingTourWindow para)
        {
            EditingTourWd = para;

            // get id of chosen destination
            var idDestination = "";
            if (EditingTourWd.CbDestinationPlanning.SelectedValue != null)
            {
                var destinationChosen = EditingTourWd.CbDestinationPlanning.SelectedValue.ToString();
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

        public void ClearDestinationChosenList(EditingTourWindow para)
        {
            EditingTourWd = para;
            
            _destinationChosenList.Clear();
            EditingTourWd.WpDestinationChoose.Children.Clear();
        }
        
        public void LoadProvince(EditingTourWindow para)
        {
            EditingTourWd = para;
            
            foreach (var province in ProvinceData.ProvinceList)
            {
                EditingTourWd.CbProvince.Items.Add(province);
            }
        }

        private async void LoadDestinationList(EditingTourWindow para)
        {
            EditingTourWd = para;
            
            EditingTourWd.CbDestinationPlanning.Items.Clear();
            var provinceChosen = EditingTourWd.CbProvince.SelectedValue.ToString();

            var destinationBLL = new DestinationBLL();
            _destinationList = await destinationBLL.GetDestinationByProvince(provinceChosen);
            
            // Load destination list to combobox
            foreach (var destination in _destinationList)
            {
                EditingTourWd.CbDestinationPlanning.Items.Add(destination.Id + "-" + destination.Name);
            }
        }

        private void LoadDestinationChooseIntoContainer()
        {
            EditingTourWd.WpDestinationChoose.Children.Clear();
            
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
                
                EditingTourWd.WpDestinationChoose.Children.Add(item);
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