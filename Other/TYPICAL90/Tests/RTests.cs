using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-7;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
2 1 1
4
0
1
2
3
";
            const string output = @"0.000000000000
24.094842552111
54.735610317245
45.000000000000
";
            Tester.InOutTest(Tasks.R.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5121
312000000 4123 3314
6
123
12
445
4114
42
1233
";
            const string output = @"4.322765775902
0.421184234768
15.640867693969
35.396039162484
1.475665637902
43.338582976959
";
            Tester.InOutTest(Tasks.R.Solve, input, output, RelativeError);
        }
    }
}
