using System.Threading.Tasks;
using DTO;
using FireSharp;

namespace DAL
{
    public class CustomerDAL
    {
        private DbUtils _db;
        private FirebaseClient _client;
        
        public async Task<CustomerModel> GetCustomerByID(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);

            var result = await _client.GetAsync("Customer/" + id);
            var data = result.ResultAs<CustomerModel>();
            return data;
        }
    }
}