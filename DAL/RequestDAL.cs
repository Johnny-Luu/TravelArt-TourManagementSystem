using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using FireSharp;

namespace DAL
{
    public class RequestDAL
    {
        private DbUtils _db;
        private FirebaseClient _client;
        
        public async Task<List<RequestModel>> GetAllRequest()
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.GetAsync("Request");
            var data = result.ResultAs<List<RequestModel>>();
            return data;
        }
        
        public async Task<bool> DeleteRequest(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.DeleteAsync("Request/" + id);
            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }
        
    }
}