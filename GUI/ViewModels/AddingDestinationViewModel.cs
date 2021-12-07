using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLL;
using DTO;
using GUI.GlobalData;
using GUI.Views.Pages;
using Microsoft.Win32;

namespace GUI.ViewModels
{
    public class AddingDestinationViewModel : BaseViewModel
    {
        private string _base64img = null;
        
        public PageAddingDestination PgAddingDestination { get; set; }
        public ICommand PushDestinationCommand { get; set; }
        public ICommand LoadProvinceCommand { get; set; }
        public ICommand LoadHotelCommand { get; set; }
        public ICommand ChooseImageCommand { get; set; }
        
        public AddingDestinationViewModel()
        {
            PushDestinationCommand = new RelayCommand<PageAddingDestination>(para => true, para => PushDestination(para));
            LoadProvinceCommand = new RelayCommand<PageAddingDestination>(para => true, para => LoadProvince(para));
            LoadHotelCommand = new RelayCommand<PageAddingDestination>(para => true, para => LoadHotel(para));
            ChooseImageCommand = new RelayCommand<PageAddingDestination>(para => true, para => ChooseImage(para));
        }

        public async void PushDestination(PageAddingDestination para)
        {
            PgAddingDestination = para;
            
            var name = PgAddingDestination.TbName.Text;
            var description = PgAddingDestination.TbDescription.Text;
            var province = PgAddingDestination.CbProvinceList.Text;
            var idHotel = "";
            
            if (PgAddingDestination.CbHotelList.SelectedValue != null)
            {
                var hotelChoose = PgAddingDestination.CbHotelList.SelectedValue.ToString();
                idHotel = hotelChoose.Split('-')[0];
            }
            
            if(name == "" || description == "" || province == "" || idHotel == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (_base64img == null)
            {
                MessageBox.Show("Please choose a picture");
                return;
            }

            var destinationBLL = new DestinationBLL();
            var id = await destinationBLL.InitID();
            
            var destination = new DestinationModel
            {
                Id = id,
                Name = name,
                Description = description,
                IdHotel = idHotel,
                Province = province,
                Img = _base64img
            };
            
            destinationBLL.PushDestination(destination);
            MessageBox.Show("Successfully added");
        }

        public void LoadProvince(PageAddingDestination para)
        {
            PgAddingDestination = para;
            
            foreach (var province in ProvinceData.ProvinceList)
            {
                PgAddingDestination.CbProvinceList.Items.Add(province);
            }
        }
        
        public async void LoadHotel(PageAddingDestination para)
        {
            PgAddingDestination = para;
            PgAddingDestination.CbHotelList.Items.Clear();
            var provinceChosen = PgAddingDestination.CbProvinceList.SelectedValue.ToString();
            
            var hotelBLL = new HotelBLL();
            var hotelList = await hotelBLL.GetHotelByProvince(provinceChosen);
            
            foreach (var hotel in hotelList)
            {
                PgAddingDestination.CbHotelList.Items.Add(hotel.Id + "-" + hotel.Name);
            }
        }
        
        public void ChooseImage(PageAddingDestination para)
        {
            PgAddingDestination = para;

            var ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                         "Portable Network Graphic (*.png)|*.png";

            if (ofd.ShowDialog() == true)
            {
                // preview img
                PgAddingDestination.ImgPicture.Stretch = Stretch.UniformToFill;
                PgAddingDestination.ImgPicture.Source = new BitmapImage(new Uri(ofd.FileName));

                var file = ofd.FileName;
                var bytes = System.IO.File.ReadAllBytes(file);
                _base64img = Convert.ToBase64String(bytes);
            }
        }
    }
}