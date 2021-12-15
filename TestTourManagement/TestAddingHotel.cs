using FunctionLibrary;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestAddingHotels
    {

        [TestCase("","1200","12A NVH","09890000","An Giang",false)]
        [TestCase("Tour 1","0","12A NVH","09890000","An Giang",false)]
        [TestCase("Tour 1","10000","A","09890000","An Giang",false)]
        [TestCase("Tour 1","A","A","09890000","An Giang",false)]
        [TestCase("A","10000","12A NVH","081 012 012","An Giang",true)]
        [TestCase("Tour Name","9999999999999","12A NVH","081 012 012","An Giang",false)]
        
        public void TestAddingHotel(string name, string price, string address, string phone ,string province,bool result)
        {
          
            Assert.AreEqual(result, AddingHotel.isAddAble(name,price,address,phone,province));
            

        }
    }
}