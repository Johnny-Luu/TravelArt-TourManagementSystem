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

        public Task<TourGroupModel> GetTourGroupById(string id)
        {
            _tourGroupDAL = new TourGroupDAL();
            return _tourGroupDAL.GetTourGroupById(id);
        }

        public Task<List<TourGroupModel>> GetTourGroupByCustomerId(string id)
        {
            _tourGroupDAL = new TourGroupDAL();
            return _tourGroupDAL.GetTourGroupByCustomerId(id);
        }

        public Task<List<TourGroupModel>> GetTourGroupByTourId(string id)
        {
            _tourGroupDAL = new TourGroupDAL();
            return _tourGroupDAL.GetTourGroupByTourId(id);
        }

        public Task<bool> RemoveTourismFromList(string tourGroupId, string customerId)
        {
            _tourGroupDAL = new TourGroupDAL();
            return _tourGroupDAL.RemoveTourismFromList(tourGroupId, customerId);
        }
        
        public Task<bool> AddTourismToList(string tourGroupId, string customerId)
        {
            _tourGroupDAL = new TourGroupDAL();
            return _tourGroupDAL.AddTourismToList(tourGroupId, customerId);
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