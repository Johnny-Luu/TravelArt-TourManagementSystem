using FunctionLibrary;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestStar
    {
   
        [TestCase(-3,-1,0,0,0,0,0,false)]
        [TestCase(0,0,0,0,0,0,0,false)]
        [TestCase(0.1,0,0,0,0,0,0,true)]
        [TestCase(0.9,1,1,0,0,0,0,true)]
        [TestCase(1,2,2,0,0,0,0,true)]
        [TestCase(1.6,3,2,1,0,0,0,true)]
        [TestCase(2.2,4,2,2,0,0,0,true)]
        [TestCase(2.51,5,2,2,1,0,0,true)]
        [TestCase(3.123,6,2,2,2,0,0,true)]
        [TestCase(3.999,7,2,2,2,1,0,true)]
        [TestCase(4.001,8,2,2,2,2,0,true)]
        [TestCase(4.6,9,2,2,2,2,1,true)]
        [TestCase(5,10,2,2,2,2,2,true)]
        [TestCase(6.9,-1,0,0,0,0,0,false)]
        
        
        public void TestStarSetUp(double score, int resultNumStar,int star1,int star2, int star3, int star4, int star5,bool result)
        {
            var numstar = StarSetUp.ScoreToStar(score);
            Assert.AreEqual(resultNumStar, numstar,"Failed StarSetUp: Function ScoreToStar()") ;
            
            StarSetUp.SetUpStar(numstar,out int s1,out int s2,out int s3,out int s4,out int s5);
            Assert.AreEqual(star1, s1,"Failed StarSetUp: star1 value");
            Assert.AreEqual(star2, s2,"Failed StarSetUp: star2 value");
            Assert.AreEqual(star3, s3,"Failed StarSetUp: star3 value");
            Assert.AreEqual(star4, s4,"Failed StarSetUp: star4 value");
           Assert.AreEqual(star5, s5,"Failed StarSetUp: star5 value ");
        }
    }
}