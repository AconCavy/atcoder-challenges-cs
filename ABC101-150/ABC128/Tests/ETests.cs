using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 6
1 3 2
7 13 10
18 20 13
3 4 2
0
1
2
3
5
8";
            const string output = @"2
2
10
-1
13
-1";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
