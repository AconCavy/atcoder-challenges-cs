using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
0 0 0
0 0 0
0 0 0
1 1 0
1 1 0
0 0 0
";
            const string output = @"Yes
1
";
            Tester.InOutTest(Tasks.CA.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
0 0 0
0 0 0
0 0 0
0 0 0
0 1 0
0 0 0
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.CA.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 5
6 17 18 29 22
39 50 25 39 25
34 34 8 25 17
28 48 25 47 42
27 47 24 32 28
4 6 3 29 28
48 50 21 48 29
44 44 19 47 28
4 49 46 29 28
4 49 45 1 1
";
            const string output = @"Yes
140
";
            Tester.InOutTest(Tasks.CA.Solve, input, output);
        }
    }
}
