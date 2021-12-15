using System.Threading.Tasks;
using BLL;
using DTO;
using Models;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestLoadDestinations
    {
        [TestCase("1","Xuan Huong Lake",true)]
        [TestCase("1","Da Lat",false)]
        [TestCase("99","Da Lat",false)]
        [TestCase(" "," ",false)]
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