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
            const string input = @"4 3
1 2 1
2 3 1
3 4 10
2
3 4 1
1 4 1
";
            const string output = @"10
8
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 16
8 7 38
2 8 142
5 2 722
8 6 779
4 6 820
1 3 316
1 7 417
8 3 41
1 4 801
3 2 126
4 2 71
8 4 738
4 3 336
7 5 717
5 6 316
2 1 501
10
6 1 950
6 1 493
1 6 308
3 4 298
2 5 518
1 5 402
4 7 625
7 6 124
3 8 166
2 4 708
";
            const string output = @"13649
12878
11954
11954
11280
11058
11058
8099
8099
8099
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}