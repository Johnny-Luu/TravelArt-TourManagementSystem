using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using FunctionLibrary;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestDeleteTour
    {
        [TestCase("0",true)]
        [TestCase("999",false)]
        public async Task TestisDeteleAble_Tour(string id,bool result)
        {
            TourBLL tourBLL = new TourBLL();
            var check = await tourBLL.ExistReference(id);
            Assert.AreEqual(result,check);
        }
    }
}