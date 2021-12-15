using System.Threading.Tasks;
using BLL;
using FunctionLibrary;
using Models;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestLoadTourModels
    {
       
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