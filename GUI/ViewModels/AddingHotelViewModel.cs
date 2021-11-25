using System.Windows;
using System.Windows.Input;
using BLL;
using DTO;
using GUI.Views.Pages;

namespace GUI.ViewModels
{
    public class AddingHotelViewModel
    {
        public PageAddingHotel PgAddingHotel { get; set; }
        public ICommand PushHotelCommand { get; set; }
        
        public AddingHotelViewModel()
        {
            PushHotelCommand = new RelayCommand<PageAddingHotel>(para => true, para => PushHotel(para));
        }

        public async void PushHotel(PageAddingHotel para)
        {
            PgAddingHotel = para;
            
            var name = PgAddingHotel.TbName.Text;
            var price = PgAddingHotel.TbPrice.Text;
            var address = PgAddingHotel.TbAddress.Text;
            var phone = PgAddingHotel.TbPhone.Text;
            
            if(name == "" || price == "" || address == "" || phone == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            
            var hotelBLL = new HotelBLL();
            var id = await hotelBLL.InitID();
            
            var hotel = new HotelModel
            {
                Id = id,
                Name = name,
                Price = price,
                Address = address,
                PhoneNumber = phone
            };
            
            hotelBLL.PushHotel(hotel);
            MessageBox.Show("Successfully added");
        }
    }
}