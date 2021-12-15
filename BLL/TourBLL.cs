using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class TourBLL
    {
        private TourDAL _tourDAL;
        
        public Task<List<TourModel>> GetAllTour()
        {
            _tourDAL = new TourDAL();
            return _tourDAL.GetAllTour();
        }
        public Task<TourModel> GetTourbyID(string id)
        {
            _tourDAL = new TourDAL();
            return _tourDAL.GetTourbyID(id);
        }

        public Task<bool> ExistReference(string id)
        {
            _tourDAL = new TourDAL();
            return _tourDAL.ExistReference(id);
        }

        public void DeleteTour(string id)
        {
            _tourDAL = new TourDAL();
            _tourDAL.DeleteTour(id);
        }

        public void PushTour(TourModel tour)
        {
            _tourDAL = new TourDAL();
            _tourDAL.PushTour(tour);
        }

        public Task<string> InitID()
        {
            _tourDAL = new TourDAL();
            return _tourDAL.InitID();
        }
    }
}