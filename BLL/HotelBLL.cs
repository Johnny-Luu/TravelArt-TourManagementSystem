using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class HotelBLL
    {
        private HotelDAL _hotelDAL;
        
        public Task<List<HotelModel>> GetAllHotel()
        {
            _hotelDAL = new HotelDAL();
            return _hotelDAL.GetAllHotel();
        }
        
        public void PushHotel(HotelModel hotel)
        {
            _hotelDAL = new HotelDAL();
            _hotelDAL.PushHotel(hotel);
        }

        public Task<List<HotelModel>> GetHotelByProvince(string province)
        {
            _hotelDAL = new HotelDAL();
            return _hotelDAL.GetHotelByProvince(province);
        }

        public Task<string> InitID()
        {
            _hotelDAL = new HotelDAL();
            return _hotelDAL.InitID();
        }
    }
}