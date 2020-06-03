using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"aabbaa";
            var output = @"4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"aaaccacabaababc";
            var output = @"12";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        // [TestMethod]
        // public void TestMethod3()
        // {
        //     var input = @"";
        //     var output = @"";
        //     Tester.InOutTest(() => Program.Solve(), input, output);
        // }
    }
}