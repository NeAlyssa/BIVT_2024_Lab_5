using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (n != 0 && k <= n && k >= 0)
        {
            answer = Combinations(n, k);
        }
        // create and use Combinations(n, k);
        static int Combinations(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        // create and use Factorial(n);
        static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 2; i < n; i++)
            {
                fact *= i;
            }
            return fact;
        }

        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double s1 = GeronAria(first[0], first[1], first[2]);
        double s2 = GeronAria(second[0], second[1], second[2]);
        if (s1 == -1 || s2 == -1) answer = -1;
        else if (s1 > s2) answer = 1;
        else if (s1 == s2) answer = 0;
        else answer = 2;

        // create and use GeronArea(a, b, c);
        static double GeronAria(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            if (a + b > c && a + c > b && b + c > a)
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            else return -1;
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
            return v * t + a * t * t / 2;
        }

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        for (int t = 1; ; t++)
        {
            double s1 = GetDistance(v1, a1, t);
            double s2 = GetDistance(v2, a2, t);
            if (s2 >= s1)
            {
                answer = t;
                break;
            }
        }

        // use GetDistance(v, a, t); t - hours
        static double GetDistance(double v, double a, int t)
        {
            return v * t + a * t * t / 2;
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
        int amax = FindMaxIndex(A);
        int bmax = FindMaxIndex(B);
        if ((7 - amax) > (9 - bmax))
        {
            A = ReplaceMaxSr(amax, A);
        }
        else B = ReplaceMaxSr(bmax, B);

        // create and use FindMaxIndex(array);
        static int FindMaxIndex(double[] array)
        {
            int imax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[imax]) imax = i;
            }
            return imax;
        }

        static double[] ReplaceMaxSr(int imax, double[] array)
        {
            double sum = 0, k = 0;
            for (int i = imax + 1; i < array.Length; i++)
            {
                sum += array[i];
                k++;
            }
            if (k != 0) array[imax] = sum / k;
            return array;
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
        int amax = FindDiagonalMaxIndex(A);
        int bmax = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int p = A[amax, i];
            A[amax, i] = B[i, bmax];
            B[i,bmax] = p;
        }

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        static int FindDiagonalMaxIndex(int[,] matrix)
        {
            int imax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i] > matrix[imax,imax]) imax = i;
            }
            return imax;
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
        A = DeleteElement(A, FindMax(A));
        B = DeleteElement(B, FindMax(B));
        int[] C = new int[13];
        int i = 0;
        while (i < 6)
        {
            C[i] = A[i];
            i++;
        }
        while (i < 13)
        {
            C[i] = B[i - 6];
            i++;
        }
        A = C;

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        static int FindMax(int[] array)
        {
            int imax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[imax]) imax = i;
            }
            return imax;
        }

        // create and use DeleteElement(array, index);
        static int[] DeleteElement(int[] array, int index)
        {
            int[] A = new int[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < index) A[i] = array[i];
                else if (i > index) A[i - 1] = array[i];
            }
            return A;
        }

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
        A = SortArrayPart(A, FindMax(A) + 1);
        B = SortArrayPart(B, FindMax(B) + 1);

        // create and use SortArrayPart(array, startIndex);
        static int[] SortArrayPart(int[] array, int startIndex)
        {
            for (int i = startIndex; i < array.Length; i++)
            {
                for (int j = startIndex; j < array.Length - 1 - i + startIndex; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int p = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = p;
                    }
                }
            }
            return array;
        }

        static int FindMax(int[] array)
        {
            int imax = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[imax]) imax = i;
            }
            return imax;
        }

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
        int n = matrix.GetLength(0);
        int jmax = 0, jmin = 0, imin = 0, imax = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (matrix[i,j] > matrix[imax, jmax])
                {
                    imax = i;
                    jmax = j;
                }
            }
            for (int j = i + 1; j < n; j++)
            {
                if (matrix[i, j] < matrix[imin, jmin])
                {
                    imin = i;
                    jmin = j;
                }
            }
        }
        matrix = RemoveColumn(matrix, Math.Max(jmin, jmax));
        if (jmin != jmax) matrix = RemoveColumn(matrix, Math.Min(jmin, jmax));

        // create and use RemoveColumn(matrix, columnIndex);
        static int[,] RemoveColumn(int[,] matrix, int columnIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] A = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < columnIndex) A[i, j] = matrix[i, j];
                    else if (j > columnIndex) A[i, j - 1] = matrix[i, j];
                }
            }
            return A;
        }

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
        int amax = FindMaxColumnIndex(A);
        int bmax = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int p = A[i, amax];
            A[i, amax] = B[i, bmax];
            B[i, bmax] = p;
        }

        // create and use FindMaxColumnIndex(matrix);
        static int FindMaxColumnIndex(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int jmax = 0, imax = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[imax, jmax])
                    {
                        imax = i;
                        jmax = j;
                    }
                }
            }
            return jmax;
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
            SortRow(ref matrix, i);
        }

        // create and use SortRow(matrix, rowIndex);
        static void SortRow(ref int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(1);
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n - 1 - j; k++)
                {
                    if (matrix[rowIndex, k] > matrix[rowIndex, k + 1])
                    {
                        int p = matrix[rowIndex, k];
                        matrix[rowIndex, k] = matrix[rowIndex, k + 1];
                        matrix[rowIndex, k + 1] = p;
                    }
                }
            }
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
        SortNegative(ref A);
        SortNegative(ref B);

        // create and use SortNegative(array);
        static void SortNegative(ref int[] array)
        {
            int c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) c++;
            }

            int[] A = new int[c];
            c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) A[c++] = array[i];
            }
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length - 1 - i; j++)
                {
                    if (A[j] < A[j + 1])
                    {
                        int p = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = p;
                    }
                }
            }
            c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) array[i] = A[c++];
            }
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
        SortDiagonal(ref A);
        SortDiagonal(ref B);

        // create and use SortDiagonal(matrix);
        static void SortDiagonal(ref int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (matrix[j, j] > matrix[j + 1, j + 1])
                    {
                        int p = matrix[j, j];
                        matrix[j, j] = matrix[j + 1, j + 1];
                        matrix[j + 1, j + 1] = p;
                    }
                }
            }
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
        RemoveAll(ref A);
        RemoveAll(ref B);

        // use RemoveColumn(matrix, columnIndex); from 2_10
        static int[,] RemoveColumn(int[,] matrix, int columnIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] A = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < columnIndex) A[i, j] = matrix[i, j];
                    else if (j > columnIndex) A[i, j - 1] = matrix[i, j];
                }
            }
            return A;
        }

        static void RemoveAll(ref int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j = m - 1; j >= 0; j--)
            {
                int c = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        c++;
                        break;
                    }
                }
                if (c == 0) matrix = RemoveColumn(matrix, j);
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

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            cols[i] = FindMaxNegativePerColumn(matrix, i);
        }

        // create and use CountNegativeInRow(matrix, rowIndex);
        static int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int c = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] < 0) c++;
            }
            return c;
        }

        // create and use FindMaxNegativePerColumn(matrix);
        static int FindMaxNegativePerColumn(int[,] matrix, int colIndex)
        {
            int imax = -1, max = -99999;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, colIndex] > max && matrix[i, colIndex] < 0)
                {
                    imax = i;
                    max = matrix[imax, colIndex];
                }
            }
            return max;
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
        int row = 0, column = 0;
        FindMaxIndex(A, out row, out column);
        SwapColumnDiagonal(A, column);
        FindMaxIndex(B, out row, out column);
        SwapColumnDiagonal(B, column);

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        static void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            row = 0;
            column = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, column])
                    {
                        row = i;
                        column = j;
                    }
                }
            }
        }

        // create and use SwapColumnDiagonal(matrix, columnIndex);
        static void SwapColumnDiagonal(int[,] matrix, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int p = matrix[i, columnIndex];
                matrix[i, columnIndex] = matrix[i, i];
                matrix[i, i] = p;
            }
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
        int amax = FindRowWithMaxNegativeCount(A);
        int bmax = FindRowWithMaxNegativeCount(B);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int p = A[amax, i];
            A[amax, i] = B[bmax, i];
            B[bmax, i] = p;
        }

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        static int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int imax = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (CountNegativeInRow(matrix, i) > CountNegativeInRow(matrix, imax)) imax = i;
            }
            return imax;
        }

        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22
        static int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int c = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] < 0) c++;
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
        // A and B - start and end indexes of elements from array for search
        static int FindSequence(int[] array, int A, int B)
        {
            int k = 10, c = 10;
            for (int i = A; i < B; i++)
            {
                if (array[i] > array[i + 1]) k = -1;
                else if (array[i] < array[i + 1]) k = 1;
                if (k != c && c != 10)
                {
                    k = 0;
                    break;
                }
                c = k;
            }
            return k;
        }

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        answer(first, ref answerFirst);
        answer(second, ref answerSecond);

        static void answer(int[] array, ref int[,] answer)
        {
            int ind1 = 0, count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int t = FindSequence(array, i, j);
                    if (t != 0) count++;
                    else break;
                }
            }
            answer = new int[count, 2];

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int t = FindSequence(array, i, j);
                    if (t != 0)
                    {
                        answer[ind1, 0] = i;
                        answer[ind1, 1] = j;
                        ind1++;
                    }
                    else break;
                }
            }
        }

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search
        static int FindSequence(int[] array, int A, int B)
        {
            int k = 10, c = 10;
            for (int i = A; i < B; i++)
            {
                if (array[i] > array[i + 1]) k = -1;
                else if (array[i] < array[i + 1]) k = 1;
                if (k != c && c != 10)
                {
                    k = 0;
                    break;
                }
                c = k;
            }
            return k;
        }

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        answer(first, ref answerFirst);
        answer(second, ref answerSecond);

        static void answer(int[] array, ref int[] answer)
        {
            answer = new int[2];
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int t = FindSequence(array, i, j);
                    if (t != 0 && answer[1] - answer[0] < j - i)
                    {
                        answer[0] = i;
                        answer[1] = j;
                    }
                    else if (t == 0) break;
                }
            }
        }

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search
        static int FindSequence(int[] array, int A, int B)
        {
            int k = 10, c = 10;
            for (int i = A; i < B; i++)
            {
                if (array[i] > array[i + 1]) k = -1;
                else if (array[i] < array[i + 1]) k = 1;
                if (k != c && c != 10)
                {
                    k = 0;
                    break;
                }
                c = k;
            }
            return k;
        }

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

    public delegate void SortRowStyle(int[,] matrix, int rowIndex);

    public void Task_3_2(int[,] matrix)
    {

        SortRowStyle sortStyle;

        for (int i = 0;  i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0) sortStyle = SortAscending;
            else sortStyle = SortDescending;
            sortStyle(matrix, i);
        }

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        static void SortAscending(int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(1);
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n - 1 - j; k++)
                {
                    if (matrix[rowIndex, k] > matrix[rowIndex, k + 1])
                    {
                        int p = matrix[rowIndex, k];
                        matrix[rowIndex, k] = matrix[rowIndex, k + 1];
                        matrix[rowIndex, k + 1] = p;
                    }
                }
            }
        }

        static void SortDescending(int[,] matrix, int rowIndex)
        {
            int n = matrix.GetLength(1);
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n - 1 - j; k++)
                {
                    if (matrix[rowIndex, k] < matrix[rowIndex, k + 1])
                    {
                        int p = matrix[rowIndex, k];
                        matrix[rowIndex, k] = matrix[rowIndex, k + 1];
                        matrix[rowIndex, k + 1] = p;
                    }
                }
            }
        }
        // change method in variable sortStyle in the loop here and use it for row sorting

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

    public delegate int[] GetTriangle(int[,] matrix);

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here
        if (isUpperTriangle) answer = GetSum(GetUpperTriange, matrix);
        else answer = GetSum(GetLowerTriange, matrix);

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        static int[] GetUpperTriange(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] arr = new int[n * (n + 1) / 2];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    arr[k++] = matrix[i, j];
                }
            }
            return arr;
        }

        static int[] GetLowerTriange(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int[] arr = new int[n * (n + 1) / 2];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    arr[k++] = matrix[i, j];
                }
            }
            return arr;
        }

        // create and use GetSum(GetTriangle, matrix)
        static int GetSum(GetTriangle operation, int[,] matrix)
        {
            int[] arr = operation(matrix);
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i * i;
            }
            return sum;
        }

        // end

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

    public delegate int FindElementDelegate(int[,] matrix);

    public void Task_3_6(int[,] matrix)
    {
        // code here
        SwapColumns(ref matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        static int FindDiagonalMaxIndex(int[,] matrix)
        {
            int imax = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > matrix[imax, imax]) imax = i;
            }
            return imax;
        }

        // create and use method FindFirstRowMaxIndex(matrix);
        static int FindFirstRowMaxIndex(int[,] matrix)
        {
            int imax = 0;
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                if (matrix[0, i] > matrix[0, imax]) imax = i;
            }
            return imax;
        }

        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        static void SwapColumns(ref int[,] matrix, FindElementDelegate diag, FindElementDelegate row)
        {
            int col1 = row(matrix);
            int col2 = diag(matrix);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int p = matrix[i, col1];
                matrix[i, col1] = matrix[i, col2];
                matrix[i, col2] = p;
            }
        }

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

    public delegate int FindIndex(int[,] matrix);

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);


        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        static int FindMaxBelowDiagonalIndex(int[,] matrix)
        {
            int jmax = 0, imax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (matrix[i, j] > matrix[imax, jmax])
                    {
                        imax = i;
                        jmax = j;
                    }
                }
            }
            return jmax;
        }

        // create and use method FindMinAboveDiagonalIndex(matrix);
        static int FindMinAboveDiagonalIndex(int[,] matrix)
        {
            int jmax = 0, jmin = 0, imin = 0, imax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] < matrix[imin, jmin])
                    {
                        imin = i;
                        jmin = j;
                    }
                }
            }
            return jmin;
        }

        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        static int[,] RemoveColumn(int[,] matrix, int columnIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] A = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < columnIndex) A[i, j] = matrix[i, j];
                    else if (j > columnIndex) A[i, j - 1] = matrix[i, j];
                }
            }
            return A;
        }

        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
        static void RemoveColumns(ref int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
        {
            int j1 = findMaxBelowDiagonalIndex(matrix);
            int j2 = findMinAboveDiagonalIndex(matrix);
            matrix = RemoveColumn(matrix, Math.Max(j1, j2));
            if (j1 != j2) matrix = RemoveColumn(matrix, Math.Min(j1, j2));
        }

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public delegate int GetNegativeArray(int[,] matrix, int index);

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        FindNegatives(matrix, CountNegativeInRow, FindMaxNegativePerColumn, ref rows, ref cols);


        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        static int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int c = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] < 0) c++;
            }
            return c;
        }

        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        static int FindMaxNegativePerColumn(int[,] matrix, int colIndex)
        {
            int imax = -1, max = -99999;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, colIndex] > max && matrix[i, colIndex] < 0)
                {
                    imax = i;
                    max = matrix[imax, colIndex];
                }
            }
            return max;
        }
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);
        static void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, ref int[] rows, ref int[] cols)
        {
            int IndexRow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int r = searcherRows(matrix, i);
                rows[IndexRow++] = r;
            }
            int IndexCol = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int c = searcherCols(matrix, i);
                cols[IndexCol++] = c;
            }
        }

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

    public delegate bool IsSequence(int[] array, int left, int right);

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        static bool FindIncreasingSequence(int[] array, int A, int B)
        {
            bool k = true;
            for (int i = A; i < B; i++)
            {
                if (array[i] > array[i + 1])
                {
                    k = false;
                    break;
                }
            }
            return k;
        }

        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        static bool FindDecreasingSequence(int[] array, int A, int B)
        {
            bool k = true;
            for (int i = A; i < B; i++)
            {
                if (array[i] < array[i + 1])
                {
                    k = false;
                    break;
                }
            }
            return k;
        }

        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
        static int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
        {
            if (FindIncreasingSequence(array, 0, array.Length - 1)) return 1;
            if (FindDecreasingSequence(array, 0, array.Length - 1)) return -1;
            return 0;
        }

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        static bool FindIncreasingSequence(int[] array, int A, int B)
        {
            bool k = true;
            for (int i = A; i < B; i++)
            {
                if (array[i] > array[i + 1])
                {
                    k = false;
                    break;
                }
            }
            return k;
        }

        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        static bool FindDecreasingSequence(int[] array, int A, int B)
        {
            bool k = true;
            for (int i = A; i < B; i++)
            {
                if (array[i] < array[i + 1])
                {
                    k = false;
                    break;
                }
            }
            return k;
        }

        // create and use method FindLongestSequence(array, sequence);
        static int[] FindLongestSequence(int[] array, IsSequence sequence)
        {
            int[] answer = new int[2];
            for (int i = 0;  i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (sequence(array, i, j) && answer[1] - answer[0] < j - i)
                    {
                        answer[0] = i;
                        answer[1] = j;
                    }
                }
            }
            return answer;
        }

        // end
    }
    #endregion
    #region bonus part

    public delegate double[,] MatrixConverter(double[,] matrix);

    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];

        // code here
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;

        matrix = mc[index](matrix);

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        double[,] ToUpperTriangular(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int j = 0; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    double p = matrix[k, j] / matrix[j, j];
                    for (int m = j; m < n; m++)
                    {
                        matrix[k, m] -= p * matrix[j, m];
                    }
                }
            }
            return matrix;
        }

        // create and use method ToLowerTriangular(matrix);
        double[,] ToLowerTriangular(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double p = matrix[i, j];
                    matrix[i, j] = matrix[n - i - 1, n - j - 1];
                    matrix[n - i - 1, n - j - 1] = p;
                }
            }
            for (int i = 0; i < n / 2; i++)
            {
                double p = matrix[i, i];
                matrix[i, i] = matrix[n - i - 1, n - i - 1];
                matrix[n - i - 1, n - i - 1] = p;
            }

            for (int j = 0; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    double p = matrix[k, j] / matrix[j, j];
                    for (int m = j; m < n; m++)
                    {
                        matrix[k, m] -= p * matrix[j, m];
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double p = matrix[i, j];
                    matrix[i, j] = matrix[n - i - 1, n - j - 1];
                    matrix[n - i - 1, n - j - 1] = p;
                }
            }
            for (int i = 0; i < n / 2; i++)
            {
                double p = matrix[i, i];
                matrix[i, i] = matrix[n - i - 1, n - i - 1];
                matrix[n - i - 1, n - i - 1] = p;
            }
            return matrix;
        }

        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        double[,] ToLeftDiagonal(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int j = 0; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    double p = matrix[k, j] / matrix[j, j];
                    for (int m = j; m < n; m++)
                    {
                        matrix[k, m] -= p * matrix[j, m];
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double p = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = p;
                }
            }

            for (int j = 0; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    double p = matrix[k, j] / matrix[j, j];
                    for (int m = j; m < n; m++)
                    {
                        matrix[k, m] -= p * matrix[j, m];
                    }
                }
            }
            return matrix;
        }

        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle
        double[,] ToRightDiagonal(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    double p = matrix[n - j - 1, n - i - 1];
                    matrix[n - j - 1, n - i - 1] = matrix[i, j];
                    matrix[i, j] = p;
                }
            }

            for (int j = 0; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    double p = matrix[k, j] / matrix[j, j];
                    for (int m = j; m < n; m++)
                    {
                        matrix[k, m] -= p * matrix[j, m];
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double p = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = p;
                }
            }

            for (int j = 0; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    double p = matrix[k, j] / matrix[j, j];
                    for (int m = j; m < n; m++)
                    {
                        matrix[k, m] -= p * matrix[j, m];
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    double p = matrix[n - j - 1, n - i - 1];
                    matrix[n - j - 1, n - i - 1] = matrix[i, j];
                    matrix[i, j] = p;
                }
            }
            return matrix;
        }

        // end

        return matrix;
    }
    #endregion
}
