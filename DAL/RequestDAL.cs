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
            var list = result.ResultAs<List<RequestModel>>();
            
            if(list == null)
            {
                return new List<RequestModel>();
            }

            // find all request with id != -1
            var data = list.FindAll(x => x.Id != "-1");
            return data;
        }
        
        public async Task<bool> DeleteRequest(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            // set id = -1 to delete
            var result = await _client.UpdateAsync("Request/" + id, new { Id = "-1" });
            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }
        
    }
}