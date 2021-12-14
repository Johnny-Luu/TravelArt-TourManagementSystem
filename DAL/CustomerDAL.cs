using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using FireSharp;

namespace DAL
{
    public class CustomerDAL
    {
        private DbUtils _db;
        private FirebaseClient _client;
        
        public async Task<List<CustomerModel>> GetAllCustomer()
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);
            
            var result = await _client.GetAsync("Customer");
            var data = result.ResultAs<List<CustomerModel>>();

            return data;
        }
        
        public async Task<CustomerModel> GetCustomerByID(string id)
        {
            _db = new DbUtils();
            var config = _db.CreateConnection();
            _client = new FirebaseClient(config);

            var result = await _client.GetAsync("Customer/" + id);
            var data = result.ResultAs<CustomerModel>();
            return data;
        }
        
        public async Task<bool> CheckDuplicate(CustomerModel customer)
        {
            var customerList = await GetAllCustomer();
            var result = false;
            
            if (customerList != null)
            {
                if (customerList.Any(item => item.Name == customer.Name))
                {
                    result = true;
                }
            }
            
            return result;
        }
    }
}