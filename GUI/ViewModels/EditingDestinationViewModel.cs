using System;
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
using GUI.Views.MainWindow;
using GUI.Views.Pages;
using Microsoft.Win32;

namespace GUI.ViewModels
{
    public class EditingDestinationViewModel: BaseViewModel
    {
        public DestinationModel des;
        private string _base64Img;
      public EditingDestinationWindow EditingDestinationWd { get; set; }
        public ICommand PushDestinationCommand { get; set; }
        public ICommand LoadProvinceCommand { get; set; }
        public ICommand LoadHotelCommand { get; set; }
        public ICommand ChooseImageCommand { get; set; }
        public ICommand LoadDestinationCommand { get; set; }

        public EditingDestinationViewModel()
        {
            PushDestinationCommand = new RelayCommand<EditingDestinationWindow>(para => true, para => PushDestination(para));
            LoadProvinceCommand = new RelayCommand<EditingDestinationWindow>(para => true, para => LoadProvince(para));
            LoadHotelCommand = new RelayCommand<EditingDestinationWindow>(para => true, para => LoadHotel(para));
            ChooseImageCommand = new RelayCommand<EditingDestinationWindow>(para => true, para => ChooseImage(para));
            LoadDestinationCommand    = new RelayCommand<EditingDestinationWindow>(para => true, para => LoadDes(para));
        }

        private async void LoadDes(EditingDestinationWindow para)
        {
            EditingDestinationWd = para;
            var desBLL = new DestinationBLL();
            //EditingTourWindow.GetDesID()
            des = await desBLL.GetDestinationbyID("3");
            //img
            var bytes = Convert.FromBase64String(des.Img);
            var ms = new MemoryStream();
            ms.Write(bytes, 0, Convert.ToInt32(bytes.Length));

            var image = new Bitmap(ms, false);
            ms.Dispose();
            var a = image.GetHbitmap();
            var b = Imaging.CreateBitmapSourceFromHBitmap(a, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ImageBrush ib = new ImageBrush(b);
            ib.Stretch = Stretch.UniformToFill;
            EditingDestinationWd.ImgPicture.Source = ib.ImageSource;
            //data
            EditingDestinationWd.TbName.Text = des.Name;
            EditingDestinationWd.TbDescription.Text = des.Description;
            //hotel
            var hotel = new HotelModel();
            var hotelBLL = new HotelBLL();
            hotel = await hotelBLL.GetHotelById(des.IdHotel);
            EditingDestinationWd.CbProvinceList.SelectedValue = hotel.Province;
            //LoadHotel(para);
            EditingDestinationWd.CbHotelList.SelectedValue = hotel.Id + "-" + hotel.Name;
        }
        public async void PushDestination(EditingDestinationWindow para)
        {
            EditingDestinationWd = para;
            
            var name = EditingDestinationWd.TbName.Text;
            var description = EditingDestinationWd.TbDescription.Text;
            var province = EditingDestinationWd.CbProvinceList.Text;
            var idHotel = "";
            var picture = false;
            if (EditingDestinationWd.CbHotelList.SelectedValue != null)
            {
                var hotelChoose = EditingDestinationWd.CbHotelList.SelectedValue.ToString();
                idHotel = hotelChoose.Split('-')[0];
            }
            if (_base64Img == null)
            {
                picture = false;
            }
            else
            {
                picture = true;
            }

            if (!AddingDestination.isAddAble(name, description, province, idHotel, picture)) return;

            var destinationBLL = new DestinationBLL();
            var id = await destinationBLL.InitID();
            
            var destination = new DestinationModel
            {
                Id = id,
                Name = name,
                Description = description,
                IdHotel = idHotel,
                Province = province,
                Img = _base64Img
            };
            //// update here
            destinationBLL.PushDestination(destination);
            //////////
            MessageBox.Show("Edit Successfully");
            
        }

        public void LoadProvince(EditingDestinationWindow para)
        {
            EditingDestinationWd = para;
            
            foreach (var province in ProvinceData.ProvinceList)
            {
                EditingDestinationWd.CbProvinceList.Items.Add(province);
            } 
        }
        
        public async void LoadHotel(EditingDestinationWindow para)
        {
            EditingDestinationWd = para;
            EditingDestinationWd.CbHotelList.Items.Clear();
            var provinceChosen = EditingDestinationWd.CbProvinceList.SelectedValue.ToString();
            
            var hotelBLL = new HotelBLL();
            var hotelList = await hotelBLL.GetHotelByProvince(provinceChosen);
            
            foreach (var hotel in hotelList)
            {
                EditingDestinationWd.CbHotelList.Items.Add(hotel.Id + "-" + hotel.Name);
            }
        }
        
        public void ChooseImage(EditingDestinationWindow para)
        {
            EditingDestinationWd = para;

            var ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png";

            if (ofd.ShowDialog() == true)
            {
                // preview img
                EditingDestinationWd.ImgPicture.Stretch = Stretch.UniformToFill;
                EditingDestinationWd.ImgPicture.Source = new BitmapImage(new Uri(ofd.FileName));

                var file = ofd.FileName;
                var bytes = System.IO.File.ReadAllBytes(file);
                _base64Img = Convert.ToBase64String(bytes);
            }
        }
    }
}
