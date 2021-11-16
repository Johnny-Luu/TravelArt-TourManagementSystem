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
        
        public void PushTour(TourModel tour)
        {
            _tourDAL = new TourDAL();
            _tourDAL.PushTour(tour);
        }
    }
}