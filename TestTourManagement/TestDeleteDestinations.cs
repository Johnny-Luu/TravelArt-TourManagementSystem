using System.Threading.Tasks;
using BLL;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestDeleteDestination
    {
      [TestCase("0",true)]
      [TestCase("999",false)]
            public async Task TestisDeteleAble_Destination(string id,bool result)
            {
                DestinationBLL desBLL = new DestinationBLL();
                var check = await desBLL.ExistReference(id);
                Assert.AreEqual(result,check);
            }
        
    
    }
}