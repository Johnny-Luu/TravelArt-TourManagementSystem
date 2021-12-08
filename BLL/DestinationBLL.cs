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
        
        public Task<List<DestinationModel>> GetAllDestination()
        {
            _destinationDAL = new DestinationDAL();
            return _destinationDAL.GetAllDestination();
        }
        public Task<DestinationModel> GetDestinationbyID(string id)
        {
            _destinationDAL = new DestinationDAL();
            return _destinationDAL.GetDestinationbyID(id);
        }
        public void PushDestination(DestinationModel destination)
        {
            _destinationDAL = new DestinationDAL();
            _destinationDAL.PushDestination(destination);
        }
        
        public Task<List<DestinationModel>> GetDestinationByProvince(string province)
        {
            _destinationDAL = new DestinationDAL();
            return _destinationDAL.GetDestinationByProvince(province);
        }

        public Task<string> InitID()
        {
            _destinationDAL = new DestinationDAL();
            return _destinationDAL.InitID();
        }
    }
}