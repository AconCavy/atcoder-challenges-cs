using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
2 2 1 3";
            var output = @"7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
1 1 1 1 1 1 1";
            var output = @"6";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
