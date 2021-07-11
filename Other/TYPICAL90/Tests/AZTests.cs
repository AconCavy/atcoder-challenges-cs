using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AZTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
1 2 3 5 7 11
4 6 8 9 10 12
";
            const string output = @"1421
";
            Tester.InOutTest(Tasks.AZ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
11 13 17 19 23 29
";
            const string output = @"112
";
            Tester.InOutTest(Tasks.AZ.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
19 23 51 59 91 99
15 45 56 65 69 94
7 11 16 34 59 95
27 30 40 43 83 85
19 23 25 27 45 99
27 48 52 53 60 81
21 36 49 72 82 84
";
            const string output = @"670838273
";
            Tester.InOutTest(Tasks.AZ.Solve, input, output);
        }
    }
}
