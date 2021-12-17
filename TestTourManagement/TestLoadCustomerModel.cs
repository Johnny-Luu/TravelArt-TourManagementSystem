using System.Threading.Tasks;
using BLL;
using DTO;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestLoadCustomerModels
    {
        [TestCase("0","Leo Messi",true)]
        [TestCase("1","Leo Messi",false)]
        [TestCase("999","Leo Messi",false)]
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