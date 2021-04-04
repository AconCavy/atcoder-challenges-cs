using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var C = new long[N - 1];
            for (var i = 0; i < N - 1; i++)
            {
                C[i] = Scanner.Scan<long>();
            }

            var cumL = new long[N];
            var cumR = new long[N];
            for (var i = 0; i < N - 1; i++) cumL[i + 1] = cumL[i] + C[i];
            for (var i = N - 2; i >= 0; i--) cumR[i] = cumR[i + 1] + C[i];

            const long inf = (long)1e18;
            var min = inf;
            var maxL = new long[N];
            var maxR = new long[N];
            for (var i = 0; i < N; i++)
            {
                min = Math.Min(min, cumL[i]);
                maxL[i] = cumL[i] - min;
            }

            min = inf;
            for (var i = N - 1; i >= 0; i--)
            {
                min = Math.Min(min, cumR[i]);
                maxR[i] = cumR[i] - min;
            }

            for (var i = 0; i < N; i++)
            {
                Console.WriteLine(Math.Max(maxL[i], maxR[i]));
            }
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
