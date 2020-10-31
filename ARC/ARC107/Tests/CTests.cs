using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 13
3 2 7
4 8 9
1 6 5";
            const string output = @"12";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10 165
82 94 21 65 28 22 61 80 81 79
93 35 59 85 96 1 78 72 43 5
12 15 97 49 69 53 18 73 6 58
60 14 23 19 44 99 64 17 29 67
24 39 56 92 88 7 48 75 36 91
74 16 26 10 40 63 45 76 86 3
9 66 42 84 38 51 25 2 33 41
87 54 57 62 47 31 68 11 83 8
46 27 55 70 52 98 20 77 89 34
32 71 30 50 90 4 37 95 13 100";
            const string output = @"348179577";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
