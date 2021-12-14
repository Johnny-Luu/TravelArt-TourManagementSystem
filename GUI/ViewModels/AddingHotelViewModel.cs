using System.Windows;
using System.Windows.Input;
using BLL;
using DTO;
using FunctionLibrary;
using GUI.GlobalData;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class AddingHotelViewModel
    {
        public PageAddingHotel PgAddingHotel { get; set; }
        public ICommand PushHotelCommand { get; set; }
        public ICommand LoadProvinceCommand { get; set; }
        
        public AddingHotelViewModel()
        {
            PushHotelCommand = new RelayCommand<PageAddingHotel>(para => true, para => PushHotel(para));
            LoadProvinceCommand = new RelayCommand<PageAddingHotel>(para => true, para => LoadProvince(para));
        }

        public void LoadProvince(PageAddingHotel para)
        {
            PgAddingHotel = para;
            
            foreach (var province in ProvinceData.ProvinceList)
            {
                PgAddingHotel.CbProvince.Items.Add(province);
            }
        }

        public async void PushHotel(PageAddingHotel para)
        {
            PgAddingHotel = para;
            
            var name = PgAddingHotel.TbName.Text;
            var price = PgAddingHotel.TbPrice.Text;
            var address = PgAddingHotel.TbAddress.Text;
            var province = PgAddingHotel.CbProvince.Text;
            var phone = PgAddingHotel.TbPhone.Text;


            if (!AddingHotel.isAddAble(name, price, address, phone, province)) return;
            
            
            var hotelBLL = new HotelBLL();
            var id = await hotelBLL.InitID();
            
            var hotel = new HotelModel
            {
                Id = id,
                Name = name,
                Price = price,
                Address = address,
                Province = province,
                PhoneNumber = phone
            };
            
            hotelBLL.PushHotel(hotel);
            MessageBox.Show("Successfully added");
        }
    }
}