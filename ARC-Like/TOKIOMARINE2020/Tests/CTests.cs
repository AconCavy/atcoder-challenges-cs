using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 1
1 0 0 1 0
";
            const string output = @"1 2 2 1 2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 2
1 0 0 1 0
";
            const string output = @"3 3 4 4 3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
