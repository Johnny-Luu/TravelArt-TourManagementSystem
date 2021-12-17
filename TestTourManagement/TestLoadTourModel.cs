using System.Threading.Tasks;
using BLL;
using FunctionLibrary;
using Models;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestLoadTourModels
    {
        [TestCase("0","DaLat",true)]
        [TestCase("1","DaLat",false)]
        [TestCase("999","DaLat",false)]
        public async Task TestLoadTourModel(string tourID,string name,bool result)
        {
            var tourBlL = new TourBLL();
            TourModel tour = await tourBlL.GetTourbyID(tourID);
            if (tour == null)
            {
                Assert.AreEqual(false, result);
            }
            else
            if(result)
            {
                Assert.AreEqual(name, tour.Name);
                Assert.AreEqual(tourID, tour.Id);
            }
        }
       
    }
}