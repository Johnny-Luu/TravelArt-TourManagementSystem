using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class CustomerBLL
    {
        private CustomerDAL _customerDAL;
        
        public Task<CustomerModel> GetCustomerByID(string id)
        {
            _customerDAL = new CustomerDAL();
            return _customerDAL.GetCustomerByID(id);
        }
    }
}