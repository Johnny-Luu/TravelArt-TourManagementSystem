using System.Threading.Tasks;
using BLL;
using DTO;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestLoadCustomerModels
    {
        public async Task TestLoadDestinationModel(string customerID,string name,bool result)
        {
            var customerBlL = new CustomerBLL();
            CustomerModel customer = await customerBlL.GetCustomerByID(customerID);
            if (customer == null)
            {
                Assert.AreEqual(false, result);
            }
            else
            if(result)
            {
                Assert.AreEqual(name, customer.Name);
                Assert.AreEqual(customerID, customer.Id);
            }
        }
    }
}