using System.Threading.Tasks;
using BLL;
using DTO;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestLoadTourGroup
    {
    
        public async Task TestLoadDestinationModel(string tourgroupID,string name,bool result)
        {
            var tourgroupBlL = new TourGroupBLL();
            TourGroupModel tourgroup = await tourgroupBlL.GetTourGroupById(tourgroupID);
            if (tourgroup == null)
            {
                Assert.AreEqual(false, result);
            }
            else
            if(result)
            {
                Assert.AreEqual(name, tourgroup.Name);
                Assert.AreEqual(tourgroupID, tourgroup.Id);
            }
        }
    }
}