using FunctionLibrary;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestAddingDestinations
    {
        [TestCase("","test description","An Giang","0",true,false)]
        [TestCase("test name","","An Giang","0",true,false)]
        [TestCase("test name","test description","","0",true,false)]
        [TestCase("test name","test description","An Giang","",true,false)]
        [TestCase("test name","test description","An Giang","0",false,false)]
        [TestCase("test long name aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa","test description","An Giang","0","true",false)]
        [TestCase("test name","test","An Giang","0",true,false)]
       
        
        public void TestAddingDestination(string name, string description, string province,string idHotel,bool picture,bool result)
        {
          
            Assert.AreEqual(result, AddingDestination.isAddAble(name,description,province,idHotel,picture));
            

        }
    }
}