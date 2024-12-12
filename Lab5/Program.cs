using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters;
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
        answer = Combitations(n, k);
        return answer;
    }
    int Combitations(int n, int k)
    {
        return Factorial(n) / Factorial(k) / Factorial(n - k);
    }
    int Factorial(int n)
    {
        int ans = 1;
        for (int i = 2; i <= n; i++)
            ans *= i;
        return ans;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        double t1 = GeronArea(first[0], first[1], first[2]);
        double t2 = GeronArea(second[0], second[1], second[2]);
        if (t1 == -1 || t2 == -1) return -1;
        if (t1 > t2) return 1;
        else if (t1 < t2) return 2;
        else return 0;
    }
    double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        if (p <= a || p <= b || p <= c) return -1;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        double d1 = GetDistance(v1, a1, time);
        double d2 = GetDistance(v2, a2, time);
        if (d1 == d2) return 0;
        else if (d1 > d2) return 1;
        else return 2;
    }
    double GetDistance(double v, double a, double t)
    {
        return v * t + a * t * t / 2;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 1;
        while (GetDistance(v1 - v2, a1 - a2, answer) > 0) answer++;
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
        int ai = FindMaxIndex(A);
        int bi = FindMaxIndex(B);
        double[] arr;
        int imax;
        if (A.Length - ai > B.Length - bi)
        {
            arr = A;
            imax = ai;
        }
        else 
        {
            arr = B;
            imax = bi;
        }
        double sr = 0, n = 0;
        for (int i = imax + 1; i < arr.Length; i++)
        {
            sr += arr[i];
            n += 1;
        }
        sr /= n;
        double max = arr[imax];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == max) arr[i] = sr;
        }
    }
    int FindMaxIndex(double[] array)
    {
        int imax = 0;
        for (int i = 1; i < array.Length; i++)
            if (array[i] > array[imax])
                imax = i;
        return imax;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        int ai = FindDiagonalMaxIndex(A);
        int bi = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[ai, i], B[i, bi]) = (B[i, bi], A[ai, i]);
        }
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0), imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > matrix[imax, imax]) imax = i;
        }
        return imax;
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        int ai = FindMax(A);
        int bi = FindMax(B);
        int[] a = DeleteElement(A, ai);
        int[] b = DeleteElement(B, bi);
        int[] ans = new int[a.Length + b.Length];
        int ind = 0;
        foreach (int x in a) ans[ind++] = x;
        foreach (int x in b) ans[ind++] = x;
        A = ans;
    }
    int FindMax(int[] array)
    {
        int imax = 0;
        for (int i = 0; i <  array.Length; i++)
            if (array[i] > array[imax])
                imax = i;
        return imax;
    }
    int[] DeleteElement(int[] array, int index)
    {
        int[] ans = new int[array.Length - 1];
        for (int i = 0; i < index; i++) ans[i] = array[i];
        for (int i = index; i < ans.Length; i++) ans[i] = array[i + 1];
        return ans;
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
        int ai = FindMax(A) + 1;
        int bi = FindMax(B) + 1;
        SortArrayPart(A, ai);
        SortArrayPart(B, bi);
    }
    void SortArrayPart(int[] array, int startIndex)
    {
        for (int i = 0; i < array.Length - startIndex; i++)
        {
            for (int j = startIndex; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
            }
        }
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
        int imaxX = 0, imaxY = 0;
        int iminX = 0, iminY = 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <  matrix.GetLength(1); j++)
            {
                if (i >= j && matrix[i, j] > matrix[imaxX, imaxY])
                {
                    imaxX = i;
                    imaxY = j;
                }
                if (i < j && matrix[i, j] < matrix[iminX, iminY])
                {
                    iminX = i;
                    iminY = j;
                }
            }
        }
        int del1 = Math.Max(imaxY, iminY);
        int del2 = Math.Min(imaxY, iminY);
        RemoveColumn(ref matrix, del1);
        if (del1 != del2)
            RemoveColumn(ref matrix, del2);
    }
    void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] ans = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int j = 0; j < columnIndex; j++)
            for (int i = 0; i < matrix.GetLength(0); i++)
                ans[i, j] = matrix[i, j];
        for (int j = columnIndex; j < ans.GetLength(1); j++)
            for (int i = 0; i < matrix.GetLength(0); i++)
                ans[i, j] = matrix[i, j + 1];
        matrix = ans;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        int aj = FindMaxColumnIndex(A);
        int bj = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[i, aj], B[i, bj]) = (B[i, bj], A[i, aj]);
        }
    }
    int FindMaxColumnIndex(int[,] matrix)
    {
        int imax = 0, jmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
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

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
        }
    }
    void SortRow(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
        }
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
        SortNegative(A);
        SortNegative(B);
    }
    void SortNegative(int[] array)
    {
        int n = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] < 0) n++;
        int[] temp = new int[n];
        int ind = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] < 0) temp[ind++] = array[i];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (temp[j] < temp[j + 1])
                    (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
        ind = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] < 0)
                array[i] = temp[ind++];
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        SortDiagonal(A);
        SortDiagonal(B);
    }
    void SortDiagonal(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (matrix[j, j] > matrix[j + 1, j + 1])
                {
                    (matrix[j, j], matrix[j + 1, j + 1]) = (matrix[j + 1, j + 1], matrix[j, j]);
                }
            }
        }
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        for (int j = 0; j < A.GetLength(1); j++)
        {
            bool hasZero = false;
            for (int i = 0; i < A.GetLength(0); i++)
                if (A[i, j] == 0) { hasZero = true; break; }
            if (!hasZero)
            {
                RemoveColumn(ref A, j);
                j--;
            }
        }
        for (int j = 0; j < B.GetLength(1); j++)
        {
            bool hasZero = false;
            for (int i = 0; i < B.GetLength(0); i++)
                if (B[i, j] == 0) { hasZero = true; break; }
            if (!hasZero)
            {
                RemoveColumn(ref B, j);
                j--;
            }
        }
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
        rows = new int[matrix.GetLength(0)];
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        cols = FindMaxNegativePerColumn(matrix);


        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }
    int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int ans = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[rowIndex, j] < 0) ans++;
        return ans;
    }
    int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > max && matrix[i, j] < 0) max = matrix[i, j];
            }
            ans[j] = max;
        }
        return ans;
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        int row, col;
        FindMaxIndex(A, out row, out col);
        SwapColumnDiagonal(A, col);
        FindMaxIndex(B, out row, out col);
        SwapColumnDiagonal(B, col);
    }
    void FindMaxIndex(int[,] matrix, out int row, out int col)
    {
        row = 0; col = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[row, col])
                {
                    row = i; col = j;
                }
            }
        }
    }
    void SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, i], matrix[i, columnIndex]) = (matrix[i, columnIndex], matrix[i, i]);
        }
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
        int ai = FindRowWithMaxNegativeCount(A);
        int bi = FindRowWithMaxNegativeCount(B);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            (A[ai, j], B[bi, j]) = (B[bi, j],  A[ai, j]);
        }
    }
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int imax = 0, maxNegCount = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int negCount = CountNegativeInRow(matrix, i);
            if (negCount > maxNegCount)
            {
                maxNegCount = negCount;
                imax = i;
            }
        }
        return imax;
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
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
    }
    int FindSequence(int[] array, int A, int B)
    {
        if (A >= B) return 0;
        bool inc = array[A] < array[A + 1];
        for (int i = A; i < B; i++)
        {
            if (inc && array[i] > array[i + 1]) return 0;
            if (!inc && array[i] < array[i + 1]) return 0;
        }
        return inc ? 1 : -1;
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        int n = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int seq = FindSequence(first, i, j);
                if (seq != 0) n++;
            }
        }
        answerFirst = new int[n, 2];
        n = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int seq = FindSequence(first, i, j);
                if (seq != 0)
                {
                    answerFirst[n, 0] = i;
                    answerFirst[n, 1] = j;
                    n++;
                }
            }
        }

        n = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int seq = FindSequence(second, i, j);
                if (seq != 0) n++;
            }
        }
        answerSecond = new int[n, 2];
        n = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int seq = FindSequence(second, i, j);
                if (seq != 0)
                {
                    answerSecond[n, 0] = i;
                    answerSecond[n, 1] = j;
                    n++;
                }
            }
        }
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        int s = 0, f = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int seq = FindSequence(first, i, j);
                if (seq != 0 && f - s < j - i)
                {
                    s = i;
                    f = j;
                }
            }
        }
        answerFirst = new int[] { s, f };

        s = 0; f = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int seq = FindSequence(second, i, j);
                if (seq != 0 && f - s < j - i)
                {
                    s = i;
                    f = j;
                }
            }
        }
        answerSecond = new int[] { s, f };
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
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0) sortStyle = SortAscending;
            else sortStyle = SortDescending;
            sortStyle(matrix, i);
        }
    }
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    void SortAscending(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n - 1 - i; j++)
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
    }
    void SortDescending(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n - 1 - i; j++)
                if (matrix[rowIndex, j] < matrix[rowIndex, j + 1])
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
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

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;
        if (isUpperTriangle)
            answer = GetSum(GetUpperTriangle, matrix);
        else
            answer = GetSum(GetLowerTriangle, matrix);
        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    int[] GetUpperTriangle(int[,] matrix) {
        int[] ans = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int ind = 0;
        for (int i = 0; i <  matrix.GetLength(0); i++)
            for (int j = i; j < matrix.GetLength(1); j++)
                ans[ind++] = matrix[i, j];
        return ans;
    }
    int[] GetLowerTriangle(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j <= i; j++)
                ans[ind++] = matrix[i, j];
        return ans;
    }
    int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        int[] arr = getTriangle(matrix);
        int ans = 0;
        foreach (int x in arr) ans += x * x;
        return ans;
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

    public void Task_3_6(int[,] matrix)
    {
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
    }
    public delegate int FindElementDelegate(int[,] matrix);
    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int imax = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (matrix[0, j] > matrix[0, imax]) imax = j;
        return imax;
    }
    void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int a = findDiagonalMaxIndex(matrix);
        int b = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
            (matrix[i, a], matrix[i, b]) = (matrix[i, b], matrix[i, a]);
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
        FindIndex searchArea = default(FindIndex);
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
    }
    public delegate int FindIndex(int[,] matrix);
    int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int imax = 0, jmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j <= i; j++)
                if (matrix[i, j] > matrix[imax, jmax])
                {
                    imax = i;
                    jmax = j;
                }
        return jmax;
    }
    int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int imin = 0, jmin = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = i + 1; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < matrix[imin, jmin])
                {
                    imin = i;
                    jmin = j;
                }
        return jmin;
    }
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

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        FindNegatives(matrix, CountNegativeInRows, FindMaxNegativePerColumn, out rows, out cols);
    }
    public delegate int[] GetNegativeArray(int[,] matrix);
    int[] CountNegativeInRows(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(0)];
        for (int i = 0; i <  matrix.GetLength(0); i++)
            ans[i] = CountNegativeInRow(matrix, i);
        return ans;
    }
    void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
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
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    bool FindIncreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == 1;
    }
    bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == -1;
    }
    int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1)) return 1;
        if (findDecreasingSequence(array, 0, array.Length - 1)) return -1;
        return 0;
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
    }
    int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int s = 0, f = 0;
        for (int i = 0; i <  array.Length; i++)
            for (int j = i + 1; j < array.Length; j++)
                if (sequence(array, i, j) && j - i > f - s)
                {
                    s = i; f = j;
                }
        return [s, f];
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        double[,] ans = new double[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                ans[i, j] = matrix[i, j];


        MatrixConverter[] mc = new MatrixConverter[4];
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;

        mc[index](ans);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
        for (int i = 0; i < ans.GetLength(0); i++)
        {
            for (int j = 0; j < ans.GetLength(1); j++)
                Console.Write(ans[i, j] + " ");
            Console.WriteLine();
        }
        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return ans;
    }
    void AddRowToRow(double[,] matrix, int r1, int r2, double a)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            matrix[r2, j] += a * matrix[r1, j];
    }
    delegate void MatrixConverter(double[,] matrix);
    void ToUpperTriangular(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(0); j++)
            {
                double k = - matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
        }
    }
    void ToLowerTriangular(double[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                double k = -matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
        }
    }
    void ToLeftDiagonal(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        ToUpperTriangular(matrix);
        for (int i = n - 1; i >= 0; i--)
            for (int j = i - 1; j >= 0; j--)
            {
                double k = - matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
    }
    void ToRightDiagonal(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        ToLowerTriangular(matrix);
        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
            {
                double k = -matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
    }
    #endregion
}
