using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
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
        if (n <= 0 || k <= 0) return answer;
        answer = Combinations(n, k);
        // create and use Combinations(n, k);
        int Combinations(int n, int k)
        {
            int j = Factorial(n) / (Factorial(k) * Factorial(n - k));
            return j;

        }
        // create and use Factorial(n);
        int Factorial(int n)
        {
            int l = 1;
            for (int i = 2; i < n; i++)
            {
                l *= i;
            }
            return l;

        }
        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        if (first == null || second == null) return answer;
        double f = GeronArea(first[0], first[1], first[2]);
        double s = GeronArea(second[0], second[1], second[2]);
        if (f < 0 || s < 0) { answer = -1; }
        else if (f < s)
        {
            answer = 2;
        }
        else if (f > s)
        {
            answer = 1;
        }
        else answer = 0;
        // create and use GeronArea(a, b, c);
        double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            if (p <= a || p <= b || p <= c) return -1;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double f = GetDistance(v1, a1, time);
        double s = GetDistance(v2, a2, time);
        if (f == s) return 0;
        else if (f > s) return 1;
        else if (f < s) return 2;
        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    double GetDistance(double v, double a, double t)
    {
        if (t < 0) return 0;
        double S = v * t + a * t * t / 2;
        return S;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        answer = 1;
        while (GetDistance(v1 - v2, a1 - a2, answer) > 0) answer++;

        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        double sum = 0;
        double n = 0;
        int a1 = FindMaxIndex(A);
        int a2 = FindMaxIndex(B);
        double[] a;
        int maxi = 0;
        if (A.Length - a1 > B.Length - a2)
        {
            a = A;
            maxi = a1;
        }
        else
        {
            a = B;
            maxi = a2;
        }
        for (int i = maxi + 1; i < a.Length; i++)
        {
            sum += a[i];
            n++;
        }
        for (int t = 0; t < a.Length; t++) { if (a[t] == a[maxi]) a[t] = sum / n; }
    }

    // create and use FindMaxIndex(array);
    int FindMaxIndex(double[] array)
    {
        int maxim = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxim]) maxim = i;
        }
        return maxim;
    }
    // end


    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int iA = FindDiagonalMaxIndex(A);
        int iB = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[iA, i];
            A[iA, i] = B[i, iB];
            B[i, iB] = temp;
        }
    }
    //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxim = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > matrix[maxim, maxim]) maxim = i;
        }
        return maxim;
    }
    // end


    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int maxima = FindMax(A);
        int maximb = FindMax(B);
        int[] a = DeleteElement(A, maxima);
        int[] b = DeleteElement(B, maximb);
        int[] ans = new int[a.Length + b.Length];
        int n = 0;
        for (int i = 0; i < a.Length; i++) { ans[n++] = a[i]; }
        for (int i = 0; i < b.Length; i++) { ans[n++] = b[i]; }
        A = ans;
        // FindMax(array);
        int FindMax(int[] array)
        {
            int maxima = 0, maximb = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[maxima]) maxima = i;
            }
            return maxima;
        }
        // create and use DeleteElement(array, index);
        int[] DeleteElement(int[] array, int index)
        {
            int[] a = new int[array.Length - 1];
            for (int i = 0; i < a.Length; i++)
            {
                if (i < index) a[i] = array[i];
                else a[i] = array[i + 1];
            }
            return a;
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
        int FindMax(int[] array)
        {
            int maxim = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[maxim]) maxim = i;
            }
            return maxim;
        }
        // create and use SortArrayPart(array, startIndex);
        int[] SortArrayPart(int[] array, int startIndex)
        {
            for (int i = 0; i < array.Length - startIndex; i++)
            {
                for (int j = startIndex; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
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
        int maxim_stolb = 0, maxim_strok = 0;
        int minim_stolb = 0, minim_strok = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[maxim_strok, maxim_stolb] && i >= j) { maxim_stolb = j; maxim_strok = i; }
                if (matrix[i, j] > matrix[maxim_strok, minim_stolb] && i < j) { minim_stolb = j; minim_strok = i; }

            }
        }
        int a = Math.Max(maxim_stolb, minim_stolb);
        int b = Math.Min(maxim_stolb, minim_stolb);
        RemoveColumn(ref matrix, a);
        if (a != b)
        {
            RemoveColumn(ref matrix, b);


        }
    }
    // create and use RemoveColumn(matrix, columnIndex);
    void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] ans = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];

        for (int j = 0; j < columnIndex; j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ans[i, j] = matrix[i, j];
            }
        }

        for (int j = columnIndex; j < ans.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ans[i, j] = matrix[i, j + 1];
            }
        }

        matrix = ans;
    }


    // end


    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int maxim_a = FindMaxColumnIndex(A);
        int maxim_b = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[i, maxim_a];
            A[i, maxim_a] = B[i, maxim_b];
            B[i, maxim_b] = temp;
        }
        // create and use FindMaxColumnIndex(matrix);
        int FindMaxColumnIndex(int[,] matrix)
        {
            int maxim_i = 0, maxim_j = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[maxim_i, maxim_j]) { maxim_i = i; maxim_j = j; }

                }
            }
            return maxim_j;
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
            SortRow(matrix, i);
        }
    }
    // create and use SortRow(matrix, rowIndex);
    void SortRow(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1]) (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
            }
        }
    }
    // end


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
        int[] SortNegative(int[] array)
        {
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) n++;
            }
            int[] ans = new int[n];
            n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) { ans[n++] = array[i]; }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (ans[j] < ans[j + 1]) (ans[j], ans[j + 1]) = (ans[j + 1], ans[j]);
                }
            }
            n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) { array[i] = ans[n++]; }
            }
            return array;
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
        SortDiagonal(A);
        SortDiagonal(B);
        // create and use SortDiagonal(matrix);
        void SortDiagonal(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
                {
                    if (matrix[j, j] > matrix[j + 1, j + 1]) { (matrix[j, j], matrix[j + 1, j + 1]) = (matrix[j + 1, j + 1], matrix[j, j]); }
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
        A = NegativeIndex(ref A);
        B = NegativeIndex(ref B);
        // use RemoveColumn(matrix, columnIndex); from 2_10
        int[,] NegativeIndex(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                bool n = false;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] == 0) { n = true; break; }
                }
                if (!n) { RemoveColumn(ref matrix, i); i--; }
            }
            return matrix;
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
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        cols = FindMaxNegativePerColumn(matrix);
    }
    // create and use CountNegativeInRow(matrix, rowIndex);
    int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int n = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] < 0) n++;
        }
        return n;

    }
    // create and use FindMaxNegativePerColumn(matrix);
    int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int maxim = int.MinValue;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] < 0 && matrix[j, i] > maxim) maxim = matrix[j, i];
            }
            ans[i] = maxim;
        }
        return ans;
    }
    // end


    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        int row, column;
        FindMaxIndex(A, out row, out column);
        SwapColumnDiagonal(A, column);
        FindMaxIndex(B, out row, out column);
        SwapColumnDiagonal(B, column);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            row = 0; column = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[row, column]) { row = i; column = j; }
                }
            }
        }
    }

    // create and use SwapColumnDiagonal(matrix, columnIndex);
    void SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = temp;
        }
    }
    // end


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
        int a = FindRowWithMaxNegativeCount(A);
        int b = FindRowWithMaxNegativeCount(B);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[a, j];
            A[a, j] = B[b, j];
            B[b, j] = temp;
        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int maxim = 0, maxim_minus = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minus = CountNegativeInRow(matrix, i);
                if (minus > maxim_minus)
                {
                    maxim_minus = minus;
                    maxim = i;
                }
            }
            return maxim;
        }
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

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
    }
    // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
    int FindSequence(int[] array, int A, int B)
    {
        if (A >= B) return 0;
        for (int i = A; i < B; i++)
        {
            if ((array[A] < array[A + 1] && array[i] > array[i + 1])) return 0;
            if (array[A] >= array[A + 1] && array[i] < array[i + 1]) return 0;
        }
        if (array[A] < array[A + 1]) return 1;
        else return -1;
    }
    // A and B - start and end indexes of elements from array for search

    // end


    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        answerFirst = Finish(first);
        answerSecond = Finish(second);
        int[,] Finish(int[] array)
        {
            int[,] answer;
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int a = FindSequence(array, i, j);
                    if (a != 0) n++;
                }
            }
            answer = new int[n, 2];
            n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int a = FindSequence(array, i, j);
                    if (a != 0)
                    {
                        answer[n, 0] = i;
                        answer[n, 1] = j;
                        n++;
                    }
                }
            }
            return answer;
        }


        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        answerFirst = Answer(first);
        answerSecond = Answer(second);
        int[] Answer(int[] array)
        {
            int a = 0, b = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int s = FindSequence(array, i, j);
                    if (s != 0 && b - a < j - i)
                    {
                        a = i;
                        b = j;
                    }
                }
            }
            int[] answer = new int[] { a, b };
            return answer;
        }
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
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
    void SortAscending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = temp;
                }
            }
        }
    }
    void SortDescending(int[,] matrix, int rowIndex)
    {

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = temp;
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

        // code here
        if (isUpperTriangle) answer = GetSum(GetUpperTriange, matrix);
        else answer = GetSum(GetLowerTriange, matrix);
        return answer;
    }
    // create and use public delegate GetTriangle(matrix);
    public delegate int[] GetTriangle(int[,] matrix);
    // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
    int[] GetUpperTriange(int[,] matrix)
    {
        int[] a = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                a[index++] = matrix[i, j];
            }
        }
        return a;
    }
    int[] GetLowerTriange(int[,] matrix)
    {
        int[] a = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                a[index++] = matrix[i, j];
            }
        }
        return a;
    }
    // create and use GetSum(GetTriangle, matrix)
    int GetSum(GetTriangle GetTriangle, int[,] matrix)
    {
        int[] ans = GetTriangle(matrix);
        int a = 0;
        for (int i = 0; i < ans.Length; i++)
        {
            a += ans[i] * ans[i];
        }
        return a;
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
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
    }
    public delegate int FindElementDelegate(int[,] matrix);

    // create and use public delegate FindElementDelegate(matrix);
    // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;

    // create and use method FindFirstRowMaxIndex(matrix)
    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int maxim = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > matrix[0, maxim]) maxim = j;
        }
        return maxim;
    }
    // FindFirstRowMaxIndex(matrix);
    // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
    void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int max = findDiagonalMaxIndex(matrix);
        int max1 = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, max];
            matrix[i, max] = matrix[i, max1];
            matrix[i, max1] = temp;
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

    public void Task_3_10(ref int[,] matrix)
    {
        // code here
        FindIndex searchArea = default(FindIndex);
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
    }
    // create and use public delegate FindIndex(matrix);
    public delegate int FindIndex(int[,] matrix);
    // create and use method FindMaxBelowDiagonalIndex(matrix)
    int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int maxi = 0, maxj = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > matrix[maxi, maxj])
                {
                    maxi = i;
                    maxj = j;
                }
            }
        }
        return maxj;
    }
    // create and use method FindMinAboveDiagonalIndex(matrix);
    int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int mini = 0, minj = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[mini, minj])
                {
                    mini = i;
                    minj = j;
                }
            }

        }
        return minj;
    }
    // use RemoveColumn(matrix, columnIndex) from Task_2_10
    // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
    void RemoveColumns(ref int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int a = findMaxBelowDiagonalIndex(matrix);
        int b = findMinAboveDiagonalIndex(matrix);
        if (a > b)
            (a, b) = (b, a);
        RemoveColumn(ref matrix, b);
        if (a != b)
            RemoveColumn(ref matrix, a);
    }

    // end


    public void Task_3_13(ref int[,] matrix)
    {
        // use RemoveColumn(matrix, columnIndex) from Task_2_10

        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
    }
    // use public delegate FindElementDelegate(matrix) from Task_3_6
    // create and use method RemoveRows(matrix, findMax, findMin)

    // end


    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;
        // code here

        FindNegatives(matrix, Answer, FindMaxNegativePerColumn, out rows, out cols);
    } 
    public delegate int [] GetNegativeArray(int [,]matrix);
    int[] Answer(int[,] matrix)
    {
        int[] rc = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rc[i] = CountNegativeInRow(matrix, i);
        }
        return rc;
    }
    void FindNegatives(int[,]matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int [] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols =searcherCols(matrix);
    }
        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);
        
    // end
    

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
        answerFirst = DefineSequence(first, FindInreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindInreasingSequence, FindDecreasingSequence);
    }
    // create public delegate IsSequence(array, left, right);
    public delegate bool IsSequence(int []array, int left, int right);
     // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
    bool FindInreasingSequence(int [] array, int A, int B)
    {
        return FindSequence(array, A, B)==1;
    }
    // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
    bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == -1;
    }
    // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
    int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        int b = array.Length - 1;
        if (findIncreasingSequence(array, 0, b)) return 1;
        if (findDecreasingSequence(array, 0, b)) return -1;
        return 0;
    }


    // end


    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        answerFirstIncrease = FindLongestSequence(first, FindInreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindInreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
    }
    // create and use method FindLongestSequence(array, sequence);
    public int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int a = 0, b = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j) && j - i > b - a) { a = i; b = j; }
            }

        }
        return [a, b];
    }
    // create public delegate IsSequence(array, left, right);
    // use method FindIncreasingSequence(array, A, B); from Task_3_28a
    // use method FindDecreasingSequence(array, A, B); from Task_3_28a


    // end

    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        int n= matrix.GetLength(0);
        double[,] a = new double[n,n];
        for (int i = 0; i < n; i++)
        {
            for (int j=0;j< n; j++)
            {
                a[i,j] = matrix[i,j];
            }
        }
        MatrixConverter[] answer= new MatrixConverter[4];
        answer[0] = ToUpperTriangular;
        answer[1] = ToLowerTriangular;
        answer[2] = ToLeftDiagonal;
        answer[3] = ToRightDiagonal;
        answer[index](a);
        return a;
    }
    delegate void MatrixConverter(double [,]matrix);
    // create public delegate MatrixConverter(matrix);
    // create and use method ToUpperTriangular(matrix);
    void ToUpperTriangular(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(0); j++)
            {
                double c = -matrix[j,i]/matrix[i,i];
                for (int k = 0; k < matrix.GetLength(1); j++) matrix[j, k] += c * matrix[i, k];
            }
        }
    }
    // create and use method ToLowerTriangular(matrix);
    void ToLowerTriangular(double[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                double c = -matrix[j, i] / matrix[i, i];
                for (int k = 0; k < matrix.GetLength(1); j++) matrix[j, k] += c * matrix[i, k];
            }
            }
        }
    
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        void ToLeftDiagonal(double [,]matrix)
        {
        ToUpperTriangular(matrix);
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                double c = -matrix[j, i] / matrix[i, i];
                for (int k = 0; k < matrix.GetLength(1); j++) matrix[j, k] += c * matrix[i, k];
            }
        }
        }
    // create and use method ToRightDiagonal(matrix); - start from the right bottom angle
    void ToRightDiagonal(double [,]matrix)
    {
        ToLowerTriangular(matrix);
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                double c = -matrix[j, i] / matrix[i, i];
                for (int k = 0; k < matrix.GetLength(1); j++) matrix[j, k] += c * matrix[i, k];
            }
        }
    }
    // end


    #endregion
}
