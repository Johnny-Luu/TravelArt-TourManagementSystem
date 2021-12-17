using FunctionLibrary;
using NUnit.Framework;

namespace TestTourManagement
{
    public class TestRatingChartRatio
    {

        [TestCase(-1,6,3,6,3,false,0,0,0,0,0)]
        [TestCase(3,-1,3,6,3,false,0,0,0,0,0)]
        [TestCase(3,6,-1,6,3,false,0,0,0,0,0)]
        [TestCase(3,6,3,-1,3,false,0,0,0,0,0)]
        [TestCase(3,6,3,6,-1,false,0,0,0,0,0)]
        [TestCase(0,0,0,0,0,false,0,0,0,0,0)]
        [TestCase(0,0,6,0,0,true,0,0,1,0,0)]
        [TestCase(6,3,6,3,6,true,1,0.5,1,0.5,1)]
        


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