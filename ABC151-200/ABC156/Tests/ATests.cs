using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 2919";
            var output = @"3719";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"22 3051";
            var output = @"3051";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
