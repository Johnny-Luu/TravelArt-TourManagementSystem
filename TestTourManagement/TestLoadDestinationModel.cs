using System.Threading.Tasks;
using BLL;
using DTO;
using Models;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestLoadDestinations
    {
        [TestCase("0","Railway Station",true)]
        [TestCase("1","Railway Station",false)]
        [TestCase("99","Da Lat",false)]
        public async Task TestLoadDestinationModel(string desID,string name,bool result)
        {
            var desBlL = new DestinationBLL();
            DestinationModel des = await desBlL.GetDestinationbyID(desID);
            if (des == null)
            {
                Assert.AreEqual(false, result);
            }
            else
            if(result)
            {
                Assert.AreEqual(name, des.Name);
                Assert.AreEqual(desID, des.Id);
            }
        }
    }
}