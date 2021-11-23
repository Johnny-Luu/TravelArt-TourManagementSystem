using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DTO;
using Models;

namespace BLL
{
    public class DestinationBLL
    {
        private DestinationDAL _destinationDAL;
        
        public Task<List<DestinationModel>> GetAllTour()
        {
            _destinationDAL = new DestinationDAL();
            return _destinationDAL.GetAllDestination();
        }
        
        public void PushTour(DestinationModel destination)
        {
            _destinationDAL = new DestinationDAL();
            _destinationDAL.PushDestination(destination);
        }

        public Task<string> InitID()
        {
            _destinationDAL = new DestinationDAL();
            return _destinationDAL.InitID();
        }
    }
}