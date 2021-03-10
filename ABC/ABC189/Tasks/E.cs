using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Tasks
{
    public class E
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
            var B = new Matrix[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                B[i] = new Matrix(3, 1);
                B[i][0, 0] = x;
                B[i][1, 0] = y;
                B[i][2, 0] = 1;
            }

            var M = Scanner.Scan<int>();
            var ops = new Matrix[M + 1];
            ops[0] = Matrix.One(3);
            for (var i = 0; i < M; i++)
            {
                var op = Scanner.ScanEnumerable<long>().ToArray();
                var mat = Matrix.One(3);
                if (op[0] == 1)
                {
                    mat[0, 0] = mat[1, 1] = 0;
                    mat[0, 1] = 1;
                    mat[1, 0] = -1;
                }
                else if (op[0] == 2)
                {
                    mat[0, 0] = mat[1, 1] = 0;
                    mat[0, 1] = -1;
                    mat[1, 0] = 1;
                }
                else if (op[0] == 3)
                {
                    mat[0, 0] = -1;
                    mat[0, 2] = op[1] * 2;
                }
                else
                {
                    mat[1, 1] = -1;
                    mat[1, 2] = op[1] * 2;
                }

                ops[i + 1] = mat.Multiply(ops[i]);
            }

            var Q = Scanner.Scan<int>();
            while (Q-- > 0)
            {
                var (a, b) = Scanner.Scan<int, int>();
                b--;
                var answer = ops[a].Multiply(B[b]);
                Console.WriteLine($"{answer[0, 0]} {answer[1, 0]}");
            }
        }

        public class Matrix
        {
            public int Height { get; }
            public int Width { get; }
            public long this[int row, int column]
            {
                get => _data[row, column];
                set => _data[row, column] = value;
            }
            private readonly long[,] _data;
            public Matrix(int height, int width)
            {
                Height = height;
                Width = width;
                _data = new long[height, width];
            }
            public static Matrix One(int n)
            {
                var ret = new Matrix(n, n);
                for (var i = 0; i < n; i++) ret[i, i] = 1;
                return ret;
            }
            public Matrix Add(Matrix other) => Add(this, other);
            public static Matrix Add(in Matrix a, in Matrix b)
            {
                if (a.Height != b.Height) throw new ArgumentException("The matrix heights do not match");
                if (a.Width != b.Width) throw new ArgumentException("The matrix widths do not match");
                var c = new Matrix(a.Height, a.Width);
                for (var i = 0; i < b.Height; i++)
                    for (var j = 0; j < b.Width; j++)
                        c[i, j] = a[i, j] + b[i, j];
                return c;
            }
            public Matrix Add(Matrix other, long mod) => Add(this, other, mod);
            public static Matrix Add(in Matrix a, in Matrix b, long mod)
            {
                if (a.Height != b.Height) throw new ArgumentException("The matrix heights do not match");
                if (a.Width != b.Width) throw new ArgumentException("The matrix widths do not match");
                var c = new Matrix(a.Height, a.Width);
                for (var i = 0; i < b.Height; i++)
                    for (var j = 0; j < b.Width; j++)
                        c[i, j] = (c[i, j] + (a[i, j] + b[i, j]) % mod) % mod;
                return c;
            }
            public Matrix Multiply(Matrix other) => Multiply(this, other);
            public static Matrix Multiply(in Matrix a, in Matrix b)
            {
                if (a.Width != b.Height) throw new ArgumentException();
                var c = new Matrix(a.Height, b.Width);
                for (var i = 0; i < a.Height; i++)
                    for (var k = 0; k < b.Height; k++)
                        for (var j = 0; j < b.Width; j++)
                            c[i, j] += a[i, k] * b[k, j];
                return c;
            }
            public Matrix Multiply(Matrix other, long mod) => Multiply(this, other, mod);
            public static Matrix Multiply(in Matrix a, in Matrix b, long mod)
            {
                if (a.Width != b.Height) throw new ArgumentException();
                var c = new Matrix(a.Height, b.Width);
                for (var i = 0; i < a.Height; i++)
                    for (var k = 0; k < b.Height; k++)
                        for (var j = 0; j < b.Width; j++)
                            c[i, j] = (c[i, j] + a[i, k] * b[k, j] % mod) % mod;
                return c;
            }
            public Matrix Power(long n) => Power(this, n);
            public static Matrix Power(in Matrix matrix, long n)
            {
                if (matrix.Height != matrix.Width) throw new ArgumentException(nameof(matrix));
                var mat = matrix.Copy();
                var ret = new Matrix(mat.Height, mat.Height);
                for (var i = 0; i < mat.Height; i++) ret[i, i] = 1;
                while (n > 0)
                {
                    if ((n & 1) == 1) ret = Multiply(ret, mat);
                    mat = Multiply(mat, mat);
                    n >>= 1;
                }
                return ret;
            }
            public Matrix Power(long n, long mod) => Power(this, n, mod);
            public static Matrix Power(in Matrix matrix, long n, long mod)
            {
                if (matrix.Height != matrix.Width) throw new ArgumentException(nameof(matrix));
                var mat = matrix.Copy();
                var ret = new Matrix(mat.Height, mat.Height);
                for (var i = 0; i < mat.Height; i++) ret[i, i] = 1;
                while (n > 0)
                {
                    if ((n & 1) == 1) ret = Multiply(ret, mat, mod);
                    mat = Multiply(mat, mat, mod);
                    n >>= 1;
                }
                return ret;
            }
            public Matrix Copy() => Copy(this);
            public static Matrix Copy(in Matrix matrix)
            {
                var ret = new Matrix(matrix.Height, matrix.Width);
                for (var i = 0; i < matrix.Height; i++)
                    for (var j = 0; j < matrix.Width; j++)
                        ret[i, j] = matrix[i, j];
                return ret;
            }
            public override string ToString()
            {
                var builder = new StringBuilder();
                for (var i = 0; i < Height; i++)
                {
                    for (var j = 0; j < Width; j++)
                    {
                        builder.Append(_data[i, j]);
                        builder.Append(j == Width - 1 ? "\n" : " ");
                    }
                }
                return builder.ToString();
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
