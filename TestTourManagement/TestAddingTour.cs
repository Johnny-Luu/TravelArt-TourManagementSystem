using FunctionLibrary;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestAddingTours
    {
        [TestCase("","1200","1000","test description","1,2,3",true,false)]
        [TestCase("test Tour","","1000","test description","1,2,3",true,false)]
        [TestCase("test Tour","1200","","test description","1,2,3",true,false)]
        [TestCase("test Tour","1200","1000","","1,2,3",true,false)]
        [TestCase("test Tour","1200","1000","test description","",true,false)]
        [TestCase("test Tour","1200","1000","test description","1,2,3",false,false)]
        [TestCase("test Tour","0","1000","test description","1,2,3",true,false)]
        [TestCase("test Tour","12000","500","test description","1,2,3",true,false)]
        [TestCase("test Tour","5000","6000","test description","1,2,3",true,false)]
        [TestCase("test Tour","9999999999999","1000","test description","1,2,3",true,false)]
        [TestCase("test Tour","9999999999999","99999999999999","test description","1,2,3",true,false)]
        [TestCase("test Tour","1200","1000","test","1,2,3",true,false)]
        [TestCase("test Tour","1200","1000","test description","1,2,3",true,true)]
        public void TestAddingTour(string name, string price,string profit,string shortDescription,string deslist,bool img,bool result)
        {
          
            Assert.AreEqual(result, AddingTour.isAddAble(name,price,profit,shortDescription,deslist,img));
        }
    }
}