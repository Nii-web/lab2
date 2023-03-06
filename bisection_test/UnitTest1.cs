using System.Drawing;
using static System.Collections.Specialized.BitVector32;

namespace bisection_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            int[] arr = { -7, 6, 5,0,-1 };
            int expected = 3;
            int test_result = 0;

            Binary.binaryMedian(arr,arr.Length,ref test_result);

            Assert.AreEqual(expected,test_result);              
        }
    }
}