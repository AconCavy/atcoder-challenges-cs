using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = ab[0] - 1;
            if (ab[1] >= ab[0]) answer++;
            Console.WriteLine(answer);
        }
    }
}
