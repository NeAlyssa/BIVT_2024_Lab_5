using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        int[,] matrix4x4 = new int[,] {
            { 1, 2, 3, 4 },
            { 5, -5, 5, -5 },
            { 6, 7, 8, 9 },
            { -6, -5, -8, 0 }};
        int[,] matrix7x4 = new int[,] {
            { 1, 2, 3, 4 },
            { 5, 5, 4, 6 },
            { 5, -5, 5, -5 },
            { 6, 7, 8, 9 },
            { -6, -5, -8, 0 },
            { 11, 12, 13, 14 },
            { 6, 5, 8, 0 }};
        int[,] matrix3x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 10 } };
        int[,] matrix4x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { -11, 12, 13, 14, -15 },
            { 6, 7, 8, 9, 0 }};
        int[,] matrix5x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
        int[,] matrix6x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 0, 1, 0, 2, 0 },
            { 6, 7, 8, 9, 0 }};
        int[,] matrix4x6 = new int[,] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
        int[,] matrix5x6 = new int[,] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
        int[,] matrix6x6 = new int[,] {
            { 1,    2,  3,  4,  5,  -1 },
            { 6,    7,  8,  9,  10, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { -1,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  20, -2 },
            { 1,    3,  3,  1,  5, 5 }};
        double[,] matrix2x2 = new double[,] {
            { 1, -2 },
            { 5, -5 }};
        double[,] matrix3x3 = new double[,] {
            { 1, -2, 3 },
            { 5, -5, 5 },
            { 6, 7, 8 }};
        int[] arr6 = new int[] { -3, 5, 5, 1, 0, 4 };
        int[] arr6b = new int[] { 13, 10, 1, 0, -2, -4 };
        int[] arr7 = new int[] { 1, 2, 13, 4, -5, 6, 7 };
        int[] arr7b = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        int[] arr8 = new int[] { 1, 8, -3, 5, 5, 1, 0, 4 };
        int[] arr9 = new int[] { 1, 12, 3, 4, 5, -6, 7, 0, 9 };
        int[] arr10 = new int[] { 1, -8, -3, 5, -5, 1, 0, -4, -1, 2 };
        int[] arr11 = new int[] { 1, 12, 13, 0, 9, 1, 5, -6, 7, 12, 14 };
        double[] array7 = new double[] { 1, 2, 13, 4, -5, 6, 7 };
        double[] array8 = new double[] { 1, 8, -3, 5, -5, 1, 0, 4 };
        double[] array9 = new double[] { 1, 12, 3, 4, 5, -6, 7, 0, 9 };
        //program.Task_1_3b(10, 1, 9, 1.6);
        //program.Task_2_2(new double[] { 1, 12, 3, 4, 5, -6, 7, 0, 9 }, new double[] { 1, 2, 13, 4, -5, 6, 7 });
        //program.Task_2_6(ref arr7,arr8);
        //program.Task_2_8(arr9, arr11);
        //program.Task_2_20(ref matrix7x4, ref matrix6x5);
        //program.Task_3_10(ref matrix5x5);
        //int resultA =0, resultB = 0;
        //program.Task_3_28a(arr7, arr7b, ref resultA, ref resultB);
        int[] resultAi = null, resultAd = null, resultBi = null, resultBd = null;
        //program.Task_3_28c(arr7, arr7b, ref resultAi, ref resultAd ,ref resultBi , ref resultBd );
        double[,] a = new double[3, 3] { { 3, 3, 3 }, { 2, 1, 1 }, { 1, 2, 3 } };
        ToUpperTriangular(a);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        ToLowerTriangular(a);
        for (int i = 0; i <3; i++)
        {
            for (int j = 0;j < 3; j++)
            {
                Console.Write(a[i,j]+" ");
            }
            Console.WriteLine();
        }
    }
    public void printarr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]+" ");
        }
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        
        answer = Combinataion(n, k);
        // create and use Combinations(n, k);
        static int Combinataion(int n, int k)
        {
            int cnk = Factorial(n) / (Factorial(k) * Factorial(n - k));
            return cnk;
        }

        // create and use Factorial(n);
        static int Factorial(int n)
        {
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f *= i;
            }
            return f;
        }
        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)

    {
        int answer = 0;

        // code here
        double s1 = 0;
        double m1 = first[0];
        double s2 = 0;
        double m2 = second[0];
        for (int i = 0; i < 3; i++) { s1 += first[i]; if (first[i] > m1) m1 = first[i]; }
        for (int i = 0; i < 3; i++) { s2 += second[i]; if (second[i] > m2) m2 = second[i]; }
        if ((m1 >= s1 - m1) || (m2 >= s2 - m2))
        {
            answer = -1;
            return answer;
        }
        double area1 = GeronArea(first[0], first[1], first[2]);
        double area2 = GeronArea(second[0], second[1], second[2]);
        if (area1 > area2)
            answer = 1;
        else if (area1 == area2)
            answer = 0;
        else
            answer = 2;

        // create and use GeronArea(a, b, c);
        static double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        if (s1 > s2) answer = 1;
        else if (s1 == s2) answer = 0;
        else answer = 2;

        // create and use GetDistance(v, a, t); t - hours
        static double GetDistance(double v, double a, int t)
        {
            double s = v * t + a * t * t / 2;
            return s;
        }
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int t = 1;

        while ((GetDistance(v1, a1, t)) > GetDistance(v2, a2, t))
        {
            t++;

        }
        answer = t;
        // use GetDistance(v, a, t); t - hours
        static double GetDistance(double v, double a, int t)
        {
            double s = v * t + a * t * t / 2;
            return s;
        }
        // end
        Console.WriteLine(answer);
        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        int mi1 = FindMaxIndex(A);
        int mi2 = FindMaxIndex(B);
        double s = 0;
        int sc = 0;
        if (A.Length - 1 - mi1 < B.Length - 1 - mi2)
        {
            for (int i = mi2 + 1; i < B.Length; i++)
            {
                s += B[i];
                sc++;
            }
            s /= sc;
            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] == B[mi2])
                {
                    B[i] = s;
                }
            }
        }
        else if (9 - 1 - mi1 > 7 - 1 - mi2)
        {
            for (int i = mi1 + 1; i < A.Length; i++)
            {
                s += A[i];
                sc++;
            }
            s /= sc;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == A[mi1])
                {
                    A[i] = s;
                }
            }
        }
        for (int i = 0; i  < A.Length; i++)
        {
            Console.Write(A[i]+" ");
        }
        Console.WriteLine();

        // create and use FindMaxIndex(array);
        static int FindMaxIndex(double[] a)
        {
            int mi = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= a[mi])
                    mi = i;
            }
            return mi;
        }
        // only 1 array have to be changed!
        foreach (double i in A)
            Console.Write(i + " ");
        Console.WriteLine();
        foreach (double i in B)
            Console.Write(i + " ");
        return;
        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        int ai = FindDiagonalMaxIndex(A);
        int bi = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[ai, i];
            A[ai, i] = B[i, bi];
            B[i, bi] = temp;
        }
        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        static int FindDiagonalMaxIndex(int[,] a)
        {
            int mi = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (a[i, i] > a[mi, mi])
                    mi = i;
            }
            return mi;
        }
        return;
        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int ma = FindMax(A);
        int mb = FindMax(B);
        for (int i = A.Length - 1; i >= 0; i--)
        {
            if (A[i] == ma)
                A = DeleteElement(A, i);
        }
        for (int i = B.Length - 1; i >= 0; i--)
        {
            if (B[i] == mb)
                B = DeleteElement(B, i);
        }
        int[] a = new int[A.Length + B.Length];
        for (int i = 0; i < A.Length; i++)
            a[i] = A[i];
        for (int i = 0; i < B.Length; i++)
            a[A.Length + i] = B[i];
        A = a;
        static int FindMax(int[] a)
        {
            int m = -1000;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > m)
                    m = a[i];
            }
            return m;
        }
        // create and use DeleteElement(array, index);
        static int[] DeleteElement(int[] a, int ind)
        {
            int[] a0 = new int[a.Length - 1];
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (i < ind)
                    a0[i] = a[i];
                else
                    a0[i] = a[i + 1];
            }
            return a0;
        }
        foreach (int i in a)
            Console.Write(i + " ");
        return;
        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        int mi1 = 0;
        int mi2 = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > A[mi1])
                mi1 = i;
        }
        for (int i = 0; i < B.Length; i++)
        {
            if (B[i] > B[mi2])
                mi2 = i;
        }
        A = SortArrayPart(A, mi1);
        B = SortArrayPart(B, mi2);
        // create and use SortArrayPart(array, startIndex);
        static int[] SortArrayPart(int[] a, int ind)
        {
            for (int i = ind + 1; i < a.Length; i++)
            {
                for (int j = ind + 1; j < a.Length - i + ind; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
            return a;
        }
        foreach (int i in A)
            Console.Write(i + " ");
        Console.WriteLine();
        foreach (double i in B)
            Console.Write(i + " ");
        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int m1 = -1000;
        int mj1 = -1;
        int m2 = 1000;
        int mj2 = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j <= i)
                {
                    if (matrix[i, j] > m1)
                    {
                        m1 = matrix[i, j];
                        mj1 = j;
                    }
                }
                else
                {
                    if (matrix[i, j] < m2)
                    {
                        m2 = matrix[i, j];
                        mj2 = j;
                    }
                }
            }
        }
        if (mj1 > mj2)
        {
            matrix = RemoveColumn(matrix, mj1);
            matrix = RemoveColumn(matrix, mj2);
        }
        else if (mj2 > mj1)
        {
            matrix = RemoveColumn(matrix, mj2);
            matrix = RemoveColumn(matrix, mj1);
        }
        else
            matrix = RemoveColumn(matrix, mj1);
        // create and use RemoveColumn(matrix, columnIndex);
    
        // end
    }
    public int[,] RemoveColumn(int[,] m, int ind)
    {
        int ii = m.GetLength(0);
        int jj = m.GetLength(1);
        int[,] m0 = new int[ii, jj - 1];
        for (int i = 0; i < ii; i++)
        {
            for (int j = 0; j < jj - 1; j++)
            {
                if (j < ind)
                    m0[i, j] = m[i, j];
                else
                    m0[i, j] = m[i, j + 1];
            }
        }
        return m0;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int ja = FibdMaxColymnIndex(A);
        int jb = FibdMaxColymnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[i, ja];
            A[i, ja] = B[i, jb];
            B[i, jb] = temp;
        }
        // create and use FindMaxColumnIndex(matrix);
        static int FibdMaxColymnIndex(int[,] m)
        {
            int mi = 0;
            int ma = -1000;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] > ma)
                    {
                        ma = m[i, j];
                        mi = j;
                    }
                }
            }
            return mi;
        }
        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix = (SortRow(matrix, i));
        }
        // create and use SortRow(matrix, rowIndex);
        static int[,] SortRow(int[,] m, int ind)
        {
            for (int i = 0; i < m.GetLength(1); i++)
            {
                for (int j = 0; j < m.GetLength(1) - 1 - i; j++)
                {
                    if (m[ind, j] > m[ind, j + 1])
                    {
                        int temp = m[ind, j];
                        m[ind, j] = m[ind, j + 1];
                        m[ind, j + 1] = temp;
                    }
                }
            }
            return m;
        }
        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        A = SortNegative(A);
        B = SortNegative(B);
        // create and use SortNegative(array);
        static int[] SortNegative(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < 0)
                {
                    int k = i, j = i - 1;
                    while (j > 0)
                    {
                        if (a[j] < 0)
                        {
                            if (a[k] > a[j])
                            {
                                int temp = a[k];
                                a[k] = a[j];
                                a[j] = temp;
                                k = j;
                            }
                        }
                        j--;
                    }
                }
            }
            return a;
        }
        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        A = SortDiagonal(A);
        B = SortDiagonal(B);
        // create and use SortDiagonal(matrix);
        static int[,] SortDiagonal(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(0) - 1 - i; j++)
                {
                    if (m[j, j] > m[j + 1, j + 1])
                    {
                        int temp = m[j, j];
                        m[j, j] = m[j + 1, j + 1];
                        m[j + 1, j + 1] = temp;
                    }
                }
            }
            return m;
        }
        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)

    {
        // code here
        for (int j = A.GetLength(1) - 1; j >= 0; j--)
        {

            for (int i = 0; i < A.GetLength(0); i++)
            {

                if (A[i, j] == 0)
                    break;
                if (i == A.GetLength(0) - 1)

                    A = RemoveColumn(A, j);
            }
        }
        for (int j = B.GetLength(1) - 1; j >= 0; j--)
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                if (B[i, j] == 0)
                    break;
                if (i == B.GetLength(0) - 1)
                    B = RemoveColumn(B, j);
            }
        }
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
                Console.Write(A[i, j] + " ");
            Console.WriteLine();
        }
        // use RemoveColumn(matrix, columnIndex); from 2_10
        static int[,] RemoveColumn(int[,] m, int ind)
        {
            int ii = m.GetLength(0);
            int jj = m.GetLength(1);
            int[,] m0 = new int[ii, jj - 1];
            for (int i = 0; i < ii; i++)
            {
                for (int j = 0; j < jj - 1; j++)
                {
                    if (j < ind)
                        m0[i, j] = m[i, j];
                    else
                        m0[i, j] = m[i, j + 1];
                }
            }
            return m0;
        }
        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        for (int i = 0; i < cols.Length; i++)
        {
            cols[i] = FindMaxNegativePerColumn(matrix, i);
        }
        // create and use CountNegativeInRow(matrix, rowIndex);
        
        // create and use FindMaxNegativePerColumn(matrix);
        
        // end
    }
    public int CountNegativeInRow(int[,] m, int ind)
    {
        int c = 0;
        for (int i = 0; i < m.GetLength(1); i++)
        {
            if (m[ind, i] < 0)
                c++;
        }
        return c;
    }
    public int FindMaxNegativePerColumn(int[,] m, int ind)
    {
        int ma = -10000;
        for (int i = 0; i < m.GetLength(0); i++)
        {
            if (m[i, ind] < 0 && (m[i, ind] > ma))
                ma = m[i, ind];
        }
        return ma;
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        int rowa, columna, rowb, columnb;
        FindMaxIndex(A, out rowa, out columna);
        FindMaxIndex(B, out rowb, out columnb);
        A = SwapColumnDiagonal(A, columna);
        B = SwapColumnDiagonal(B, columnb);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        static void FindMaxIndex(int[,] m, out int r, out int c)
        {
            r = 0;
            c = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] > m[r, c])
                    {
                        r = i;
                        c = j;
                    }
                }
            }
        }
        // create and use SwapColumnDiagonal(matrix, columnIndex);
        static int[,] SwapColumnDiagonal(int[,] m, int ind)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                int temp = m[i, ind];
                m[i, ind] = m[i, i];
                m[i, i] = temp;
            }
            return m;
        }
        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int ia = FindRowWithMaxNegativeCount(A);
        int ib = FindRowWithMaxNegativeCount(B);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int temp = A[ia, i];
            A[ia, i] = B[ib, i];
            B[ib, i] = temp;
        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        static int FindRowWithMaxNegativeCount(int[,] m)
        {
            int ind = -1;
            int c = -1;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                int cn = CountNegativeInRow(m, i);
                if (cn > c)
                {
                    c = cn;
                    ind = i;
                }
            }
            return ind;
        }
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22
        static int CountNegativeInRow(int[,] m, int ind)
        {
            int c = 0;
            for (int i = 0; i < m.GetLength(1); i++)
            {
                if (m[ind, i] < 0)
                    c++;
            }
            return c;
        }
        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        static int FindSequence(int[] arr, int a, int b)
        {
            int ans = -1;
            for (int i = a; i < b; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    ans = 0;
                    break;
                }
            }
            if (ans == -1)
                return ans;
            ans = 1;
            for (int i = a; i < b; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    ans = 0;
                    break;
                }
            }
            return ans;
        }
        // A and B - start and end indexes of elements from array for search

        // end
    }


    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        int c1 = 0;
        int c2 = 0;
        for (int i = 0; i < first.Length - 1; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                if (FindSequence(first, i, j) != 0)
                    c1++;
            }
        }
        for (int i = 0; i < second.Length - 1; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                if (FindSequence(second, i, j) != 0)
                    c2++;
            }
        }
        answerFirst = new int[c1, 2];
        answerSecond = new int[c2, 2];
        int k = 0;
        for (int i = 0; i < first.Length - 1; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                if (FindSequence(first, i, j) != 0)
                {
                    answerFirst[k, 0] = i;
                    answerFirst[k, 1] = j;
                    k++;
                }
            }
        }
        k = 0;
        for (int i = 0; i < second.Length - 1; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                if (FindSequence(second, i, j) != 0)
                {
                    answerSecond[k, 0] = i;
                    answerSecond[k, 1] = j;
                    k++;
                }
            }
        }
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        static int FindSequence(int[] arr, int a, int b)
        {
            int ans = -1;
            for (int i = a; i < b; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    ans = 0;
                    break;
                }
            }
            if (ans == -1)
                return ans;
            ans = 1;
            for (int i = a; i < b; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    ans = 0;
                    break;
                }
            }
            return ans;
        }
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        answerFirst = [0, 0];
        answerSecond = [0, 0];
        for (int i = 0; i < first.Length - 1; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                if (FindSequence(first, i, j) != 0)
                {
                    if (j - i > (answerFirst[1] - answerFirst[0]))
                    {
                        answerFirst[0] = i;
                        answerFirst[1] = j;
                    }
                }
            }
        }
        for (int i = 0; i < second.Length - 1; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                if (FindSequence(second, i, j) != 0)
                {
                    if (j - i > (answerSecond[1] - answerSecond[0]))
                    {
                        answerSecond[0] = i;
                        answerSecond[1] = j;
                    }
                }
            }
        }
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        static int FindSequence(int[] arr, int a, int b)
        {
            int ans = -1;
            for (int i = a; i < b; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    ans = 0;
                    break;
                }
            }
            if (ans == -1)
                return ans;
            ans = 1;
            for (int i = a; i < b; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    ans = 0;
                    break;
                }
            }
            return ans;
        }
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);


        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sortStyle = (i % 2 == 0) ? SortAscending : SortDescending;
            sortStyle(matrix, i);
        }
    }

    // create and use public delegate SortRowStyle(matrix, rowIndex);
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
    public static void SortAscending(int[,] m, int ind)
    {
        for (int i = 0; i < m.GetLength(1); i++)
        {
            for (int j = 0; j < m.GetLength(1) - 1 - i; j++)
            {
                if (m[ind, j] > m[ind, j + 1])
                {
                    int temp = m[ind, j];
                    m[ind, j] = m[ind, j + 1];
                    m[ind, j + 1] = temp;
                }
            }
        }
    }

    public static void SortDescending(int[,] m, int ind)
    {
        for (int i = 0; i < m.GetLength(1); i++)
        {
            for (int j = 0; j < m.GetLength(1) - 1 - i; j++)
            {
                if (m[ind, j] < m[ind, j + 1])
                {
                    int temp = m[ind, j];
                    m[ind, j] = m[ind, j + 1];
                    m[ind, j + 1] = temp;
                }
            }
        }
    }
    // change method in variable sortStyle in the loop here and use it for row sorting

    // end



    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;
        GetTriangle getTriangle;
        if (isUpperTriangle)
            getTriangle = GetUpperTriange;
        else
            getTriangle = GetLowerTriange;
        answer = GetSum(getTriangle, matrix);
        return answer;
    }
    // code here

    // create and use public delegate GetTriangle(matrix);
    public delegate int[] GetTriangle(int[,] matrix);
    // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
    public int[] GetUpperTriange(int[,] matrix)
    {
        int ii = matrix.GetLength(0);
        int[] vector = new int[ii * (ii + 1) / 2];
        int k = 0;
        for (int i = 0; i < ii; i++)
        {
            for (int j = i; j < ii; j++)
            {
                vector[k] = matrix[i, j];
                k++;
            }
        }
        return vector;
    }
    public int[] GetLowerTriange(int[,] matrix)
    {
        int ii = matrix.GetLength(0);
        int[] vector = new int[ii * (ii + 1) / 2];
        int k = 0;
        for (int i = 0; i < ii; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                vector[k] = matrix[i, j];
                k++;
            }
        }
        return vector;
    }
    // create and use GetSum(GetTriangle, matrix)
    public int GetSum(GetTriangle Triangle, int[,] matrix)
    {
        int[] vector = Triangle(matrix);
        int s = 0;
        foreach (int i in vector)
            s += i * i;
        return s;
    }
    // end



    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here
        FindElementDelegate Diagonal = FindDiagonalMaxIndex;
        FindElementDelegate FirstRow = FindFirstRowMaxIndex;
        SwapColumns(matrix, Diagonal, FirstRow);
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int indexmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > matrix[indexmax, indexmax])
                indexmax = i;
        }
        return indexmax;
    }

    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int indexmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[0, i] > matrix[0, indexmax])
                indexmax = i;
        }
        return indexmax;
    }
    public void SwapColumns(int[,] matrix, FindElementDelegate Diagonal, FindElementDelegate FirstRow)
    {
        int i1 = Diagonal(matrix);
        int i2 = FirstRow(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, i1];
            matrix[i, i1] = matrix[i, i2];
            matrix[i, i2] = temp;
        }
    }


    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me
        FindIndex maxBelow = FindMaxBelowDiagonalIndex;
        FindIndex minAbove= FindMinAboveDiagonalIndex;
        matrix = RemoveColumns(matrix, maxBelow, minAbove);
        // code here
        
        
        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public delegate int FindIndex(int[,] matrix);

    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int index = 0;
        int m = -1000;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j<= i; j++)
            {
                if (matrix[i,j] > m)
                {
                    m = matrix[i, j];
                    index = j;
                }
            }
        }
        return index;
    }
    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int index = 0;
        int m = 1000;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i+1; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] < m)
                {
                    m = matrix[i, j];
                    index = j;
                }
            }
        }
        return index;
    }
    public int[,] RemoveColumns(int[,] matrix, FindIndex maxBelow, FindIndex minAbove)
    {
        int i1 = maxBelow(matrix);
        int i2 = minAbove(matrix);
        if (i1 == i2)
            matrix = RemoveColumn(matrix, i1);
        else
        {
            matrix = RemoveColumn(matrix, Math.Max(i1, i2));
            matrix = RemoveColumn(matrix, Math.Min(i1, i2));
        }
        return matrix;
    }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;
        FindNegatives(matrix, out rows, out cols);
        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }
    public delegate int GetNegativeArray(int[,] matrix, int rowIndex);
    public void FindNegatives(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        GetNegativeArray searcherRows = CountNegativeInRow;
        GetNegativeArray searcherCols = FindMaxNegativePerColumn;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = searcherRows(matrix, i);
        }
        
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            cols[j] = searcherCols(matrix, j);
        }
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = DefineSequence(first, 0, first.Length - 1);
        answerSecond = DefineSequence(second, 0, second.Length - 1);
        Console.WriteLine(answerFirst);

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
    }
    public delegate bool IsSequence(int[] arrat, int left, int right);

    public bool FindIncreasingSequence(int[] array, int A,int B)
    {
        bool answer = true;
        for (int i =A; i<=B-1; i++)
        {
            if (array[i] > array[i + 1])
                answer = false;
        }
        return answer;
    }
    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        bool answer = true;
        for (int i = A; i <=B-1; i++)
        {
            if (array[i] < array[i + 1])
                answer = false;
        }
        return answer;
    }
    public int DefineSequence(int[] array, int A,int B)
    {
        int answer = 0;
        IsSequence monotony = FindIncreasingSequence;
        if (monotony(array, A, B))
            answer = 1;
        monotony = FindDecreasingSequence;
        if (monotony(array, A, B))
            answer = -1;
        return answer;
    }
    // end


    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        IsSequence monotony = FindIncreasingSequence;
        answerFirstIncrease = FindLongestSequence(first, monotony);
        answerSecondIncrease = FindLongestSequence(second, monotony);
        monotony = FindDecreasingSequence;
        answerFirstDecrease = FindLongestSequence(first, monotony);
        answerSecondDecrease = FindLongestSequence(second, monotony);
        printarr(answerFirstIncrease);
        Console.WriteLine();
        printarr(answerSecondIncrease);
        Console.WriteLine();
        printarr(answerFirstDecrease);
        Console.WriteLine();
        printarr(answerSecondDecrease);
        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);
    }
    public int[] FindLongestSequence(int[] array,IsSequence sequence)
    {
        int ans = 0;
        int ansi = -1;
        int ansj = -1;
        int[] answer = null;
        for (int i = 0; i < array.Length-1; i++)
        {
            for (int j = i +1; j < array.Length; j++)
            {
                if (sequence(array, i, j) && j - i + 1 > ans)
                {
                    ans = j - i + 1;
                    ansi = i;
                    ansj = j;
                }
            }
        }
        Console.WriteLine(ansi);
        Console.WriteLine(ansj);
        answer = new int[2];
        int k = 0;
        if (ansi == -1)
            return answer;
        answer[0] = ansi;
        answer[1] = ansj;
        return answer;
    }
    // end

    #endregion
    #region bonus part
    public delegate void MatrixConverter(double[,] matrix);
    public static void ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                double p = matrix[j, i] / matrix[i,i];
                for (int k = i; k < n; k++)
                {
                    
                    matrix[j, k] -= matrix[i, k] * p;
                }
            }    
        }
    }
    public static void ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = n-1; i > 0; i--)
        {
            for (int j = i -1; j >= 0; j--)
            {
                double p = matrix[j, i] / matrix[i, i];
                for (int k = i; k >=0; k--)
                {

                    matrix[j, k] -= matrix[i, k] * p;
                }
            }
        }
    }
    public static void ToLefDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }
    public static void ToRightDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLefDiagonal;
        mc[3] = ToRightDiagonal;
        mc[index](matrix);
        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
