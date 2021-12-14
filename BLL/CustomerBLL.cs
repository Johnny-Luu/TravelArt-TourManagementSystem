using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class CustomerBLL
    {
        private CustomerDAL _customerDAL;

        public async Task<List<CustomerModel>> GetAllCustomer()
        {
            _customerDAL = new CustomerDAL();
            return await _customerDAL.GetAllCustomer();
        }
        
        public Task<CustomerModel> GetCustomerByID(string id)
        {
            _customerDAL = new CustomerDAL();
            return _customerDAL.GetCustomerByID(id);
        }
    }
}