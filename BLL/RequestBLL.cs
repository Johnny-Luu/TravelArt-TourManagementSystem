using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class RequestBLL
    {
        private RequestDAL _requestDAL;
        
        public Task<List<RequestModel>> GetAllRequest()
        {
            _requestDAL = new RequestDAL();
            return _requestDAL.GetAllRequest();
        }

        public Task<bool> DeleteRequest(string id)
        {
            _requestDAL = new RequestDAL();
            return _requestDAL.DeleteRequest(id);
        }
    }
}