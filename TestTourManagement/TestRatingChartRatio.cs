using FunctionLibrary;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestRatingChartRatio
    {

        [TestCase(2,-1,1,0,0,false,0,0,0,0,0)]
        [TestCase(0,0,0,0,0,false,0,0,0,0,0)]
        [TestCase(0,0,6,0,0,true,0,0,1,0,0)]
        [TestCase(2,2,1,0,0,true,1,1,0.5,0,0)]
        [TestCase(20,20,20,20,20,true,1,1,1,1,1)]
        [TestCase(1,2,3,4,5,true,1.0/5,2.0/5,3.0/5,4.0/5,1)]
        [TestCase(6,2,1,4,5,true,1,2.0/6,1.0/6,4.0/6,5.0/6)]
        [TestCase(1001,321,672,9,50,true,1,321.0/1001,672.0/1001,9.0/1001,50.0/1001)]



        public void TestChartRatio(int n1, int n2, int n3, int n4, int n5, bool result, double ratio1, double ratio2,
            double ratio3, double ratio4, double ratio5)
        {
            Assert.AreEqual(result,
                RatingChartRatio.Ratio(n1, n2, n3, n4, n5, out double r1, out double r2, out double r3, out double r4,
                    out double r5), "Failed :function result");
            Assert.AreEqual(ratio1, r1,"Failed : ratio 1");
            Assert.AreEqual(ratio2, r2,"Failed : ratio 2");
            Assert.AreEqual(ratio3, r3,"Failed : ratio 3");
            Assert.AreEqual(ratio4, r4,"Failed : ratio 4");
            Assert.AreEqual(ratio5, r5,"Failed : ratio 5");

        }
    }
}