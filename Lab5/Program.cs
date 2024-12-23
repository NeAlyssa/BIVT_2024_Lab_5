using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        int[,] matrix5x6 = new int[,] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 6, 7, 8, 9, 0, -2 }};
        program.Task_3_2(matrix5x6);
        program.printM(matrix5x6);
    }


    void printM(int[,] m)
    {
        for (int i =0; i<m.GetLength(0); i++)
        {
            for (int j = 0; j<m.GetLength(1); j++)
            {
                Console.Write("{0:d} ", m[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        long factorial(long n)
        {
            int answer = 1;
            for (int i = 1; i<=n; i++)
            {
                answer *= i;
            }
            return answer;
        }
        long Combinations(long n, long k)
        {
            return (factorial(n)) / (factorial(n - k) * factorial(k));
        }

        // create and use Combinations(n, k);
        // create and use Factorial(n);
        answer = Combinations(n, k);
        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        // create and use GeronArea(a, b, c);
        double GeronArea(double a, double b, double c)
        {
            double p = a + b + c; p /= 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        bool Tringle(double a, double b, double c)
        {
            if (a+b<=c || a+c <=b || b+c <= a)
            {
                return false;
            }
            return true;
        }
        if (first == null || second == null || first.Length != 3 || second.Length != 3)
        {
            return -1;
        }
        if (!Tringle(first[0], first[1], first[2]) || !Tringle(second[0], second[1], second[2])) return -1;
        double ar1 = GeronArea(first[0], first[1], first[2]), ar2 = GeronArea(second[0], second[1], second[2]);
        if (ar1 == ar2) return 0;
        if (ar1 < ar2) return 2;
        else return 1;
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        double GetDistance(double v, double a, double t)
        {
            return v * t + (a * t * t) / 2;
        }
        double d1 = GetDistance(v1, a1, time), d2 = GetDistance(v2,a2,time);
        if (d1 == d2) return 0;
        if (d1 < d2) return 2;
        else return 1;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // use GetDistance(v, a, t); t - hours
        double GetDistance(double v, double a, double t)
        {
            return v * t + (a * t * t) / 2;
        }
        for (int time = 1; ; time++)
        {
            double d1 = GetDistance(v1, a1, time), d2 = GetDistance(v2, a2, time);
            if (d1 <= d2) return time;
        }

        // end

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

        // create and use FindMaxIndex(array);
        int FindMax(double[] arr)
        {
            double mx = -1e18; int pos = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (mx < arr[i])
                {
                    mx = arr[i]; pos = i;
                }
            }
            return pos;
        }

        int p1 = FindMax(A), p2 = FindMax(B);
        if (p1 < p2)
        {
            double sum = 0;
            for (int i = p1+1; i<A.Length; i++)
            {
                sum += A[i];
            }
            sum /= (A.Length - (p1 + 1));
            A[p1] = sum;
        }
        else
        {
            double sum = 0;
            for (int i = p2 + 1; i < B.Length; i++)
            {
                sum += B[i];
            }
            sum /= (B.Length - (p2 + 1));
            B[p2] = sum;
        }

        // only 1 array has to be changed!

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

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        (int, int) FindDiagonalMaxIndex(int[,] matrix)
        {
            int mx = -1000000000, row = 0, col = 0;
            for (int i = 0; i<matrix.GetLength(0) && i<matrix.GetLength(1); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i]; row = i; col = i;
                }
            }
            return (row, col);
        }

        int row1, col1, row2, col2; (row1, col1) = FindDiagonalMaxIndex(A); (row2, col2) = FindDiagonalMaxIndex(B);
        for (int i =0; i<A.GetLength(1); i++)
        {
            (A[row1, i], B[i, col2]) = (B[i, col2],  A[row1, i]);
        }
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

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);
        int FindMax(int[] A)
        {
            int mx = -1000000, pos = 0;
            for (int i =0; i<A.Length; i++)
            {
                if (A[i] > mx)
                {
                    mx = A[i]; pos = i;
                }
            }
            return pos;
        }
        int pos1 = FindMax(A), pos2 = FindMax(B);
        void Delete(ref int[] A, int pos)
        {
            int[] Ad = new int[A.Length - 1];
            for (int i = 0; i < A.Length; i++)
            {
                if (i > pos)
                {
                    Ad[i - 1] = A[i];
                }
                else if (i == pos)
                {
                    continue;
                }
                else { Ad[i] = A[i]; }
            }
            A = Ad;
        }
        Delete(ref A, pos1); Delete(ref B, pos2);
        int[] F = new int[A.Length + B.Length];
        for (int i =0; i<F.Length; i++)
        {
            if (i < A.Length)
            {
                F[i] = A[i];
            }
            else
            {
                F[i] = B[i - A.Length];
            }
        }
        A = F;

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

        // create and use SortArrayPart(array, startIndex);
        void SortArrayPart(int[] A, int l, int r, bool flag)
        {
            double cmp = 1; if (flag) cmp = -1;
            for (int i = l; i < r; i++)
            {
                for (int j = l + 1; j < r - (i - l); j++)
                {
                    if (A[j - 1] * cmp > A[j] * cmp)
                    {
                        (A[j], A[j - 1]) = (A[j - 1], A[j]);
                    }
                }
            }
        }
        int FindMax(int[] A)
        {
            int mx = -1000000, pos = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > mx)
                {
                    mx = A[i]; pos = i;
                }
            }
            return pos;
        }
        int pos1 = FindMax(A), pos2 = FindMax(B);
        SortArrayPart(A, pos1 + 1, A.Length, false); SortArrayPart(B, pos2 + 1, B.Length, false); 

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

    public delegate (int, int) FindIndex(int[,] m);
    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);
        (int, int) FindDiagonalMaxIndex(int[,] matrix)
        {
            int mx = -1000000000, row = 0, col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j<=i; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j]; row = i; col = j;
                    }
                }
            }
            return (row, col);
        }
        (int, int) FindDiagonalMinIndex(int[,] matrix)
        {
            int mx = -1000000000, row = 0, col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j]; row = i; col = j;
                    }
                }
            }
            return (row, col);
        }
        void RemoveColumn(ref int[,] matrix, int columnIndex)
        {
            int[,] mat = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i =0; i<matrix.GetLength(0); i++)
            {
                for (int j =0; j < matrix.GetLength(1); j++)
                {
                    if (j == columnIndex) continue;
                    if (j > columnIndex)
                    {
                        mat[i,j-1] = matrix[i,j];
                    }
                    else
                    {
                        mat[i,j] = matrix[i,j];
                    }
                }
            }
            matrix = mat;
        }
        int row1,col1,row2,col2;
        FindIndex DiagMax = FindDiagonalMaxIndex, DiagMin = FindDiagonalMinIndex;
        (row1,col1) = DiagMax(matrix); (row2,col2) = DiagMin(matrix);
        if (col1 > col2)
        {
            (col1, col2) = (col2, col1);
        }
        RemoveColumn(ref matrix, col1); if (col1!=col2) RemoveColumn(ref matrix, col2 - 1);
        printM(matrix);
        // end
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

        // create and use FindMaxColumnIndex(matrix);
        (int, int) FindMaxIndex(int[,] matrix)
        {
            int mx = -1000000000, row = 0, col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j]; row = i; col = j;
                    }
                }
            }
            return (row, col);
        }
        int row1, col1, row2, col2;
        (row1, col1) = FindMaxIndex(A); (row2, col2) = FindMaxIndex(B);
        for (int i =0; i<A.GetLength(0); i++)
        {
            (A[i, col1], B[i, col2]) = (B[i, col2], A[i, col1]);
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

        // create and use SortRow(matrix, rowIndex);
        void sortRow(int[,] matrix, int ind)
        {
            for (int i = 0; i<matrix.GetLength(1); i++)
            {
                for (int j = 1; j<matrix.GetLength(1) - i; j++)
                {
                    if (matrix[ind,j] < matrix[ind, j - 1])
                    {
                        (matrix[ind, j], matrix[ind, j - 1]) = (matrix[ind, j - 1], matrix[ind, j]);
                    }
                }
            }
        }
        for (int i =0; i<matrix.GetLength(0); i++)
        {
            sortRow(matrix, i);
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

        // create and use SortNegative(array);
        void SortNegative(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int prev = -1;
                for (int j = 1; j < A.Length; j++)
                {
                    if (A[j] >= 0) continue;
                    else if (prev==-1)
                    {
                        prev = j;
                    }
                    if (A[j] > A[prev] && A[j] < 0) 
                    {
                        (A[j], A[prev]) = (A[prev], A[j]);
                    }
                    if (A[j] < 0) prev = j;
                }
            }
        }
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write("{0:d} ", A[i]);
        }
        Console.WriteLine();
        SortNegative(A); SortNegative(B);
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write("{0:d} ", A[i]);
        }
        Console.WriteLine();
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

        // create and use SortDiagonal(matrix);
        void sortDiag(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) && i<matrix.GetLength(1); i++)
            {
                for (int j = 1; j < matrix.GetLength(0) && j < matrix.GetLength(1); j++)
                {
                    if (matrix[j, j] < matrix[j - 1, j - 1])
                    {
                        (matrix[j, j], matrix[j - 1, j - 1]) = (matrix[j - 1, j - 1], matrix[j, j]);
                    }
                }
            }
        }
        sortDiag(A); sortDiag(B);
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

        // use RemoveColumn(matrix, columnIndex); from 2_10
        void RemoveColumn(ref int[,] matrix, int columnIndex)
        {
            int[,] mat = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == columnIndex) continue;
                    if (j > columnIndex)
                    {
                        mat[i, j - 1] = matrix[i, j];
                    }
                    else
                    {
                        mat[i, j] = matrix[i, j];
                    }
                }
            }
            matrix = mat;
        }
        printM(A);
        for (int i = 0; i<A.GetLength(1); i++)
        {
            int cnt = 0;
            for (int j =0;  j < A.GetLength(0); j++)
            {
                if (A[j,i]==0)
                {
                    cnt++; break;
                }
            }
            if (cnt == 0)
            {
                RemoveColumn(ref A, i); i--;
            }
        }
        printM(A);
        for (int i = 0; i < B.GetLength(1); i++)
        {
            int cnt = 0;
            for (int j = 0; j < B.GetLength(0); j++)
            {
                if (B[j, i] == 0)
                {
                    cnt++; break;
                }
            }
            if (cnt == 0)
            {
                RemoveColumn(ref B, i); i--;
            }
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

    public delegate int Count(int[,] m, int i);
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);
        int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int cnt = 0;
            for (int i =0; i< matrix.GetLength(1); i++)
            {
                if (matrix[rowIndex, i] < 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }
        int FindMaxNegativePerColumn(int[,] matrix, int colIndex)
        {
            int mx = -1000000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (mx < matrix[i,colIndex] && matrix[i, colIndex] < 0)
                {
                    mx = matrix[i,colIndex];
                }
            }
            return mx;
        }
        Count Neg = CountNegativeInRow, MaxNeg = FindMaxNegativePerColumn;
        for (int i =0; i<matrix.GetLength(0); i++)
        {
            rows[i] = Neg(matrix, i);
        }
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            cols[i] = MaxNeg(matrix, i);
        }
        // end
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

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);
        (int, int) FindMaxIndex(int[,] matrix)
        {
            int mx = -1000000000, row = 0, col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j]; row = i; col = j;
                    }
                }
            }
            return (row, col);
        }
        void Swap(int[,] matrix, int col)
        {
            for (int i =0; i<matrix.GetLength(0); i++)
            {
                (matrix[i, i], matrix[i, col]) = (matrix[i, col], matrix[i, i]);
            }
        }
        int row1, col1, row2, col2;
        (row1, col1) = FindMaxIndex(A); (row2, col2) = FindMaxIndex(B);

        Swap(A, col1); Swap(B, col2);
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

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22
        int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[rowIndex, i] < 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }
        int FindRowWithMaxNegativeCount(int[,] a)
        {
            int mx = -10000, pos = 0;
            for (int i = 0; i<a.GetLength(0); i++)
            {
                int now = CountNegativeInRow(a, i);
                if (mx < now)
                {
                    mx = now; pos = i;
                }
            }
            return pos;
        }
        int row1 = FindRowWithMaxNegativeCount(A), row2 = FindRowWithMaxNegativeCount(B);
        for (int i =0; i<A.GetLength(1); i++)
        {
            (A[row1, i], B[row2, i]) = (B[row2, i], A[row1, i]);
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

    delegate int FindSeq(int[] arr, int A, int B);
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search
        int FindSequence(int[] array, int A, int B)
        {
            bool inc = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] < array[i - 1])
                {
                    inc = false; break;
                }
            }
            if (inc) return 1;
            bool decr = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] > array[i - 1])
                {
                    decr = false; break;
                }
            }
            if (decr) return -1;
            return 0;
        }
        FindSeq F = FindSequence;
        answerFirst = F(first, 0, first.Length - 1);
        answerSecond = F(second, 0, second.Length - 1);
        // end
    }

    public delegate int[,] FindMonot(int[] arr, int A, int B);
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search
        int FindSequence(int[] array, int A, int B)
        {
            bool inc = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] < array[i - 1])
                {
                    inc = false; break;
                }
            }
            if (inc) return 1;
            bool decr = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] > array[i - 1])
                {
                    decr = false; break;
                }
            }
            if (decr) return -1;
            return 0;
        }
        int[,] FindMonotony(int[] array, int A, int B)
        {
            FindSeq F = FindSequence;
            int len = 0;
            for (int i =A; i<=B; i++)
            {
                for (int j = i + 1; j<=B; j++)
                {
                    if (F(array, i, j) != 0)
                    {
                        len++;
                    }
                }
            }
            int[,] matrix = new int[len, 2];
            int cnt = 0;
            for (int i = A; i <= B; i++)
            {
                for (int j = i + 1; j <= B; j++)
                {
                    if (F(array, i, j) != 0)
                    {
                        matrix[cnt, 0] = i; matrix[cnt, 1] = j; cnt++;
                    }
                }
            }
            return matrix;
        }
        FindMonot F = FindMonotony;
        answerFirst = F(first, 0, first.Length - 1);
        answerSecond = F(second, 0, second.Length - 1);
        // end
    }

    public delegate int[] FindLong(int[] arr);
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search
        int FindSequence(int[] array, int A, int B)
        {
            bool inc = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] < array[i - 1])
                {
                    inc = false; break;
                }
            }
            if (inc) return 1;
            bool decr = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] > array[i - 1])
                {
                    decr = false; break;
                }
            }
            if (decr) return -1;
            return 0;
        }
        int[,] FindMonotony(int[] array, int A, int B)
        {
            FindSeq F = FindSequence;
            int len = 0;
            for (int i = A; i <= B; i++)
            {
                for (int j = i + 1; j <= B; j++)
                {
                    if (F(array, i, j) != 0)
                    {
                        len++;
                    }
                }
            }
            int[,] matrix = new int[len, 2];
            int cnt = 0;
            for (int i = A; i <= B; i++)
            {
                for (int j = i + 1; j <= B; j++)
                {
                    if (F(array, i, j) != 0)
                    {
                        matrix[cnt, 0] = i; matrix[cnt, 1] = j; cnt++;
                    }
                }
            }
            return matrix;
        }
        int[] FindLongestMon(int[] arr)
        {
            FindMonot F = FindMonotony;
            int[,] mon = F(arr, 0, arr.Length - 1);
            int len = -1;
            int l = 0, r = 0;
            for (int i = 0; i < mon.GetLength(0); i++)
            {
                if (len < Math.Abs(mon[i,0] - mon[i,1]))
                {
                    len = Math.Abs(mon[i,1] - mon[i,0]);
                    l = mon[i, 0]; r = mon[i, 1];
                }
            }
            int[] ret = new int[] { l, r};
            return ret;
        }
        FindLong F = FindLongestMon;
        answerFirst = F(first);
        answerSecond = F(second);
        
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

    public delegate void SortRowStyle(int[,] matrix, int index);
    public void Task_3_2(int[,] matrix)
    {
        //SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting
        void SortAscending(int[,] A, int index)
        {
            int n = A.GetLength(1);
            for (int i =0; i<n; i++)
            {
                for (int j = 1; j < n - i; j++)
                {
                    if (A[index, j] < A[index, j - 1])
                    {
                        (A[index, j], A[index, j - 1]) = (A[index, j - 1], A[index, j]);
                    }
                }
            }
        }
        void SortDescending(int[,] A, int index)
        {
            int n = A.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n - i; j++)
                {
                    if (A[index, j] > A[index, j - 1])
                    {
                        (A[index, j], A[index, j - 1]) = (A[index, j - 1], A[index, j]);
                    }
                }
            }
        }
        void SortingMatrix(int[,] A)
        {
            int n = A.GetLength(0);
            for (int i =0; i<n; i++)
            {
                SortRowStyle sort;
                sort = (i % 2 == 0 ? SortAscending : SortDescending);
                sort(matrix, i);
            }
        }
        SortingMatrix(matrix);
        // end
    }

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

    public delegate int[] GetTringle(int[,] matrix);
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)
        int[] GetUpperTringle(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] ret = new int[(n * n) / 2 + n];
            int cnt = 0;
            for (int i =0; i<n; i++)
            {
                for (int j = i; j < m; j++)
                {
                    ret[cnt++] = matrix[i, j];
                }
            }
            return ret;
        }
        int[] GetLowerTringle(int[,] matrix)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] ret = new int[(n * n) / 2 + n];
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    ret[cnt++] = matrix[i, j];
                }
            }
            return ret;
        }
        int GetSum(int[,] matrix)
        {
            GetTringle tringle;
            tringle = (isUpperTriangle ? GetUpperTringle : GetLowerTringle);
            int[] a = tringle(matrix);
            int ret = 0;
            foreach (int i in a)
            {
                ret+= i*i;
            }
            return ret;
        }
        // end
        answer = GetSum(matrix);
        return answer;
    }

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

    public delegate int FindElement(int[,] m);
    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        int FindDiagonalMaxIndex(int[,] matrix)
        {
            int res = 0, mx = -10000000;
            for (int i = 0, j = 0; i < matrix.GetLength(0); i++, j++)
            {
                if (mx < matrix[i, j])
                {
                    res = j; mx = matrix[i, j];
                }
            }
            return res;
        }
        int FindFirstRowMaxIndex(int[,] matrix)
        {
            int res = 0, mx = -10000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (mx < matrix[0, i])
                {
                    res = i; mx = matrix[0, i];
                }
            }
            return res;
        }
        void SwapColumns(int[,] matrix, FindElement findElementDiag, FindElement findElementRow)
        {
            int n = matrix.GetLength(0);
            int c1 = findElementDiag(matrix), c2 = findElementRow(matrix);
            for (int i = 0; i<n; i++)
            {
                (matrix[i, c1], matrix[i, c2]) = (matrix[i, c2], matrix[i, c1]);
            }
        }
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        // end
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

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
        (int, int) FindDiagonalMaxIndex(int[,] matrix)
        {
            int mx = -1000000000, row = 0, col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j]; row = i; col = j;
                    }
                }
            }
            return (row, col);
        }
        (int, int) FindDiagonalMinIndex(int[,] matrix)
        {
            int mx = -1000000000, row = 0, col = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j]; row = i; col = j;
                    }
                }
            }
            return (row, col);
        }
        void RemoveColumn(ref int[,] matrix, int columnIndex)
        {
            int[,] mat = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == columnIndex) continue;
                    if (j > columnIndex)
                    {
                        mat[i, j - 1] = matrix[i, j];
                    }
                    else
                    {
                        mat[i, j] = matrix[i, j];
                    }
                }
            }
            matrix = mat;
        }
        void RemoveColumns(ref int[,] matrix, FindIndex DiagMax, FindIndex DiagMin)
        {
            int row1, col1, row2, col2;
            (row1, col1) = DiagMax(matrix); (row2, col2) = DiagMin(matrix);
            if (col1 > col2)
            {
                (col1, col2) = (col2, col1);
            }
            RemoveColumn(ref matrix, col1); if (col1 != col2) RemoveColumn(ref matrix, col2 - 1);
        }
        RemoveColumns(ref matrix, FindDiagonalMaxIndex, FindDiagonalMinIndex);
        printM(matrix);

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public delegate int[] GetNegativeArray(int[,] matrix);
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);
        int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[rowIndex, i] < 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }
        int FindMaxNegativePerColumn(int[,] matrix, int colIndex)
        {
            int mx = -1000000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (mx < matrix[i, colIndex] && matrix[i, colIndex] < 0)
                {
                    mx = matrix[i, colIndex];
                }
            }
            return mx;
        }
        int[] searcherRows(int[,] matrix)
        {
            int[] rows = new int[matrix.GetLength(0)];
            Count Neg = CountNegativeInRow;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                rows[i] = Neg(matrix, i);
            }
            return rows;
        }
        int[] searcherCols(int[,] matrix)
        {
            int[] cols = new int[matrix.GetLength(1)];
            Count Neg = FindMaxNegativePerColumn;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                cols[i] = Neg(matrix, i);
            }
            return cols;
        }
        void FindNegatives(int[,] matrix, GetNegativeArray SR, GetNegativeArray SC, out int[] rows, out int[] cols)
        {
            rows = new int[matrix.GetLength(0)];
            cols = new int[matrix.GetLength(1)];
            rows = SR(matrix); cols = SC(matrix);
        }
        FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
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

    public delegate int IsSequence(int[] array, int index1, int index2);
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
        int FindIncreasingSequence(int[] array, int A, int B)
        {
            bool inc = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] < array[i - 1])
                {
                    inc = false; break;
                }
            }
            if (inc) return 1;
            return 0;
        }
        int FindDecreasingSequence(int[] array, int A, int B)
        {
            bool decr = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] > array[i - 1])
                {
                    decr = false; break;
                }
            }
            if (decr) return 1;
            return 0;
        }
        int DefineSequence(int[] array, IsSequence A, IsSequence B)
        {
            int inc = A(array, 0, array.Length - 1), decr = B(array, 0, array.Length - 1);
            if (inc == 0 && decr == 1) return -1;
            if (inc == 1 && decr == 0) return 1;
            return 0;
        }
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
        // end
    }

    public delegate int Sequence(int[] array, int A, int B);
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);
        int FindIncreasingSequence(int[] array, int A, int B)
        {
            bool inc = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] < array[i - 1])
                {
                    inc = false; break;
                }
            }
            if (inc) return 1;
            return 0;
        }
        int FindDecreasingSequence(int[] array, int A, int B)
        {
            bool decr = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] > array[i - 1])
                {
                    decr = false; break;
                }
            }
            if (decr) return 1;
            return 0;
        }
        int[] FindLongestSequence(int[] arr, Sequence F)
        {
            int len = -1, l = 0, r = 0;
            for (int i = 0; i < arr.Length; i++){
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (F(arr, i, j) == 1 && j - i > len)
                    {
                        len = j - i; l = i; r = j;
                    }
                }
            }
            int[] ret = new int[] { l, r };
            return ret;
        }
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

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
