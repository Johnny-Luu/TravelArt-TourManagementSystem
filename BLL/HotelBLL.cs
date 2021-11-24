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

        public Task<string> InitID()
        {
            _hotelDAL = new HotelDAL();
            return _hotelDAL.InitID();
        }
    }
}