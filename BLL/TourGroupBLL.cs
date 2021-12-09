using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TourGroupBLL
    {
        private TourGroupDAL _tourGroupDAL;
        
        public Task<List<TourGroupModel>> GetAllTourGroup()
        {
            _tourGroupDAL = new TourGroupDAL();
            return _tourGroupDAL.GetAllTourGroup();
        }
        
        public void PushTourGroup(TourGroupModel tourGroup)
        {
            _tourGroupDAL = new TourGroupDAL();
            _tourGroupDAL.PushTourGroup(tourGroup);
        }
        
        public Task<string> InitID()
        {
            _tourGroupDAL = new TourGroupDAL();
            return _tourGroupDAL.InitID();
        }
    }
}